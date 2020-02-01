using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    public int level;
    public Sprite colorStar;
    private int _score;
    private GameObject _panelActive;
    private GameObject _panelUnlock;
    private GameObject _panelUnActive;

    private void Start()
    {
        _panelActive = transform.Find("PanelActive").gameObject;
        _panelUnlock = transform.Find("PanelUnLock").gameObject;
        _panelUnActive = transform.Find("PanelUnActive").gameObject;
        Debug.Log("level" + level);
        if(level <= GameManager.Get.GetLastLevelComplete() + 1)
        {
            Debug.Log("enable" + level);
            IsEnable();
        }

        if(level <= GameManager.Get.GetLastLevelComplete())
        {
            Debug.Log("unlock" + level);
            _score = GameManager.Get.GetLevelScore(level);
            ShowAsUnlock();
        }
    }

    private void ShowAsUnlock()
    {
        _panelUnlock.SetActive(true);
        _panelActive.SetActive(false);

    }

    private void IsEnable()
    {
        _panelActive.SetActive(true);
        _panelUnActive.SetActive(false);
        _panelUnlock.SetActive(false);
    }
}
