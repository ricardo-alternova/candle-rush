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
    [SerializeField]
    private List<RectTransform> worlds;
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private Button lastButton;

    private int currentIndex = 0;

    private void Start()
    {
        nextButton.onClick.AddListener(TakeMeToNext);
        lastButton.onClick.AddListener(TakeMeToLast);
        checkButtonStatus();
        TakeMeToIndex();
    }

    private void TakeMeToIndex()
    {
        content.DOKill();
        content.DOAnchorPosX(-worlds[currentIndex].anchoredPosition.x, 1f).SetEase(Ease.InBack);
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
