using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasData : MonoBehaviour
{
    public Text NumberOfPieces;
    public GameObject panelDead;

    public static CanvasData Get;

    private void Awake()
    {
        Get = this;
    }

    public void SetNumberOfPieces(int pieces)
    {
        NumberOfPieces.text = pieces + "";
    }

    public void Dead()
    {
        panelDead.SetActive(true);
    }

    public void Restore()
    {
        panelDead.SetActive(false);
    }
}
