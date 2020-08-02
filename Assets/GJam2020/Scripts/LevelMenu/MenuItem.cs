using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    public int level;
    [SerializeField]
    private GameObject _star;
    [SerializeField]
    private Button _button;
    
    public LevelSettings levelSettings;

    private TextMeshProUGUI _label;
    private const string GameplayScene = "Gameplay";
    private int _score;
    
    private void Start()
    {
        _button.interactable = false;
        _star.gameObject.SetActive(false);
        _label = _button.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        Assert.IsNotNull(_label, "Not textMP component found");
        _label.color = new Color(1, 1, 1, 0.5f);

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
        _star.gameObject.SetActive(true);
    }

    private void IsEnable()
    {
        _label.color = Color.white;
        _button.interactable = true;
    }
}
