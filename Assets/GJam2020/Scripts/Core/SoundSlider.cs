using GJam2020.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GJam2020.Core.SoundManager;

public class SoundSlider : MonoBehaviour
{
    public SoundType type;
    
    private void Start()
    {
        gameObject.GetComponent<Slider>().value = Get().GetVolumePercent(type);
        gameObject.GetComponent<Slider>().onValueChanged.AddListener(valueChange);
    }
    private void valueChange(float value)
    {
        Get().SetVolumePercent((int)value, type);
    }
}
