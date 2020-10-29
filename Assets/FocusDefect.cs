using GJam2020.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.InputSystem.InputAction;

public class FocusDefect : MonoBehaviour
{
    public GameObject goSelected;
    private UIInputInjecter inputActions;
    // Start is called before the first frame update
    void Start()
    {
        inputActions = CanvasData.Get.inputActions;
        if (goSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(goSelected);
        }
        inputActions.CreateNewUiInput();
        inputActions.EnableInput();
        OnEnable();
    }

    private void Actions(CallbackContext obj)
    {
        if (goSelected != null)
        {
            if (EventSystem.current.currentSelectedGameObject == null|| !EventSystem.current.currentSelectedGameObject.transform.IsChildOf(transform))
            {
                EventSystem.current.SetSelectedGameObject(goSelected);
            }
        }
    }
    
    private void OnEnable()
    {
        if (inputActions != null)
        {
            inputActions.GetRight().started += Actions;
            inputActions.GetLeft().started += Actions;
            inputActions.GetUp().started += Actions;
            inputActions.GetDown().started += Actions;
        }
        
    }

    private void OnDisable()
    {
        inputActions.GetRight().started -= Actions;
        inputActions.GetLeft().started -= Actions;
        inputActions.GetUp().started -= Actions;
        inputActions.GetDown().started -= Actions;
    }
}
