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
    public int currentLevel = 0;
}

public class GameManager : MonoBehaviour
{
    private const string GameplayScene = "Gameplay";
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
    public LevelSettings[] _levelSettings;

    private GameData _gameData;
    private string _nextLevel;

    private void Awake()
    {
        if (Get != null)
        {
            if (Get != this)
            {
                Destroy(gameObject);
            }

        }
        else
        {
            Get = this;
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(gameObject);

            //SetRandomSkyMat();
            SceneManager.sceneLoaded += SetRandomSkyMat;
            ObjectsUnactive = new List<GameObject>();
            LoadGameData();
        }
    }
    private void SetRandomSkyMat()
    {
        if (Get.randomMaterial != null)
        {
            Get.materialsSettings = Get.randomMaterial.GetRandomMaterialSettings();
            RenderSettings.skybox = Get.materialsSettings.SkyboxMaterial;
        }
    }

    private void SetRandomSkyMat(Scene scene, LoadSceneMode loadSceneMode)
    {
        SetRandomSkyMat();
    }

    public void NewLevelComplete(int level, int score, string nextLevel)
    {
        _nextLevel = nextLevel;
        _gameData.lastLevelUnLock = Mathf.Max(level, _gameData.lastLevelUnLock);
        _gameData.currentLevel = level == _levelSettings.Length? 0 : level;
        if(_gameData.levelsScore.Count < level)
        {
            _gameData.levelsScore.Add(score);
        }
        else
        {
            print(level);
            print(_gameData.levelsScore.Count);
            _gameData.levelsScore[level - 1] = score;
        }
        SaveGameData();
        ChargeNextLevel();
    }

    public void ChargeNextLevel()
    {
        if(ObjectsUnactive != null)
            ObjectsUnactive.Clear();

        if (_nextLevel != null && !_nextLevel.Equals(""))
        {
            SceneManager.LoadScene(_nextLevel);
        }
        else
        {
            _nextLevel = GAMEPLAY_NAME;
            currentLevel = _levelSettings[_gameData.currentLevel];
            //SaveGameData();
            SceneManager.LoadScene(_nextLevel);
        }
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
        LoadLevelSettings(_gameData.currentLevel);
    }

    private void LoadLevelSettings(int actualLevel)
    {
        if (actualLevel >= _levelSettings.Length)
            actualLevel = 0;

        currentLevel = _levelSettings[actualLevel];
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
