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
    private const string SceneNamePrefix = "Level";
    private int _score;
    
    private void Start()
    {
        _button.interactable = false;
        _star.gameObject.SetActive(false);

        Debug.Log("Level: " + _level);
        if(_level <= GameManager.Get.GetLastLevelComplete() + 1)
        {
            Debug.Log("Enable: " + _level);
            IsEnable();
        }

        if(_level <= GameManager.Get.GetLastLevelComplete())
        {
            Debug.Log("Unlock: " + _level);
            //_score = GameManager.Get.GetLevelScore(_level);
            ShowAsUnlock();
        }
        Init();
    }

    [ContextMenu("Setup")]
    private void Init()
    {
        var textMP = _button.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        Assert.IsNotNull(textMP, "Not textMP component found");
        textMP.text = _level.ToString();

        //var chargeScene = GetComponentInParent<ChargeScene>();
        //Assert.IsNotNull(chargeScene);

        var button = GetComponentInChildren<Button>();
        string sceneName = SceneNamePrefix + _level;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => LoadScene(sceneName));
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void ShowAsUnlock()
    {
        _button.interactable = true;
        _star.gameObject.SetActive(false);
    }

    private void IsEnable()
    {
        _button.interactable = true;
    }
}
