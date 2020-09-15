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
                    ""name"": ""Right(RS)"",
                    ""type"": ""Button"",
                    ""id"": ""5c116220-b432-4c88-b4f4-ea9c6978da66"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left(RS)"",
                    ""type"": ""Button"",
                    ""id"": ""e8c2c309-9710-40f2-a81b-3910d8895bd2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UP(RS)"",
                    ""type"": ""Button"",
                    ""id"": ""9acd12e9-ac4e-4618-ab6c-9b6b25f2f198"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down(RS)"",
                    ""type"": ""Button"",
                    ""id"": ""e9c93cee-799e-42b2-9bad-6f63c212e94a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RB"",
                    ""type"": ""Button"",
                    ""id"": ""2c6a9a91-0832-47a6-b1d0-2e83d0484b45"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LB"",
                    ""type"": ""Button"",
                    ""id"": ""7a62a781-1ebb-45d2-bb71-5b08d9dd58a8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right(LS)"",
                    ""type"": ""Button"",
                    ""id"": ""be881ea0-30b7-46a7-a3cf-7ace9ba1d4c4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left(LS)"",
                    ""type"": ""Button"",
                    ""id"": ""6091dff6-340b-4597-a3ef-f3eff30e2702"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up(LS)"",
                    ""type"": ""Button"",
                    ""id"": ""e6977f7e-a560-4fec-9571-c3feced84318"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down(LS)"",
                    ""type"": ""Button"",
                    ""id"": ""143f5249-ee4a-46fe-971a-5adf4f2665ce"",
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
                    ""action"": ""Right(RS)"",
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
                    ""action"": ""Right(RS)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f2efdfd-dcc5-425a-b807-7277cc177b7a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left(RS)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""064f1eb8-11e6-4435-9596-774cebf742e2"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left(RS)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01af0702-3c21-44ca-9b56-8db48d89f06d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP(RS)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cad3f334-f04b-492e-974b-a778a1647740"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP(RS)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64814087-ab16-405e-8300-3c3487b5b8bb"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down(RS)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0d6ac54-ee53-42ae-8320-ca98478c4f2f"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down(RS)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af9f8ee5-3ca3-4c83-b99a-29e79959d4de"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6aa3fe6e-7b5b-4f7b-95aa-b3ca30572f1a"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dbf1334-9ab7-4272-8b08-92c6e96a41a1"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right(LS)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f876dc5-5e9f-490b-9722-06a629c354fb"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left(LS)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30c0e4c5-a7f0-4bb8-a7ae-ba66c384ac68"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up(LS)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bcec71e-93d1-4d6c-9210-fc1b3a72a199"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down(LS)"",
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
        m_Ui_RightRS = m_Ui.FindAction("Right(RS)", throwIfNotFound: true);
        m_Ui_LeftRS = m_Ui.FindAction("Left(RS)", throwIfNotFound: true);
        m_Ui_UPRS = m_Ui.FindAction("UP(RS)", throwIfNotFound: true);
        m_Ui_DownRS = m_Ui.FindAction("Down(RS)", throwIfNotFound: true);
        m_Ui_RB = m_Ui.FindAction("RB", throwIfNotFound: true);
        m_Ui_LB = m_Ui.FindAction("LB", throwIfNotFound: true);
        m_Ui_RightLS = m_Ui.FindAction("Right(LS)", throwIfNotFound: true);
        m_Ui_LeftLS = m_Ui.FindAction("Left(LS)", throwIfNotFound: true);
        m_Ui_UpLS = m_Ui.FindAction("Up(LS)", throwIfNotFound: true);
        m_Ui_DownLS = m_Ui.FindAction("Down(LS)", throwIfNotFound: true);
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
    private readonly InputAction m_Ui_RightRS;
    private readonly InputAction m_Ui_LeftRS;
    private readonly InputAction m_Ui_UPRS;
    private readonly InputAction m_Ui_DownRS;
    private readonly InputAction m_Ui_RB;
    private readonly InputAction m_Ui_LB;
    private readonly InputAction m_Ui_RightLS;
    private readonly InputAction m_Ui_LeftLS;
    private readonly InputAction m_Ui_UpLS;
    private readonly InputAction m_Ui_DownLS;
    public struct UiActions
    {
        private @UiInput m_Wrapper;
        public UiActions(@UiInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_Ui_Submit;
        public InputAction @Start => m_Wrapper.m_Ui_Start;
        public InputAction @Back => m_Wrapper.m_Ui_Back;
        public InputAction @RightRS => m_Wrapper.m_Ui_RightRS;
        public InputAction @LeftRS => m_Wrapper.m_Ui_LeftRS;
        public InputAction @UPRS => m_Wrapper.m_Ui_UPRS;
        public InputAction @DownRS => m_Wrapper.m_Ui_DownRS;
        public InputAction @RB => m_Wrapper.m_Ui_RB;
        public InputAction @LB => m_Wrapper.m_Ui_LB;
        public InputAction @RightLS => m_Wrapper.m_Ui_RightLS;
        public InputAction @LeftLS => m_Wrapper.m_Ui_LeftLS;
        public InputAction @UpLS => m_Wrapper.m_Ui_UpLS;
        public InputAction @DownLS => m_Wrapper.m_Ui_DownLS;
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
                @RightRS.started -= m_Wrapper.m_UiActionsCallbackInterface.OnRightRS;
                @RightRS.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnRightRS;
                @RightRS.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnRightRS;
                @LeftRS.started -= m_Wrapper.m_UiActionsCallbackInterface.OnLeftRS;
                @LeftRS.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnLeftRS;
                @LeftRS.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnLeftRS;
                @UPRS.started -= m_Wrapper.m_UiActionsCallbackInterface.OnUPRS;
                @UPRS.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnUPRS;
                @UPRS.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnUPRS;
                @DownRS.started -= m_Wrapper.m_UiActionsCallbackInterface.OnDownRS;
                @DownRS.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnDownRS;
                @DownRS.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnDownRS;
                @RB.started -= m_Wrapper.m_UiActionsCallbackInterface.OnRB;
                @RB.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnRB;
                @RB.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnRB;
                @LB.started -= m_Wrapper.m_UiActionsCallbackInterface.OnLB;
                @LB.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnLB;
                @LB.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnLB;
                @RightLS.started -= m_Wrapper.m_UiActionsCallbackInterface.OnRightLS;
                @RightLS.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnRightLS;
                @RightLS.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnRightLS;
                @LeftLS.started -= m_Wrapper.m_UiActionsCallbackInterface.OnLeftLS;
                @LeftLS.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnLeftLS;
                @LeftLS.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnLeftLS;
                @UpLS.started -= m_Wrapper.m_UiActionsCallbackInterface.OnUpLS;
                @UpLS.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnUpLS;
                @UpLS.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnUpLS;
                @DownLS.started -= m_Wrapper.m_UiActionsCallbackInterface.OnDownLS;
                @DownLS.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnDownLS;
                @DownLS.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnDownLS;
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
                @RightRS.started += instance.OnRightRS;
                @RightRS.performed += instance.OnRightRS;
                @RightRS.canceled += instance.OnRightRS;
                @LeftRS.started += instance.OnLeftRS;
                @LeftRS.performed += instance.OnLeftRS;
                @LeftRS.canceled += instance.OnLeftRS;
                @UPRS.started += instance.OnUPRS;
                @UPRS.performed += instance.OnUPRS;
                @UPRS.canceled += instance.OnUPRS;
                @DownRS.started += instance.OnDownRS;
                @DownRS.performed += instance.OnDownRS;
                @DownRS.canceled += instance.OnDownRS;
                @RB.started += instance.OnRB;
                @RB.performed += instance.OnRB;
                @RB.canceled += instance.OnRB;
                @LB.started += instance.OnLB;
                @LB.performed += instance.OnLB;
                @LB.canceled += instance.OnLB;
                @RightLS.started += instance.OnRightLS;
                @RightLS.performed += instance.OnRightLS;
                @RightLS.canceled += instance.OnRightLS;
                @LeftLS.started += instance.OnLeftLS;
                @LeftLS.performed += instance.OnLeftLS;
                @LeftLS.canceled += instance.OnLeftLS;
                @UpLS.started += instance.OnUpLS;
                @UpLS.performed += instance.OnUpLS;
                @UpLS.canceled += instance.OnUpLS;
                @DownLS.started += instance.OnDownLS;
                @DownLS.performed += instance.OnDownLS;
                @DownLS.canceled += instance.OnDownLS;
            }
        }
    }
    public UiActions @Ui => new UiActions(this);
    public interface IUiActions
    {
        void OnSubmit(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnRightRS(InputAction.CallbackContext context);
        void OnLeftRS(InputAction.CallbackContext context);
        void OnUPRS(InputAction.CallbackContext context);
        void OnDownRS(InputAction.CallbackContext context);
        void OnRB(InputAction.CallbackContext context);
        void OnLB(InputAction.CallbackContext context);
        void OnRightLS(InputAction.CallbackContext context);
        void OnLeftLS(InputAction.CallbackContext context);
        void OnUpLS(InputAction.CallbackContext context);
        void OnDownLS(InputAction.CallbackContext context);
    }
}
