

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class UIInputInjecter : MonoBehaviour
{

    private AxisEventData currentAxis;
    private GameObject currentButton;
    private bool waitTime = false;
    public void Start()
    {
        CreateNewUiInput();
        GetUp().started += ActionUp;
        GetDown().started += ActionDown;
        GetLeft().started += ActionLeft;
        GetRight().started += ActionRight;
        GetSubmit().started += ActionSubmit;
    }
    private void ActionUp(CallbackContext obj)
    {
        Action(MoveDirection.Up);
    }

    private void ActionDown(CallbackContext obj)
    {
        Action(MoveDirection.Down);
    }

    private void ActionLeft(CallbackContext obj)
    {
        Action(MoveDirection.Left);
    }

    private void ActionRight(CallbackContext obj)
    {
        Action(MoveDirection.Right);
    }

    private void ActionSubmit(CallbackContext obj)
    {
        currentButton = EventSystem.current.currentSelectedGameObject;
        ExecuteEvents.Execute(currentButton, null, ExecuteEvents.submitHandler);
    }

    private IEnumerator WaitForNextAction()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        waitTime = false;
        yield return null;
    }
    private void Action(MoveDirection direction)
    {
        if (!waitTime)
        {
            waitTime = true;
            currentAxis = new AxisEventData(EventSystem.current);
            currentButton = EventSystem.current.currentSelectedGameObject;
            currentAxis.moveDir = direction;
            ExecuteEvents.Execute(currentButton, currentAxis, ExecuteEvents.moveHandler);
            StartCoroutine(WaitForNextAction());
        }
    }

    UiInput input;
    public void CreateNewUiInput()
    {
        if (input == null)
        {
            input = new UiInput();
        }
    }

    public void EnableInput()
    {
        input.Enable();
    }

    public InputAction GetLeft()
    {
        CreateNewUiInput();
#if UNITY_TVOS
        return input.UiTvOs.Left;
#elif UNITY_WEBGL
        return input.UiWebgl.Left;
#elif UNITY_ANDROID || UNITY_IPHONE
        return input.UiMobile.Left;
#else
        return input.UiWindowsEditor.Left;
#endif
    }

    public InputAction GetRight()
    {
        CreateNewUiInput();
#if UNITY_TVOS
        return input.UiTvOs.Right;
#elif UNITY_WEBGL
        return input.UiWebgl.Right;
#elif UNITY_ANDROID || UNITY_IPHONE
        return input.UiMobile.Right;
#else
        return input.UiWindowsEditor.Right;
#endif
    }

    public InputAction GetUp()
    {
        CreateNewUiInput();
#if UNITY_TVOS
        return input.UiTvOs.Up;
#elif UNITY_WEBGL
        return input.UiWebgl.UP;
#elif UNITY_ANDROID || UNITY_IPHONE
        return input.UiMobile.UP;
#else
        return input.UiWindowsEditor.UP;
#endif
    }

    public InputAction GetDown()
    {
        CreateNewUiInput();
#if UNITY_TVOS
        return input.UiTvOs.Down;
#elif UNITY_WEBGL
        return input.UiWebgl.Down;
#elif UNITY_ANDROID || UNITY_IPHONE
        return input.UiMobile.Down;
#else
        return input.UiWindowsEditor.Down;
#endif
    }

    public InputAction GetStart()
    {
        CreateNewUiInput();
#if UNITY_TVOS
        return input.UiTvOs.Start;
#elif UNITY_WEBGL
        return input.UiWebgl.Start;
#elif UNITY_ANDROID || UNITY_IPHONE
        return input.UiMobile.Start;
#else
        return input.UiWindowsEditor.Start;
#endif
    }

    public InputAction GetBack()
    {
        CreateNewUiInput();
#if UNITY_TVOS
        return input.UiTvOs.Back;
#elif UNITY_WEBGL
        return input.UiWebgl.Back;
#elif UNITY_ANDROID || UNITY_IPHONE
        return input.UiMobile.Back;
#else
        return input.UiWindowsEditor.Back;
#endif
    }

    public InputAction GetSubmit()
    {
        CreateNewUiInput();
#if UNITY_TVOS
        return input.UiTvOs.Submit;
#elif UNITY_WEBGL
        return input.UiWebgl.Submit;
#elif UNITY_ANDROID || UNITY_IPHONE
        return input.UiMobile.Submit;
#else
        return input.UiWindowsEditor.Submit;
#endif
    }

    private void OnDestroy()
    {
        GetUp().started -= ActionUp;
        GetDown().started -= ActionDown;
        GetLeft().started -= ActionLeft;
        GetRight().started -= ActionRight;
        GetSubmit().started -= ActionSubmit;
    }
}
