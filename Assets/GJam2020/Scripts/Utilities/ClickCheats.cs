using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickCheats : MonoBehaviour
{
    public UnityEvent OnCheatCalled;

    [SerializeField]
    private float clickEvery = 0.3f;
    [SerializeField]
    private int clicksToStart = 4;

    private float lastClick = 0;
    private int clickCounter;

    private void Start()
    {
    }

    public void ClickButton()
    {
        if (lastClick == 0)
            lastClick = Time.time;
        if(Time.time - lastClick <= clickEvery)
        {
            clickCounter++;
            lastClick = Time.time;
            if(clickCounter >= clicksToStart)
            {
                OnCheatCalled.Invoke();
                //Debug.Log("CC: " + actions.Count);
                //if (actions.Count > clickCounter - clicksToStart)
                //{
                //    Debug.Log("Calling cheat");
                //    actions[clickCounter - clicksToStart].Invoke();
                //}
            }
        }
        else
        {
            clickCounter = 1;
            lastClick = Time.time;
        }

    }
}
