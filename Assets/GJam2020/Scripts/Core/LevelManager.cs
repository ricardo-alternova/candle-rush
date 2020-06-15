using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private LevelSettings settings;

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

    public static LevelManager Get;

    private void Awake()
    {
        settings = GameManager.Get.currentLevel;
    }

    private void Start()
    {
        Get = this;
    }
}
