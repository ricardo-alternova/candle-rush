using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ISelectable : MonoBehaviour, ISelectHandler
{
    [HideInInspector]
    public WorldsNavigation navigation;

    [HideInInspector]
    public int index;

    public void OnSelect(BaseEventData eventData)
    {
        navigation.onSelectButton(index);
    }
}
