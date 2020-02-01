using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml.Serialization;

using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public List<int> levelsScore = new List<int>();
    public int lastLevelUnLock = 0;
}

public class GameManager : MonoBehaviour
{
    private GameData _gameData;
    public static GameManager Get;
    private string _nextLevel;
   

    private void Awake()
    {
        if(Get == null)
        {
            Get = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            if(Get != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        LoadGameData();
    }

    public void NewLevelComplete(int level, int score, string nextLevel)
    {
        _nextLevel = nextLevel;
        if(_gameData.levelsScore.Count < level)
        {
            _gameData.levelsScore.Add(score);
            _gameData.lastLevelUnLock = level;
        }
        else
        {
            print(level);
            print(_gameData.levelsScore.Count);
            _gameData.levelsScore[level-1] = score;
        }
        SaveGameData();
        SceneManager.LoadScene("IntersectionScene");
    }

    public void ChargeNextLevel()
    {
        SceneManager.LoadScene(_nextLevel);
    }

    public int GetLastLevelComplete()
    {
        return _gameData.lastLevelUnLock;
    }

    public int GetLevelScore(int level)
    {
        if(level <= _gameData.lastLevelUnLock)
        {
            return _gameData.levelsScore[level];
        }
        return 0;
    }

    private void LoadGameData()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GameData));
        string text = PlayerPrefs.GetString("Gamedata");
        if (text.Length == 0)
        {
            _gameData = new GameData();
        }
        else
        {
            using (var reader = new StringReader(text))
            {
                _gameData = serializer.Deserialize(reader) as GameData;
            }
        }
    }

    private void SaveGameData()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GameData));
        using(StringWriter sw = new StringWriter())
        {
            serializer.Serialize(sw, _gameData);
            PlayerPrefs.SetString("Gamedata", sw.ToString());
        }
    }

    public void LoadLevelScene()
    {
        SceneManager.LoadScene("LevelsMenu");
    }

}
