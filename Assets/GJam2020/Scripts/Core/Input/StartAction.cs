using GJam2020.Core;
using GJam2020.Level.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class StartAction : MonoBehaviour
{
    private InputAction inputAction;
    private UIInputInjecter inputActions;
    private bool Asigned = false;
    private void Awake()
    {
        inputActions = CanvasData.Get.inputActions;
        inputAction = inputActions.GetStart();
        Enable();
        
    }

    private void Action(CallbackContext obj)
    {
        LevelMenuMgr.Get().Play();
    }

    public void Enable()
    {
        if (!Asigned)
        {
            Asigned = true;
            inputAction.started += Action;
        }
    }

    private void OnEnable()
    {
        Enable();
    }

    private void OnDisable()
    {
        Asigned = false;
        inputAction.started -= Action;
        Asigned = false;
    }
}
