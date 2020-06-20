using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private LevelSettings settings;

    public static LevelManager Get;

    public int LevelNumber
    {
        get { return settings.Number; }
    }

    public int Score
    {
        get { return settings.Score; }
    }

    public LevelSettings NextLevel
    {
        get { return settings.NextLevel; }
    }

    private void Awake()
    {
        settings = GameManager.Get.currentLevel;
    }

    private void Start()
    {
        Get = this;
    }
}
