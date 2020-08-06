using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class WorldsNavigation : MonoBehaviour
{
    [SerializeField]
    private RectTransform content;

    private List<RectTransform> worlds;

    [SerializeField]
    private GameObject panelPrefab;
    [SerializeField]
    private GameObject levelPrefab;
    [SerializeField]
    private LevelSettings firstLevel;

    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private Button lastButton;

    private int currentIndex = 0;

    private void Start()
    {
        BuildLevelButtons();
        nextButton.onClick.AddListener(TakeMeToNext);
        lastButton.onClick.AddListener(TakeMeToLast);
        checkButtonStatus();
        TakeMeToIndex();
    }

    private void BuildLevelButtons()
    {
        worlds = new List<RectTransform>();
        LevelSettings auxSettings = firstLevel;
        Transform panelAux = null;
        int indexLevel = 0;
        while (auxSettings != null)
        {
            if (indexLevel % 6 == 0)
            {
                panelAux = Instantiate(panelPrefab, content).transform;
                worlds.Add(panelAux.GetComponent<RectTransform>());
            }
            GameObject levelButton = Instantiate(levelPrefab, panelAux);
            MenuItem menuItem = levelButton.GetComponent<MenuItem>();
            menuItem.level = indexLevel + 1;
            menuItem.levelSettings = auxSettings;
            auxSettings = auxSettings.NextLevel;
            indexLevel++;
        }
    }

    private void TakeMeToIndex()
    {
        content.DOKill();
        content.DOAnchorPosX(-worlds[currentIndex].anchoredPosition.x, 0.6f).SetEase(Ease.InBack);
        checkButtonStatus();
    }

    private void checkButtonStatus()
    {
        lastButton.interactable = currentIndex > 0;
        nextButton.interactable = currentIndex < worlds.Count - 1;
    }

    private void TakeMeToNext()
    {
        if (currentIndex < worlds.Count - 1)
        {
            currentIndex++;
            TakeMeToIndex();
        }
    }

    private void TakeMeToLast()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            TakeMeToIndex();
        }
    }
}
