using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInputName : MonoBehaviour
{
    [SerializeField]
    private InputTesting inputActions;
    public Text buttonPressed;

    private void Awake()
    {
        //ButtonCalled("Texto");
        inputActions = new InputTesting();

        inputActions.GamePad.LeftStick.started += moveAction =>
        {

            ButtonCalled("LeftStick" + moveAction.ReadValue<Vector2>().ToString());
        };

        inputActions.GamePad.East.started += moveAction =>
        {
            ButtonCalled("East");
        };

        inputActions.GamePad.North.started+= moveAction =>
        {
            ButtonCalled("North");
        };

        inputActions.GamePad.West.started += moveAction =>
        {
            ButtonCalled("West");
        };

        inputActions.GamePad.South.started += moveAction =>
        {
            ButtonCalled("South");
        };

        inputActions.GamePad.Dpad.started += moveAction =>
        {

            ButtonCalled("Dpad" + moveAction.ReadValue<Vector2>().ToString());
        };

        inputActions.GamePad.LeftStick.started += moveAction =>
        {
            ButtonCalled("LeftStick" + moveAction.ReadValue<Vector2>().ToString());
        };

        inputActions.GamePad.RightStick.started += moveAction =>
        {
            ButtonCalled("RightStick" + moveAction.ReadValue<Vector2>().ToString());
        };

        inputActions.GamePad.LeftShoulder.started += moveAction =>
        {
            ButtonCalled("LeftShoulder");
        };

        inputActions.GamePad.RightShoulder.started += moveAction =>
        {
            ButtonCalled("RightShoulder");
        };

        //inputActions.GamePad.LeftStick.started += moveAction =>
        //{
        //    ButtonCalled("LeftStick");
        //};

        //inputActions.GamePad.RightStick.started += moveAction =>
        //{
        //    ButtonCalled("RightStick");
        //};

        inputActions.GamePad.RightTrigger.started += moveAction =>
        {
            ButtonCalled("RightTrigger");
        };

        inputActions.GamePad.LeftTrigger.started += moveAction =>
        {
            ButtonCalled("LeftTrigger");
        };

        inputActions.GamePad.Select.started += moveAction =>
        {
            ButtonCalled("Select");
        };

        inputActions.GamePad.Start.started += moveAction =>
        {
            ButtonCalled("Start");
        };

        inputActions.GamePad.LeftTriggerButton.started += moveAction =>
        {
            ButtonCalled("LeftTriggerButton");
        };

        inputActions.GamePad.RigthTriggerButton.started += moveAction =>
        {
            ButtonCalled("RightTriggerButton");
        };

        inputActions.GamePad.TouchPadButton.started += moveAction =>
        {
            ButtonCalled("TouchPadButton");
        };

        inputActions.GamePad.SystemButton.started += moveAction =>
        {
            ButtonCalled("SystemButton");
        };

        inputActions.TouchScreen.PrimaryTouch.started += moveAction =>
        {
            ButtonCalled("PrimaryTouch" + moveAction.ReadValue<Vector2>().ToString());
        };

        inputActions.TouchScreen.SecondTouch.started += moveAction =>
        {
            ButtonCalled("SecondTouch" + moveAction.ReadValue<Vector2>().ToString());
        };

        inputActions.TouchScreen.PressTouch.started += moveAction =>
        {
            ButtonCalled("PressTouch");
        };

        inputActions.TouchScreen.PressPrimary.started += moveAction =>
        {
            ButtonCalled("PressPrimary");
        };

        inputActions.Enable();
    }

    private void ButtonCalled(string name)
    {
        buttonPressed.text = name;
    }
}
