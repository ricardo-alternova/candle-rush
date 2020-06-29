using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml.Serialization;

using UnityEngine.SceneManagement;
using GJam2020.Core;
using GJam2020.Avatar;
using UnityEngine.Assertions;

[System.Serializable]
public class GameData
{
    public List<int> levelsScore = new List<int>();
    public int lastLevelUnLock = 0;
}

public class GameManager : MonoBehaviour
{
    public bool IsPlaying;
    public LevelSettings currentLevel;
    public MaterialsSettings materialsSettings;
    public RandomMaterialConfig randomMaterial;
    public PlayerMovement playerMovement;
    public List<GameObject> ObjectsUnactive=new List<GameObject>();
    public static GameManager Get;
    public static string MAIN_MENU_NAME = "MainMenu";
    public static string LEVELS_MENU_NAME = "LevelsMenu";
    public static string GAMEPLAY_NAME = "Gameplay";

    private GameData _gameData;
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
                Get.ObjectsUnactive = new List<GameObject>();
                Get.playerMovement = playerMovement;
                Destroy(gameObject);
            }
        }
        if (Get.randomMaterial != null)
        {
            Get.materialsSettings = Get.randomMaterial.GetMaterialSettings();
            RenderSettings.skybox = Get.materialsSettings.SkyboxMaterial;
        }
        ObjectsUnactive = new List<GameObject>();
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
            _gameData.levelsScore[level - 1] = score;
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
        if(_gameData==null)
            LoadGameData();
        return _gameData.lastLevelUnLock;
    }

    public int GetLevelScore(int level)
    {
        if(level <= _gameData.lastLevelUnLock)
        {
            return _gameData.levelsScore[level-1];
        }
        return 0;
    }
    private void LoadGameData()
    {
        
        XmlSerializer serializer = new XmlSerializer(typeof(GameData));
        string text = PlayerPrefs.GetString("Gamedata");
        if(text.Length == 0)
        {
            _gameData = new GameData();
        }
        else
        {
            using(var reader = new StringReader(text))
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
    
    public void AddElementToRestore(GameObject objeto)
    {
        ObjectsUnactive.Add(objeto);
    }

    public void Restore()
    {
        print("Restore");
        if (playerMovement == null)
            playerMovement = GameObject.Find("Root/Environment/WaxBoy").GetComponent<PlayerMovement>();
        Assert.IsNotNull(playerMovement, "Player movement not found");

        
        CommandsManager.Instance.StartRewindCommands(playerMovement, (() => { 
            Debug.Log("Rewind finished");
            foreach (GameObject obj in ObjectsUnactive)
            {
                obj.SetActive(true);
            }
        }));

        IsPlaying = true;
    }
}
