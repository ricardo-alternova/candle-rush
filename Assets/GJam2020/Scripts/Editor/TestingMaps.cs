using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace Tests
{
    // Validates the level maps stored as Resources/1.csv .. 50.csv.
    // Each rule is a test case per map, so the Test Runner lists failures by map number.
    public class TestingMaps
    {
        private const int MapCount = 50;
        private const int MaxListedCells = 10;

        private static readonly Color White = new Color(1, 1, 1);

        private MapGeneratorSettings settings;
        private Color teleporterColor;

        public static IEnumerable<int> MapNumbers()
        {
            return Enumerable.Range(1, MapCount);
        }

        private class Cell
        {
            public int Row;
            public int Column;
            public string Raw;
            public bool Parsed;
            public Color Color;
            public bool Known;
            public MapEntity Entity;

            public override string ToString()
            {
                return "'" + Raw + "' at row " + Row + ", column " + Column;
            }
        }

        private class Map
        {
            public int Number;
            public List<List<Cell>> Rows = new List<List<Cell>>();

            public IEnumerable<Cell> Cells { get { return Rows.SelectMany(r => r); } }
        }

        // Groups colors with Unity's approximate Color ==, the same comparison TryResolve uses.
        // The hash is constant because approximate equality cannot be hashed consistently.
        private class ColorComparer : IEqualityComparer<Color>
        {
            public bool Equals(Color a, Color b) { return a == b; }
            public int GetHashCode(Color color) { return 0; }
        }

        // Common_Map is loaded once for the whole fixture instead of once per test case.
        [OneTimeSetUp]
        public void LoadSettings()
        {
            settings = Resources.Load<MapGeneratorSettings>("Common_Map");
            Assert.IsNotNull(settings, "Resources/Common_Map could not be loaded");
            teleporterColor = TeleporterSpecialColor(settings);
        }

        // Same format MapGenerator.GetColorFromCsv reads: rows split by '\n', cells by ',', channels by '-'.
        private Map LoadMap(int number)
        {
            TextAsset asset = Resources.Load<TextAsset>(number.ToString(CultureInfo.InvariantCulture));
            Assert.IsNotNull(asset, "Map " + number + ": Resources/" + number + ".csv could not be loaded");

            Map map = new Map { Number = number };
            string[] lines = asset.text.Split('\n');
            for (int r = 0; r < lines.Length; r++)
            {
                List<Cell> row = new List<Cell>();
                string[] cells = lines[r].Split(',');
                for (int c = 0; c < cells.Length; c++)
                {
                    Cell cell = new Cell { Row = r, Column = c, Raw = cells[c].Trim() };
                    cell.Parsed = TryParseColor(cell.Raw, out cell.Color);
                    if (cell.Parsed)
                        cell.Known = TryResolve(settings, teleporterColor, cell.Color, out cell.Entity);
                    row.Add(cell);
                }
                map.Rows.Add(row);
            }
            return map;
        }

        private static bool TryParseColor(string raw, out Color color)
        {
            color = default(Color);
            string[] parts = raw.Split('-');
            if (parts.Length != 3)
                return false;

            float r, g, b;
            NumberStyles style = NumberStyles.Float;
            if (!float.TryParse(parts[0], style, CultureInfo.InvariantCulture, out r)
                || !float.TryParse(parts[1], style, CultureInfo.InvariantCulture, out g)
                || !float.TryParse(parts[2], style, CultureInfo.InvariantCulture, out b))
                return false;

            color = new Color(r, g, b);
            return true;
        }

        // Mirrors MapGeneratorSettings.GetPrefab: prefabs list first, then the ground and teleporter
        // specials, plus white (accepted by TestingPortals). An unmatched color is reported as unknown
        // but, like GetPrefab's fallback, still counted as a teleporter.
        private static bool TryResolve(MapGeneratorSettings settings, Color teleporterColor, Color color, out MapEntity entity)
        {
            ColorPrefabRelation prefab = settings.prefabs.Find(p => p.Color == color);
            if (prefab != null)
            {
                entity = prefab.Entity;
                return true;
            }

            if (settings.Ground.Color == color || color == White)
            {
                entity = MapEntity.ground;
                return true;
            }

            entity = MapEntity.teleporter;
            return teleporterColor == color;
        }

        // The teleporter special is a private serialized field with no getter.
        private static Color TeleporterSpecialColor(MapGeneratorSettings settings)
        {
            SerializedProperty property = new SerializedObject(settings).FindProperty("teleporter.color");
            Assert.IsNotNull(property, "Common_Map has no serialized teleporter.color field");
            return property.colorValue;
        }

        private static string Listed(IEnumerable<Cell> cells)
        {
            List<Cell> list = cells.ToList();
            string text = string.Join("; ", list.Take(MaxListedCells).Select(c => c.ToString()).ToArray());
            if (list.Count > MaxListedCells)
                text += "; ... (" + (list.Count - MaxListedCells) + " more)";
            return text;
        }

        private static IEnumerable<Cell> CellsOf(Map map, MapEntity entity)
        {
            return map.Cells.Where(c => c.Parsed && c.Entity == entity);
        }

        [Test, TestCaseSource(nameof(MapNumbers))]
        public void Rule1_AllRowsHaveSameCellCount(int number)
        {
            Map map = LoadMap(number);
            int expected = map.Rows[0].Count;
            List<string> broken = new List<string>();
            for (int r = 1; r < map.Rows.Count; r++)
            {
                if (map.Rows[r].Count != expected)
                    broken.Add("row " + r + " has " + map.Rows[r].Count + " cells");
            }

            Assert.IsEmpty(broken, "Map " + number + " - rule 1 (rectangular rows): row 0 has " + expected
                + " cells but " + string.Join("; ", broken.ToArray()));
        }

        [Test, TestCaseSource(nameof(MapNumbers))]
        public void Rule2_ExactlyOneStartAndOneEnd(int number)
        {
            Map map = LoadMap(number);
            List<Cell> starts = CellsOf(map, MapEntity.startFlag).ToList();
            List<Cell> ends = CellsOf(map, MapEntity.endFlag).ToList();

            List<string> broken = new List<string>();
            if (starts.Count != 1)
                broken.Add(starts.Count + " start flags [" + Listed(starts) + "]");
            if (ends.Count != 1)
                broken.Add(ends.Count + " end flags [" + Listed(ends) + "]");

            Assert.IsEmpty(broken, "Map " + number + " - rule 2 (exactly one start and one end flag): found "
                + string.Join("; ", broken.ToArray()));
        }

        [Test, TestCaseSource(nameof(MapNumbers))]
        public void Rule3_TeleportersComeInPairs(int number)
        {
            Map map = LoadMap(number);
            List<Cell> teleporters = CellsOf(map, MapEntity.teleporter).ToList();
            List<string> broken = teleporters
                .GroupBy(c => c.Color, new ColorComparer())
                .Where(g => g.Count() != 2)
                .Select(g => "color '" + g.First().Raw + "' appears " + g.Count() + " times (" + Listed(g) + ")")
                .ToList();

            if (teleporters.Count % 2 != 0)
                broken.Insert(0, teleporters.Count + " teleporter cells in total (odd)");

            Assert.IsEmpty(broken, "Map " + number + " - rule 3 (teleporter pairs): "
                + string.Join("; ", broken.ToArray()));
        }

        [Test, TestCaseSource(nameof(MapNumbers))]
        public void Rule4_KeysMatchDoors(int number)
        {
            Map map = LoadMap(number);
            List<Cell> keys = CellsOf(map, MapEntity.key).ToList();
            List<Cell> doors = CellsOf(map, MapEntity.door).ToList();

            Assert.AreEqual(doors.Count, keys.Count, "Map " + number + " - rule 4 (keys match doors): "
                + keys.Count + " keys [" + Listed(keys) + "] vs " + doors.Count + " doors [" + Listed(doors) + "]");
        }

        [Test, TestCaseSource(nameof(MapNumbers))]
        public void Rule5_EveryColorIsKnown(int number)
        {
            Map map = LoadMap(number);
            List<Cell> unparsed = map.Cells.Where(c => !c.Parsed).ToList();
            List<Cell> unknown = map.Cells.Where(c => c.Parsed && !c.Known).ToList();

            List<string> broken = new List<string>();
            if (unparsed.Count > 0)
                broken.Add("unparsable cells " + Listed(unparsed));
            if (unknown.Count > 0)
                broken.Add("colors not in Common_Map " + Listed(unknown));

            Assert.IsEmpty(broken, "Map " + number + " - rule 5 (known colors): "
                + string.Join("; ", broken.ToArray()));
        }
    }
}
