using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    [SerializeField]
    private int _level;
    [SerializeField]
    private GameObject _star;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private LevelSettings levelSettings;

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

        Debug.Log("Level: " + _level);
        if(_level <= GameManager.Get.GetLastLevelComplete() + 1)
        {
            Debug.Log("Enable: " + _level);
            IsEnable();
        }

        if(_level <= GameManager.Get.GetLastLevelComplete())
        {
            Debug.Log("Unlock: " + _level);
            ShowAsUnlock();
        }
        Init();
    }

    [ContextMenu("Setup")]
    private void Init()
    {
        _label.text = _level.ToString();

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
