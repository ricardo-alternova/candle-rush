using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapTransform : MonoBehaviour
{
    public Texture2D[] maps;
    public MapGeneratorSettings settings;
    private List<Vector3> _obstaclesPosition = new List<Vector3>();

    public string CsvFinal;
    private void Start()
    {
        foreach (Texture2D originalMap in maps)
        {
            CsvFinal = "";
            string path = "Assets/Resources/{0}.csv";
            int width = originalMap.width;
            int height = originalMap.height;
            Color[] colors = originalMap.GetPixels();
            float fPos = 0;
            float cPos = 0;
            for (int f = 0; f < height; f++)
            {
                List<string> Line = new List<string>();
                for (int c = 0; c < width; c++)
                {

                    Color color = colors[((f * width) + c)];
                    string scolor = string.Format("{0}-{1}-{2}", color.r, color.g, color.b);
                    Line.Add(scolor.ToString());
                    cPos += 1;
                }
                fPos += 1;
                cPos = 0;
                CsvFinal += string.Join(",", Line);
                if (f < height - 1)
                {
                    CsvFinal += "\n";
                }
            }
            path = string.Format(path, originalMap.name.Replace(".png", ""));
            ////Write some text to the test.txt file
            //if (!File.Exists(path))
            //{
            //    File.Create(path);
            //}
            File.WriteAllText(path, CsvFinal);
        }
    }
}
