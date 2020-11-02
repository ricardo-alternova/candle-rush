using GJam2020.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Button))]
public class InputButton : MonoBehaviour
{
    public InputType type;
    public enum InputType
    {
        Submit,
        Start,
        Back,
        Up,
        Down,
        Right,
        Left
    }
    
    private UIInputInjecter inputActions;
    private bool Asigned=false;
    private Button button;
    private InputAction inputAction;

    private void Start()
    {
        inputActions = GameManager.Get.inputActions;
        inputActions.CreateNewUiInput();
        button = GetComponent<Button>();
        switch (type)
        {
            case InputType.Submit:
                inputAction = inputActions.GetSubmit();
                break;
            case InputType.Start:
                inputAction = inputActions.GetStart();
                break;
            case InputType.Back:
                inputAction = inputActions.GetBack();
                break;
            case InputType.Up:
                inputAction = inputActions.GetUp();
                break;
            case InputType.Down:
                inputAction = inputActions.GetDown();
                break;
            case InputType.Left:
                inputAction = inputActions.GetLeft();
                break;
            case InputType.Right:
                inputAction = inputActions.GetRight();
                break;
        }
        inputActions.EnableInput();
        if (!Asigned)
        {
            inputAction.started += Action;
            Asigned = true;
        }
    }

    public void Enable()
    {
        StartCoroutine(IEOnEnable());
    }

    private void OnEnable()
    {
        Enable();
    }

    private void OnDisable()
    {
        Debug.Log(name);
        inputAction.started -= Action;
        Asigned = false;
    }

    private void Action(CallbackContext obj)
    {
        button.SendMessage("Press", true);
    }

    private IEnumerator IEOnEnable()
    {
        yield return new WaitForSecondsRealtime(.2f);

        if (inputAction != null && !Asigned)
        {
            inputAction.started += Action;
            Asigned = true;
        }
    }
    
}
