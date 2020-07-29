using GJam2020.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static GJam2020.Core.SoundManager;

[RequireComponent(typeof(Toggle))]
public class AudioToggle : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private SoundType soundType;

    private SoundManager manager;
    private Toggle toggle;

    private void Start()
    {
        manager = SoundManager.Get();
        toggle = GetComponent<Toggle>();
    }

    private void Update()
    {
        switch (soundType)
        {
            case SoundType.UI:
                toggle.isOn = !manager.IsUIEnabled;
                break;
            case SoundType.FX:
                toggle.isOn = !manager.IsFxEnabled;
                break;
            case SoundType.SONG:
                toggle.isOn = !manager.IsSongEnable;
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (soundType)
        {
            case SoundType.UI:
                manager.EnableUI(!manager.IsUIEnabled);
                break;
            case SoundType.FX:
                manager.EnableFx(!manager.IsFxEnabled);
                break;
            case SoundType.SONG:
                manager.EnableSong(!manager.IsSongEnable);
                break;
        }
    }
}
