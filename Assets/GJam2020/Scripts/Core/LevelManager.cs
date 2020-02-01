using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int LevelNumber=0;
    public int Score = 0;
    public string NextLevel = "";

    public static LevelManager Get;

    private void Start()
    {
        Get = this;
    }
}
