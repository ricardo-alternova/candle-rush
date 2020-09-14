// GENERATED AUTOMATICALLY FROM 'Assets/GJam2020/Scripts/Core/Input/UiInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @UiInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @UiInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UiInput"",
    ""maps"": [
        {
            ""name"": ""Ui"",
            ""id"": ""073806bd-935a-4ad3-afcc-605bf69308b7"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""d55de0b9-60c6-4174-8c7f-55a3e9c0b0ed"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""9082f92e-c8dc-4626-b2b1-a7ecde12f0cb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""f4203901-01a1-4230-8f70-b78c73c22ad8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""5c116220-b432-4c88-b4f4-ea9c6978da66"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""efb132ab-799b-4512-80d9-af61f420cae1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70ea1280-1397-4288-9fea-95b798830a74"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f685632b-3769-464a-8bc6-58fd19bbe97a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c24d5f9e-da01-490b-92e8-7a08c82e37fa"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10f30a14-5b79-4656-9975-faa219d9cb78"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""856efa32-b97e-4919-9a7c-8a7157f2be23"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""954b0d5a-7f07-40c5-8263-cd8f5f4f971b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7374ca99-f7d0-40c3-95da-aed83fbc4df0"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ui
        m_Ui = asset.FindActionMap("Ui", throwIfNotFound: true);
        m_Ui_Submit = m_Ui.FindAction("Submit", throwIfNotFound: true);
        m_Ui_Start = m_Ui.FindAction("Start", throwIfNotFound: true);
        m_Ui_Back = m_Ui.FindAction("Back", throwIfNotFound: true);
        m_Ui_Right = m_Ui.FindAction("Right", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Ui
    private readonly InputActionMap m_Ui;
    private IUiActions m_UiActionsCallbackInterface;
    private readonly InputAction m_Ui_Submit;
    private readonly InputAction m_Ui_Start;
    private readonly InputAction m_Ui_Back;
    private readonly InputAction m_Ui_Right;
    public struct UiActions
    {
        private @UiInput m_Wrapper;
        public UiActions(@UiInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_Ui_Submit;
        public InputAction @Start => m_Wrapper.m_Ui_Start;
        public InputAction @Back => m_Wrapper.m_Ui_Back;
        public InputAction @Right => m_Wrapper.m_Ui_Right;
        public InputActionMap Get() { return m_Wrapper.m_Ui; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiActions set) { return set.Get(); }
        public void SetCallbacks(IUiActions instance)
        {
            if (m_Wrapper.m_UiActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_UiActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnSubmit;
                @Start.started -= m_Wrapper.m_UiActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnStart;
                @Back.started -= m_Wrapper.m_UiActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnBack;
                @Right.started -= m_Wrapper.m_UiActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_UiActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public UiActions @Ui => new UiActions(this);
    public interface IUiActions
    {
        void OnSubmit(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
