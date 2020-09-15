using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    private int lastButtonSelected = 0;

    private List<Selectable> buttonsNavigation = new List<Selectable>();

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
            ISelectable auxSelectable = levelButton.GetComponentInChildren<ISelectable>();
            auxSelectable.navigation = this;
            auxSelectable.index = indexLevel;
            buttonsNavigation.Add(levelButton.GetComponentInChildren<Selectable>());
            int count = buttonsNavigation.Count;
            if (count > 1)
            {
                Navigation nav = new Navigation
                {
                    mode=Navigation.Mode.Explicit,
                    selectOnRight= buttonsNavigation[count-1] 
                };
                if (count > 2)
                {
                    nav.selectOnLeft = buttonsNavigation[count-3];
                }
                if (count > 3)
                {
                    nav.selectOnUp = buttonsNavigation[count - 4];

                    Navigation auxNav = buttonsNavigation[count - 4].GetComponent<Button>().navigation;
                    auxNav.selectOnDown = buttonsNavigation[count - 2];
                    buttonsNavigation[count - 4].GetComponent<Button>().navigation = auxNav;
                }
                buttonsNavigation[count - 2].GetComponent<Button>().navigation = nav;

            }
            if (indexLevel == 0)
            {
                GetComponent<FocusDefect>().goSelected = levelButton.GetComponentInChildren<Button>().gameObject;
            }
            MenuItem menuItem = levelButton.GetComponent<MenuItem>();
            menuItem.level = indexLevel + 1;
            menuItem.levelSettings = auxSettings;
            auxSettings = auxSettings.NextLevel;
            indexLevel++;
        }
    }

    public void onSelectButton(int index)
    {
        lastButtonSelected = index;
        int indexExpected = (int)(index / 6f);
        if (indexExpected > currentIndex)
        {
            TakeMeToNext();
        }
        else if (indexExpected < currentIndex)
        {
            TakeMeToLast();
        }

    }

    private void TakeMeToIndex()
    {
        if ((int)(lastButtonSelected / 6f) != currentIndex)
        {
            EventSystem.current.SetSelectedGameObject(buttonsNavigation[currentIndex * 6].gameObject);
        }
        content.DOKill();
        content.DOAnchorPosX(-worlds[currentIndex].anchoredPosition.x, 0.6f).SetEase(Ease.InBack);
        checkButtonStatus();
        GetComponent<FocusDefect>().goSelected=buttonsNavigation[currentIndex * 6].gameObject;
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
