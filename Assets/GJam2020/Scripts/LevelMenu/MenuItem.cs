using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    public int level;
    [SerializeField]
    private GameObject[] _stars;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Sprite starWonSprite;

    public LevelSettings levelSettings;

    private TextMeshProUGUI _label;
    private const string GameplayScene = "Gameplay";
    private int _score;
    
    private void Start()
    {
        _button.interactable = false;
        foreach (GameObject star in _stars)
        {
            star.gameObject.SetActive(false);
        }
        _label = _button.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        Assert.IsNotNull(_label, "Not textMP component found");
        _label.color = new Color(1, 1, 1, 0.5f);
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        IsEnable();
        if (GameManager.Get.CurrentLevel == level)
            _button.transform.localScale *= 1.3f;

        ShowAsUnlock();
#else
        Debug.Log("Level: " + level);
        if(level <= GameManager.Get.GetLastLevelComplete() + 1)
        {
            Debug.Log("Enable: " + level);
            IsEnable();
            if (GameManager.Get.CurrentLevel == level)
                _button.transform.localScale *= 1.3f;
        }

        if(level <= GameManager.Get.GetLastLevelComplete())
        {
            Debug.Log("Unlock: " + level);
            ShowAsUnlock();
        }
#endif

        Init();
    }

    [ContextMenu("Setup")]
    private void Init()
    {
        _label.text = level.ToString();

        var button = GetComponentInChildren<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => LoadScene());
    }

    public void LoadScene()
    {
        GameManager.Get.currentLevel = levelSettings;
        GameManager.Get.ChargeNextLevel();
    }

    private void ShowAsUnlock()
    {
        _label.color = Color.white;
        _button.interactable = true;
        int starstNumber = GameManager.Get.GetLevelScore(level);
        for(int i = 0; i < _stars.Length; i++)
        {
            _stars[i].SetActive(true);
            if (i < starstNumber)
                _stars[i].GetComponent<Image>().sprite = starWonSprite;
        }
        
    }

    private void IsEnable()
    {
        _label.color = Color.white;
        _button.interactable = true;
    }
}
