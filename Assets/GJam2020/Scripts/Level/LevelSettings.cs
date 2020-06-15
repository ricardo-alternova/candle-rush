using UnityEngine;

public class LevelSettings : ScriptableObject
{
    [SerializeField]
    private int number;
    [SerializeField]
    private Texture2D map;
    [SerializeField]
    private Vector3 startLocation;
    [SerializeField]
    private int score;
    [SerializeField]
    private LevelSettings nextLevel;

    public int Number { get => number; }
    public Texture2D Map { get => map; }
    public int Score { get => score; }
    public LevelSettings NextLevel { get => nextLevel; }
    public Vector3 StartLocation { get => startLocation; }
}
