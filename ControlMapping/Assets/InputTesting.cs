// GENERATED AUTOMATICALLY FROM 'Assets/InputTesting.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputTesting : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputTesting()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputTesting"",
    ""maps"": [
        {
            ""name"": ""GamePad"",
            ""id"": ""9113be68-ac45-4d34-bf44-3fee2e65340b"",
            ""actions"": [
                {
                    ""name"": ""East"",
                    ""type"": ""Button"",
                    ""id"": ""ea82370d-da2d-461f-9795-9e47311c66ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""North"",
                    ""type"": ""Button"",
                    ""id"": ""cfede22b-22d5-4aba-b382-ab72c89501e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""South"",
                    ""type"": ""Button"",
                    ""id"": ""7bf2c93f-f365-40a5-92c2-cc4057ea07d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""West"",
                    ""type"": ""Button"",
                    ""id"": ""9b2451d8-1fe2-4cec-90bd-c58a389cc25e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dpad"",
                    ""type"": ""Button"",
                    ""id"": ""18370729-676c-4abe-9e38-298821176720"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DpadOnClick"",
                    ""type"": ""Button"",
                    ""id"": ""6d3d2fc4-27cc-4cc6-bd44-bdc3b1fc2a33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Button"",
                    ""id"": ""ee5f4cb0-aeab-4794-90d9-26b7876a9ab1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStick"",
                    ""type"": ""Button"",
                    ""id"": ""13ed4539-aa35-4d3f-bf53-91dd6aae3512"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftShoulder"",
                    ""type"": ""Button"",
                    ""id"": ""11384f42-7db7-476a-a796-f835d52dbcde"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightShoulder"",
                    ""type"": ""Button"",
                    ""id"": ""c5de8b44-e3ea-42e0-a4f3-f18dc1901b1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftStickPress"",
                    ""type"": ""Button"",
                    ""id"": ""11739cfb-d560-4baf-96f5-7b5951ba77d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStickPress"",
                    ""type"": ""Button"",
                    ""id"": ""243ca09c-dd8c-4d57-abe9-a98fdef5ab53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""66c3e486-c7b1-49cc-89b2-4ca8b9797b89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""9b1c3898-2987-415b-a6a2-1693e194e807"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""d195b0e8-10a5-4229-9be6-b0060f2a0bb0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""86272de1-1e9c-4cbd-93a9-0deaacfc6585"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTriggerButton"",
                    ""type"": ""Button"",
                    ""id"": ""9c7196b7-9ef8-4910-94a5-51194ab2ffbb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RigthTriggerButton"",
                    ""type"": ""Button"",
                    ""id"": ""0b74317e-e89e-434b-8a80-6b7aa9105931"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPadButton"",
                    ""type"": ""Button"",
                    ""id"": ""89407d21-2dc5-4711-a8a9-28c6462df325"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SystemButton"",
                    ""type"": ""Button"",
                    ""id"": ""2d24ef6b-f673-4832-9d12-2f51d078041b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""adbda444-02f5-4cdb-90f3-31919873f5e9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""faeaaab5-ef6e-44a5-b106-74ff583af160"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""377dc3e1-ca0f-4884-953f-b6c350d4428b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2acb08cf-bf71-42df-bcca-eb24ee192e85"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e58bfb7e-213c-4d38-ae86-4ddfb08735f5"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dpad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a97320c3-2a76-40ba-99df-1129cc72d79c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""512f17cc-8567-40aa-ad1e-a4cab15d08a4"",
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
                    ""id"": ""e77b9dcf-d241-4ebd-a33d-4c810f5d2a32"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a18836f6-4b6d-4c9b-a429-cc9e87153c01"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b4a5c35-0efa-44df-94d8-bb3bc96500e1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""7388a105-f541-45c3-a3b4-6d49254ef830"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DpadOnClick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""73c97e07-7fcb-4c9a-a620-4e675369c2be"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DpadOnClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8814e7a0-600d-445f-bf48-f4da4726cbcd"",
                    ""path"": ""<Gamepad>/dpad/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DpadOnClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""72a97fed-81a7-4c57-be44-e1bfa31e1ad5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1a739f3c-ee04-4e69-b20a-f293b5335fb5"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e20a7728-34ed-4c03-8266-31ee16b5cf87"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5afe4f3f-f8dc-4d0c-9d1c-b2a29dd38066"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""07c48ba5-0488-4b28-b56f-2a2ee9e6706f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b8287e36-f840-4971-b2f5-8023f1aaaee0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""030d83da-84d0-4424-929f-d18ac370bba0"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""30f4eead-ad3c-4ef4-896f-4cea28457b63"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4706a022-d8d2-4210-b3c0-1e7381674c11"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7e18c9ad-8483-4108-8147-efbd8842e873"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""147a941a-c6a5-41e4-a109-d8078690f42e"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1181865-8f39-4a4f-bc08-67ad753d3f54"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""435909c7-9be3-4e87-b631-e5394dafd495"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStickPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d282e097-6262-430d-a777-ef2a2eaf90f3"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStickPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e9e3957-b841-4aba-b48e-8abcbd136acd"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0322274-e658-4691-a24b-c116247dec81"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5577691d-cce1-411e-b906-50dea201f4b5"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fde416e7-5053-433d-810a-a56cf8b1f3a8"",
                    ""path"": ""<Gamepad>/leftTriggerButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTriggerButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7139eb5b-1e00-483b-997f-efc22fa9592a"",
                    ""path"": ""<Gamepad>/rightTriggerButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RigthTriggerButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecf41f18-b900-40cb-96b5-8fad293dac31"",
                    ""path"": ""<Gamepad>/touchpadButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPadButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f40f0fb-2249-4b0b-84aa-7d18c9849996"",
                    ""path"": ""<Gamepad>/systemButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SystemButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TouchScreen"",
            ""id"": ""ccb7246f-4f77-495b-91c3-331109c1b273"",
            ""actions"": [
                {
                    ""name"": ""PrimaryTouch"",
                    ""type"": ""Button"",
                    ""id"": ""03429497-d619-445c-ac54-59b1b7f6094d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Second Touch"",
                    ""type"": ""Button"",
                    ""id"": ""625526f2-406f-4171-a464-9e3a8052b814"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressTouch"",
                    ""type"": ""Button"",
                    ""id"": ""89f2bf03-836e-492f-a3d8-f3a87a079e47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressPrimary"",
                    ""type"": ""Button"",
                    ""id"": ""6fdf31c9-3004-40d5-b71d-228f49022b87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8b744b56-7000-4b5b-ae0a-dcf8fa82b39b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3e215039-9529-48c6-936c-39a597bfa04a"",
                    ""path"": ""<Touchscreen>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4d034743-0c0f-4731-8b72-8c7204c92eb4"",
                    ""path"": ""<Touchscreen>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""418a4e96-d2c1-4fcd-9d78-f385f10b7f64"",
                    ""path"": ""<Touchscreen>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4c952984-bf72-4021-8814-cfe3731daeb5"",
                    ""path"": ""<Touchscreen>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2ba4c372-d7ac-4fdb-9e33-4b0caca9d689"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Second Touch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4c5e38ab-e66c-42d4-aaea-0e823d08a356"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Second Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8f8bd5a5-19f8-4114-b976-24b0189000c4"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Second Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""90efaef4-5c93-469a-b6f5-a871a8250e35"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Second Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f0d12f60-48da-4e2e-87de-8185c49c26c9"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Second Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b96ae882-0cb7-4f15-8175-6b554a85f380"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5610d51-bbae-4146-a883-ad1fd3b56a1e"",
                    ""path"": ""<Touchscreen>/touch0/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressPrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePad
        m_GamePad = asset.FindActionMap("GamePad", throwIfNotFound: true);
        m_GamePad_East = m_GamePad.FindAction("East", throwIfNotFound: true);
        m_GamePad_North = m_GamePad.FindAction("North", throwIfNotFound: true);
        m_GamePad_South = m_GamePad.FindAction("South", throwIfNotFound: true);
        m_GamePad_West = m_GamePad.FindAction("West", throwIfNotFound: true);
        m_GamePad_Dpad = m_GamePad.FindAction("Dpad", throwIfNotFound: true);
        m_GamePad_DpadOnClick = m_GamePad.FindAction("DpadOnClick", throwIfNotFound: true);
        m_GamePad_LeftStick = m_GamePad.FindAction("LeftStick", throwIfNotFound: true);
        m_GamePad_RightStick = m_GamePad.FindAction("RightStick", throwIfNotFound: true);
        m_GamePad_LeftShoulder = m_GamePad.FindAction("LeftShoulder", throwIfNotFound: true);
        m_GamePad_RightShoulder = m_GamePad.FindAction("RightShoulder", throwIfNotFound: true);
        m_GamePad_LeftStickPress = m_GamePad.FindAction("LeftStickPress", throwIfNotFound: true);
        m_GamePad_RightStickPress = m_GamePad.FindAction("RightStickPress", throwIfNotFound: true);
        m_GamePad_RightTrigger = m_GamePad.FindAction("RightTrigger", throwIfNotFound: true);
        m_GamePad_LeftTrigger = m_GamePad.FindAction("LeftTrigger", throwIfNotFound: true);
        m_GamePad_Select = m_GamePad.FindAction("Select", throwIfNotFound: true);
        m_GamePad_Start = m_GamePad.FindAction("Start", throwIfNotFound: true);
        m_GamePad_LeftTriggerButton = m_GamePad.FindAction("LeftTriggerButton", throwIfNotFound: true);
        m_GamePad_RigthTriggerButton = m_GamePad.FindAction("RigthTriggerButton", throwIfNotFound: true);
        m_GamePad_TouchPadButton = m_GamePad.FindAction("TouchPadButton", throwIfNotFound: true);
        m_GamePad_SystemButton = m_GamePad.FindAction("SystemButton", throwIfNotFound: true);
        // TouchScreen
        m_TouchScreen = asset.FindActionMap("TouchScreen", throwIfNotFound: true);
        m_TouchScreen_PrimaryTouch = m_TouchScreen.FindAction("PrimaryTouch", throwIfNotFound: true);
        m_TouchScreen_SecondTouch = m_TouchScreen.FindAction("Second Touch", throwIfNotFound: true);
        m_TouchScreen_PressTouch = m_TouchScreen.FindAction("PressTouch", throwIfNotFound: true);
        m_TouchScreen_PressPrimary = m_TouchScreen.FindAction("PressPrimary", throwIfNotFound: true);
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

    // GamePad
    private readonly InputActionMap m_GamePad;
    private IGamePadActions m_GamePadActionsCallbackInterface;
    private readonly InputAction m_GamePad_East;
    private readonly InputAction m_GamePad_North;
    private readonly InputAction m_GamePad_South;
    private readonly InputAction m_GamePad_West;
    private readonly InputAction m_GamePad_Dpad;
    private readonly InputAction m_GamePad_DpadOnClick;
    private readonly InputAction m_GamePad_LeftStick;
    private readonly InputAction m_GamePad_RightStick;
    private readonly InputAction m_GamePad_LeftShoulder;
    private readonly InputAction m_GamePad_RightShoulder;
    private readonly InputAction m_GamePad_LeftStickPress;
    private readonly InputAction m_GamePad_RightStickPress;
    private readonly InputAction m_GamePad_RightTrigger;
    private readonly InputAction m_GamePad_LeftTrigger;
    private readonly InputAction m_GamePad_Select;
    private readonly InputAction m_GamePad_Start;
    private readonly InputAction m_GamePad_LeftTriggerButton;
    private readonly InputAction m_GamePad_RigthTriggerButton;
    private readonly InputAction m_GamePad_TouchPadButton;
    private readonly InputAction m_GamePad_SystemButton;
    public struct GamePadActions
    {
        private @InputTesting m_Wrapper;
        public GamePadActions(@InputTesting wrapper) { m_Wrapper = wrapper; }
        public InputAction @East => m_Wrapper.m_GamePad_East;
        public InputAction @North => m_Wrapper.m_GamePad_North;
        public InputAction @South => m_Wrapper.m_GamePad_South;
        public InputAction @West => m_Wrapper.m_GamePad_West;
        public InputAction @Dpad => m_Wrapper.m_GamePad_Dpad;
        public InputAction @DpadOnClick => m_Wrapper.m_GamePad_DpadOnClick;
        public InputAction @LeftStick => m_Wrapper.m_GamePad_LeftStick;
        public InputAction @RightStick => m_Wrapper.m_GamePad_RightStick;
        public InputAction @LeftShoulder => m_Wrapper.m_GamePad_LeftShoulder;
        public InputAction @RightShoulder => m_Wrapper.m_GamePad_RightShoulder;
        public InputAction @LeftStickPress => m_Wrapper.m_GamePad_LeftStickPress;
        public InputAction @RightStickPress => m_Wrapper.m_GamePad_RightStickPress;
        public InputAction @RightTrigger => m_Wrapper.m_GamePad_RightTrigger;
        public InputAction @LeftTrigger => m_Wrapper.m_GamePad_LeftTrigger;
        public InputAction @Select => m_Wrapper.m_GamePad_Select;
        public InputAction @Start => m_Wrapper.m_GamePad_Start;
        public InputAction @LeftTriggerButton => m_Wrapper.m_GamePad_LeftTriggerButton;
        public InputAction @RigthTriggerButton => m_Wrapper.m_GamePad_RigthTriggerButton;
        public InputAction @TouchPadButton => m_Wrapper.m_GamePad_TouchPadButton;
        public InputAction @SystemButton => m_Wrapper.m_GamePad_SystemButton;
        public InputActionMap Get() { return m_Wrapper.m_GamePad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePadActions set) { return set.Get(); }
        public void SetCallbacks(IGamePadActions instance)
        {
            if (m_Wrapper.m_GamePadActionsCallbackInterface != null)
            {
                @East.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnEast;
                @East.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnEast;
                @East.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnEast;
                @North.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnNorth;
                @North.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnNorth;
                @North.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnNorth;
                @South.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnSouth;
                @South.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnSouth;
                @South.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnSouth;
                @West.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnWest;
                @West.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnWest;
                @West.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnWest;
                @Dpad.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnDpad;
                @Dpad.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnDpad;
                @Dpad.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnDpad;
                @DpadOnClick.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnDpadOnClick;
                @DpadOnClick.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnDpadOnClick;
                @DpadOnClick.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnDpadOnClick;
                @LeftStick.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftStick;
                @RightStick.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightStick;
                @RightStick.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightStick;
                @RightStick.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightStick;
                @LeftShoulder.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftShoulder;
                @LeftShoulder.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftShoulder;
                @LeftShoulder.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftShoulder;
                @RightShoulder.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightShoulder;
                @RightShoulder.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightShoulder;
                @RightShoulder.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightShoulder;
                @LeftStickPress.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftStickPress;
                @LeftStickPress.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftStickPress;
                @LeftStickPress.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftStickPress;
                @RightStickPress.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightStickPress;
                @RightStickPress.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightStickPress;
                @RightStickPress.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightStickPress;
                @RightTrigger.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRightTrigger;
                @LeftTrigger.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftTrigger;
                @Select.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnSelect;
                @Start.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnStart;
                @LeftTriggerButton.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftTriggerButton;
                @LeftTriggerButton.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftTriggerButton;
                @LeftTriggerButton.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnLeftTriggerButton;
                @RigthTriggerButton.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRigthTriggerButton;
                @RigthTriggerButton.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRigthTriggerButton;
                @RigthTriggerButton.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnRigthTriggerButton;
                @TouchPadButton.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnTouchPadButton;
                @TouchPadButton.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnTouchPadButton;
                @TouchPadButton.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnTouchPadButton;
                @SystemButton.started -= m_Wrapper.m_GamePadActionsCallbackInterface.OnSystemButton;
                @SystemButton.performed -= m_Wrapper.m_GamePadActionsCallbackInterface.OnSystemButton;
                @SystemButton.canceled -= m_Wrapper.m_GamePadActionsCallbackInterface.OnSystemButton;
            }
            m_Wrapper.m_GamePadActionsCallbackInterface = instance;
            if (instance != null)
            {
                @East.started += instance.OnEast;
                @East.performed += instance.OnEast;
                @East.canceled += instance.OnEast;
                @North.started += instance.OnNorth;
                @North.performed += instance.OnNorth;
                @North.canceled += instance.OnNorth;
                @South.started += instance.OnSouth;
                @South.performed += instance.OnSouth;
                @South.canceled += instance.OnSouth;
                @West.started += instance.OnWest;
                @West.performed += instance.OnWest;
                @West.canceled += instance.OnWest;
                @Dpad.started += instance.OnDpad;
                @Dpad.performed += instance.OnDpad;
                @Dpad.canceled += instance.OnDpad;
                @DpadOnClick.started += instance.OnDpadOnClick;
                @DpadOnClick.performed += instance.OnDpadOnClick;
                @DpadOnClick.canceled += instance.OnDpadOnClick;
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
                @RightStick.started += instance.OnRightStick;
                @RightStick.performed += instance.OnRightStick;
                @RightStick.canceled += instance.OnRightStick;
                @LeftShoulder.started += instance.OnLeftShoulder;
                @LeftShoulder.performed += instance.OnLeftShoulder;
                @LeftShoulder.canceled += instance.OnLeftShoulder;
                @RightShoulder.started += instance.OnRightShoulder;
                @RightShoulder.performed += instance.OnRightShoulder;
                @RightShoulder.canceled += instance.OnRightShoulder;
                @LeftStickPress.started += instance.OnLeftStickPress;
                @LeftStickPress.performed += instance.OnLeftStickPress;
                @LeftStickPress.canceled += instance.OnLeftStickPress;
                @RightStickPress.started += instance.OnRightStickPress;
                @RightStickPress.performed += instance.OnRightStickPress;
                @RightStickPress.canceled += instance.OnRightStickPress;
                @RightTrigger.started += instance.OnRightTrigger;
                @RightTrigger.performed += instance.OnRightTrigger;
                @RightTrigger.canceled += instance.OnRightTrigger;
                @LeftTrigger.started += instance.OnLeftTrigger;
                @LeftTrigger.performed += instance.OnLeftTrigger;
                @LeftTrigger.canceled += instance.OnLeftTrigger;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @LeftTriggerButton.started += instance.OnLeftTriggerButton;
                @LeftTriggerButton.performed += instance.OnLeftTriggerButton;
                @LeftTriggerButton.canceled += instance.OnLeftTriggerButton;
                @RigthTriggerButton.started += instance.OnRigthTriggerButton;
                @RigthTriggerButton.performed += instance.OnRigthTriggerButton;
                @RigthTriggerButton.canceled += instance.OnRigthTriggerButton;
                @TouchPadButton.started += instance.OnTouchPadButton;
                @TouchPadButton.performed += instance.OnTouchPadButton;
                @TouchPadButton.canceled += instance.OnTouchPadButton;
                @SystemButton.started += instance.OnSystemButton;
                @SystemButton.performed += instance.OnSystemButton;
                @SystemButton.canceled += instance.OnSystemButton;
            }
        }
    }
    public GamePadActions @GamePad => new GamePadActions(this);

    // TouchScreen
    private readonly InputActionMap m_TouchScreen;
    private ITouchScreenActions m_TouchScreenActionsCallbackInterface;
    private readonly InputAction m_TouchScreen_PrimaryTouch;
    private readonly InputAction m_TouchScreen_SecondTouch;
    private readonly InputAction m_TouchScreen_PressTouch;
    private readonly InputAction m_TouchScreen_PressPrimary;
    public struct TouchScreenActions
    {
        private @InputTesting m_Wrapper;
        public TouchScreenActions(@InputTesting wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryTouch => m_Wrapper.m_TouchScreen_PrimaryTouch;
        public InputAction @SecondTouch => m_Wrapper.m_TouchScreen_SecondTouch;
        public InputAction @PressTouch => m_Wrapper.m_TouchScreen_PressTouch;
        public InputAction @PressPrimary => m_Wrapper.m_TouchScreen_PressPrimary;
        public InputActionMap Get() { return m_Wrapper.m_TouchScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchScreenActions set) { return set.Get(); }
        public void SetCallbacks(ITouchScreenActions instance)
        {
            if (m_Wrapper.m_TouchScreenActionsCallbackInterface != null)
            {
                @PrimaryTouch.started -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.performed -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.canceled -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPrimaryTouch;
                @SecondTouch.started -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnSecondTouch;
                @SecondTouch.performed -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnSecondTouch;
                @SecondTouch.canceled -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnSecondTouch;
                @PressTouch.started -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressTouch;
                @PressTouch.performed -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressTouch;
                @PressTouch.canceled -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressTouch;
                @PressPrimary.started -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressPrimary;
                @PressPrimary.performed -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressPrimary;
                @PressPrimary.canceled -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressPrimary;
            }
            m_Wrapper.m_TouchScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryTouch.started += instance.OnPrimaryTouch;
                @PrimaryTouch.performed += instance.OnPrimaryTouch;
                @PrimaryTouch.canceled += instance.OnPrimaryTouch;
                @SecondTouch.started += instance.OnSecondTouch;
                @SecondTouch.performed += instance.OnSecondTouch;
                @SecondTouch.canceled += instance.OnSecondTouch;
                @PressTouch.started += instance.OnPressTouch;
                @PressTouch.performed += instance.OnPressTouch;
                @PressTouch.canceled += instance.OnPressTouch;
                @PressPrimary.started += instance.OnPressPrimary;
                @PressPrimary.performed += instance.OnPressPrimary;
                @PressPrimary.canceled += instance.OnPressPrimary;
            }
        }
    }
    public TouchScreenActions @TouchScreen => new TouchScreenActions(this);
    public interface IGamePadActions
    {
        void OnEast(InputAction.CallbackContext context);
        void OnNorth(InputAction.CallbackContext context);
        void OnSouth(InputAction.CallbackContext context);
        void OnWest(InputAction.CallbackContext context);
        void OnDpad(InputAction.CallbackContext context);
        void OnDpadOnClick(InputAction.CallbackContext context);
        void OnLeftStick(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
        void OnLeftShoulder(InputAction.CallbackContext context);
        void OnRightShoulder(InputAction.CallbackContext context);
        void OnLeftStickPress(InputAction.CallbackContext context);
        void OnRightStickPress(InputAction.CallbackContext context);
        void OnRightTrigger(InputAction.CallbackContext context);
        void OnLeftTrigger(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnLeftTriggerButton(InputAction.CallbackContext context);
        void OnRigthTriggerButton(InputAction.CallbackContext context);
        void OnTouchPadButton(InputAction.CallbackContext context);
        void OnSystemButton(InputAction.CallbackContext context);
    }
    public interface ITouchScreenActions
    {
        void OnPrimaryTouch(InputAction.CallbackContext context);
        void OnSecondTouch(InputAction.CallbackContext context);
        void OnPressTouch(InputAction.CallbackContext context);
        void OnPressPrimary(InputAction.CallbackContext context);
    }
}
