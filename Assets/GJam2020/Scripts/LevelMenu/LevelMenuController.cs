using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuController : MonoBehaviour
{
    [SerializeField]
    private RectTransform _scrollViewContent;
    [SerializeField]
    private ScrollRect _scrollRect;

    void Start()
    {
        StartCoroutine(AdjustContentSize());
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator AdjustContentSize()
    {
        yield return new WaitForEndOfFrame();

        var parentRTransform = _scrollViewContent.parent.GetComponent<RectTransform>();
        _scrollViewContent.anchorMin = new Vector2(0, 0);
        _scrollViewContent.anchorMax = new Vector2(1, 1);

        _scrollViewContent.offsetMin = new Vector2(0, 0);
        _scrollViewContent.offsetMax = new Vector2(parentRTransform.rect.width, 0);
        //_scrollRect.normalizedPosition = new Vector2(0.5f, 0.5f);
    }
}
