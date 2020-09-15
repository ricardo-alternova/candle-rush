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
        UpRs,
        DownRs,
        LeftRs,
        RightRs,
        RB,
        LB
    }

    [SerializeField]
    private UiInput inputActions;
    private bool Asigned=false;
    private Button button;
    private InputAction inputAction;

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
            case InputType.UpRs:
                inputAction = inputActions.Ui.UPRS;
                break;
            case InputType.DownRs:
                inputAction = inputActions.Ui.DownRS;
                break;
            case InputType.LeftRs:
                inputAction = inputActions.Ui.LeftRS;
                break;
            case InputType.RightRs:
                inputAction = inputActions.Ui.RightRS;
                break;
            case InputType.RB:
                inputAction = inputActions.Ui.RB;
                break;
            case InputType.LB:
                inputAction = inputActions.Ui.LB;
                break;
        }
        inputActions.Enable();
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
