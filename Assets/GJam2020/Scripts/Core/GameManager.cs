using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using GJam2020.Core;
using GJam2020.Avatar;
using GGJ2020.Avatar;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Assertions;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
    public List<int> levelsScore = new List<int>();
    public int lastLevelUnLock = 0;
    public int currentLevel = 0;
}

public class GameManager : MonoBehaviour
{
    public bool IsPlaying;
    public LevelSettings firstLevel;
    public LevelSettings currentLevel;
    public MaterialsSettings materialsSettings;
    public RandomMaterialConfig randomMaterial;
    public PlayerMovement playerMovement;
    public List<GameObject> ObjectsUnactive=new List<GameObject>();
    public static GameManager Get;
    public static string MAIN_MENU_NAME = "MainMenu";
    public static string LEVELS_MENU_NAME = "LevelsMenu";
    public static string GAMEPLAY_NAME = "Gameplay";
    public int CurrentLevel { get { return _gameData.currentLevel; } }
    public UnityEvent StartGame;

    [Tooltip("Set to -1 to enable all levels.")]
    [SerializeField]
    private int levelsAvailables = -1;
    private LevelSettings[] _levelSettings;
    private GameData _gameData;
    private string _nextScene;

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
            SceneManager.sceneLoaded += OnSceneLoaded;
            ObjectsUnactive = new List<GameObject>();
            LoadGameData();
        }
    }

    public void NewLevelComplete(int level, int score, string nextLevel)
    {
        _nextScene = nextLevel;
        _gameData.lastLevelUnLock = Mathf.Max(level, _gameData.lastLevelUnLock);
        _gameData.currentLevel = level;
        if(_gameData.levelsScore.Count < level)
        {
            _gameData.levelsScore.Add(score);
        }
        else
        {
            if(_gameData.levelsScore[level-1]<score)
                _gameData.levelsScore[level - 1] = score;
        }
        SaveGameData();
        ChargeNextLevel();
    }

    public void ChargeOrReload()
    {
        if (_nextScene.Equals(MAIN_MENU_NAME))
        {
            Get.currentLevel = _levelSettings[0];
            _nextScene = GAMEPLAY_NAME;
        }
        ChargeNextLevel();
    }

    public void ChargeNextLevel()
    {
        if (ObjectsUnactive != null)
            ObjectsUnactive.Clear();

        if (!(_nextScene != null && !_nextScene.Equals("")))
        {
            _nextScene = GAMEPLAY_NAME;
        }
        if (currentLevel == null)
        {
            LoadLevelSettings(_gameData.currentLevel);
        }
        _gameData.currentLevel = currentLevel.Number;
        SaveGameData();
        Debug.Log("Current: " + _gameData.currentLevel);
        
        if(levelsAvailables > -1 && _gameData.currentLevel > levelsAvailables)
        {
            currentLevel = firstLevel;
            _gameData.currentLevel = currentLevel.Number;
            SaveGameData();
            Debug.Log("LOAD MAIN MENU");
            SceneManager.LoadScene(MAIN_MENU_NAME);
        }
        else
            SceneManager.LoadScene(_nextScene);
    }

    public int GetLastLevelComplete()
    {
        if(_gameData==null)
            LoadGameData();
        return _gameData.lastLevelUnLock;
    }

    public int GetLevelScore(int level)
    {
        if(level <= _gameData.lastLevelUnLock && 
            level <= _gameData.levelsScore.Count)
        {
            return _gameData.levelsScore[level-1];
        }
        return 0;
    }
    
    public void AddElementToRestore(GameObject elementGO)
    {
        ObjectsUnactive.Add(elementGO);
    }

    public void RemoveelementToRestore(GameObject elementGO)
    {
        ObjectsUnactive.Remove(elementGO);
    }

    public void ResetCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Restore()
    {
        print("Restore");
        if (playerMovement == null)
            playerMovement = GameObject.Find("Root/Environment/WaxBoy").GetComponent<PlayerMovement>();
        Assert.IsNotNull(playerMovement, "Player movement not found");

        IsPlaying = false;

        CommandsManager.Instance.StartRewindCommands(playerMovement, (() => { 
            Debug.Log("Rewind finished");
            IsPlaying = true;
            StartGame.Invoke();
            foreach (GameObject obj in ObjectsUnactive)
            {
                obj.SetActive(true);
            }
            CheckAvatarStartPosition();
            AvatarPosition.Restart();
            })
        );
    }

    private int ParseLevel(string levelName)
    {
        int level;
        Debug.Log(levelName);
        string probableNumber = levelName.Split('_')[1];
        if (!int.TryParse(probableNumber, out level))
            return -1;
        else
            return level;
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("Gameplay"))
            StartGame.Invoke();
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
        LevelSettings aux = firstLevel;
        while (aux != null && aux.Number != actualLevel)
        {
            aux = aux.NextLevel;
        }
        if (aux != null)
            currentLevel = aux;
        else
            currentLevel = firstLevel;
    }

    private void SaveGameData()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GameData));
        using(StringWriter sw = new StringWriter())
        {
            serializer.Serialize(sw, _gameData);
            PlayerPrefs.SetString("Gamedata", sw.ToString());
            Debug.Log("Game data saved");
        }
    }

    private void CheckAvatarStartPosition()
    {
        var difference = (MapGenerator.Get.StartPosition - AvatarPosition.AVATAR_POSITION).magnitude;
        if (difference > 0.4f)
        {
            Debug.LogWarning("Scene reloaded because avatar was to far from start position: " + difference);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
