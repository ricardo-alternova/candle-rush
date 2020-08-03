using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private int linkIndex;
    public Action<int> TakeKey;

    private int avatarLayer;

    private void Awake()
    {
        avatarLayer = LayerMask.NameToLayer("Avatar");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != avatarLayer) return;
        TakeKey?.Invoke(linkIndex);
        Destroy(gameObject);
    }
}
