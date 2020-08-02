using System.Collections.Generic;
using UnityEngine;

public enum MapEntity 
{
    none = 0,
    hole = 1,
    ground = 2,
    wall = 3,
    endFlag = 4,
    startFlag = 5,
    extraLife = 6, 
    teleporter = 7,
    door = 8,
    key = 9,
    iceCube = 10
}


[System.Serializable]
public class MapGeneratorSettings : ScriptableObject
{
    [SerializeField]
    private ColorPrefabRelation ground;
    [SerializeField]
    private ColorPrefabRelation teleporter;
    [SerializeField]
    private List<ColorPrefabRelation> prefabs;

    public ColorPrefabRelation Ground { get => ground; }

    public ColorPrefabRelation GetPrefab(Color color)
    {
        ColorPrefabRelation prefab = prefabs.Find(p => p.Color == color);

        if (prefab != null)
            return prefab;
        else
        {
            if (ground.Color == color)
                return ground;

            if (teleporter.Color == color)
                return teleporter;

            Debug.LogWarning("There in not coincidence for ColorPrefabRelation of: " + color.ToString());
            return teleporter;
        }
    }
}

[System.Serializable]
public class ColorPrefabRelation
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private MapEntity entity;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float offset;
    [SerializeField]
    private bool isObstacle;
    [SerializeField]
    private bool isEmpty;
    [SerializeField]
    private bool useGround;
    [SerializeField]
    private bool usePairPosition;

    public Color Color { get => color; }
    public GameObject Prefab { get => prefab; }
    public float Offset { get => offset; }
    public bool IsObstacle { get => isObstacle; }
    public bool UseGround { get => useGround; }
    public bool IsEmpty { get => isEmpty; }
    public MapEntity Entity { get => entity; }
    public bool UsePairPosition { get => usePairPosition; }
}
