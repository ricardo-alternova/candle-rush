using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Button))]
public class InputButton : MonoBehaviour
{
    public bool DisableOnClick = false;
    private bool Asigned=false;
    public enum InputType
    {
        Submit,
        Start,
        Back,
        Up,
        Down,
        Left,
        Right
    }
    [SerializeField]
    private UiInput inputActions;

    private InputAction inputAction;    
    private Button button;

    public InputType type;
    private void Start()
    {
        inputActions = new UiInput();
        button = GetComponent<Button>();
        switch (type)
        {
            case InputType.Submit:
                inputAction = inputActions.Ui.Submit;
                break;
            case InputType.Start:
                inputAction = inputActions.Ui.Start;
                break;
            case InputType.Back:
                inputAction = inputActions.Ui.Back;
                break;
            case InputType.Up:
                inputAction = inputActions.Ui.Submit;
                break;
            case InputType.Down:
                inputAction = inputActions.Ui.Submit;
                break;
            case InputType.Left:
                inputAction = inputActions.Ui.Submit;
                break;
            case InputType.Right:
                inputAction = inputActions.Ui.Right;
                break;
        }
        inputActions.Enable();
        if (!Asigned)
        {
            inputAction.started += Action;
            Asigned = true;
        }
    }

    private void Action(CallbackContext obj)
    {
        if (button.GetComponent<RectTransform>().IsFullyVisibleFrom(Camera.main)){
            button.SendMessage("Press", true);
            inputAction.started -= Action;
            Asigned = false;
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
