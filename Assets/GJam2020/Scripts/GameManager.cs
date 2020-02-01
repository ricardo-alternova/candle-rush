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
   

    private void Awake()
    {
        if(Get == null)
        {
            Get = this;
            DontDestroyOnLoad(gameObject);
            LoadGameData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NewLevelComplete(int level, int score)
    {
        if(_gameData.levelsScore.Count < level)
        {
            _gameData.levelsScore.Add(score);
            _gameData.lastLevelUnLock = level;
        }
        else
        {
            _gameData.levelsScore[level] = score;
        }
        SaveGameData();
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
