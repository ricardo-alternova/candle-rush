using UnityEngine;

[CreateAssetMenu(fileName = "new Map Config", menuName = "LevelConfig")]
public class LevelSettings : ScriptableObject
{
    [SerializeField]
    private int number;
    [SerializeField]
    private Vector3 startLocation;

    [SerializeField]
    private int maxTime3Stars;

    [SerializeField]
    private int maxTime2Stars;

    [SerializeField]
    private MapGeneratorSettings mapSettings;
    [SerializeField]
    private LevelSettings nextLevel;
    [SerializeField]
    private AudioClip soundBackground;

    public int Number { get => number; }
    public string MapName { get => number.ToString(); }
    public int GetStarts(float time) {
        if (time <= maxTime3Stars)
        {
            return 3;
        }
        if (time <= maxTime2Stars)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
    public LevelSettings NextLevel { get => nextLevel; }
    public Vector3 StartLocation { get => startLocation; }
    public MapGeneratorSettings MapSettings { get => mapSettings; }
    public AudioClip SoundBackground { get => soundBackground; }
}
