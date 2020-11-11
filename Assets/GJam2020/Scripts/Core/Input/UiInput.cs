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
            ""name"": ""UiTvOs"",
            ""id"": ""38e21bc6-a367-428f-a597-ad732810f97d"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""c3254243-0297-4aee-995a-09a4e6fb39d4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""314e4d54-fed7-42e3-9d60-b6409d0a9a7b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""4ce004d6-4982-468d-a2d4-4a21d9b79749"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""bab41d6d-136a-4d82-b263-8fca8bdda826"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""0121b626-d61a-4fd8-ae4d-5a84769e8936"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""46ef7337-6a1e-4339-85f6-d9367a731c93"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""453f0795-f269-4493-8a47-dc5e2f920b00"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1a351fbf-9f43-48ff-b590-4a7737b52be0"",
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
                    ""id"": ""32c0bb86-dccc-4fbb-961c-a411465cf8d2"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef6dafee-3f85-4881-9bb7-4ce4a0bb8d02"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""120214f3-6a96-4bbf-9331-957c8c2d9d44"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f979ee2a-7b31-408e-be69-ec0cfdb5ecf3"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e95a929d-15f9-44e1-adbd-d6895c83b953"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UiWindows/Editor"",
            ""id"": ""7586a0e3-a0d2-49cb-b0d3-7f27598ce90b"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""6c635e74-d794-4375-bc29-f5b1324bc649"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""8df0a42e-af41-4fbe-acaf-6e3ed2d327e7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""c5ea6d01-90ed-43b0-8f7f-e6a54f04d5a0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""c8a2f589-1db1-4dee-b944-8075e47aaac3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""e04d4520-f8ab-46c7-9bf9-512a33fa8c92"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UP"",
                    ""type"": ""Button"",
                    ""id"": ""e8d16d36-f3fe-4e1a-9ad0-fd4467d634c4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""03c9f355-340c-483c-99ca-fdc87612c8ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eb482d29-aa5c-41dd-a09d-c9353e21afa6"",
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
                    ""id"": ""8b0dcf25-b791-4eba-a6cc-460f735fde81"",
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
                    ""id"": ""6c64d282-2f7d-464d-9ae9-befb0b732cef"",
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
                    ""id"": ""a863df1a-c446-4024-a992-49a3d8a733cb"",
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
                    ""id"": ""73daabc9-346a-4707-a009-3294c32d096c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""821de1fc-9c36-4314-b4d8-bc8a6f5f1dec"",
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
                    ""id"": ""7c650c8b-3c3b-43b6-aefd-84b60346d9bc"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7fd3615-075c-427d-bc8d-7740f056c1d6"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73777815-70f5-49cc-9857-073c4bed5550"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e3b7026-e1ce-4c58-a82f-9743d733212f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b79fcf08-7718-4ee1-9e84-7482597133d0"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95b04225-87dc-438d-ba8b-5f91e507defe"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93cd0eff-ef1c-47c2-8f74-b674795ce10f"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b16d2cb-90c7-4674-bac4-50239d516745"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6913784a-b62c-4243-8314-c14fa819e762"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc441c1e-9802-432d-9691-77fbeee45b74"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e162bb8-7540-4b37-8229-b63c5bc5898b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9eb6e1e-775f-41e9-b153-6755ddf8bfe3"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca57aa55-d727-4631-acfd-ca321660198d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bea68cf3-c024-46ae-b8a0-f6e8198d8f48"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9882f61f-3cd7-435c-9617-77bc76e96a03"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e100957-be7f-4cdb-b9c1-aab501db6488"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UiWebgl"",
            ""id"": ""48cb1d4e-fd28-4717-9231-d939b7175abf"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""e81c4a62-03a6-4806-bbc6-5ecb4c6045ec"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""7f0fe229-2463-4a6d-9faa-a3fc8adb4978"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""5de16202-aedb-4d9c-94dc-6e388ca42a54"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""a8fb4b2e-57e2-43a0-8239-ca3d011e763f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""bd48dc16-ecea-428b-9481-3cc88cb4b074"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UP"",
                    ""type"": ""Button"",
                    ""id"": ""9e1ab712-7a62-4b30-979d-ade7a0b33502"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""e779e886-3b69-4513-8525-bbfd7709cbb1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""14da6f15-07ef-43ad-81b5-db1a1a758c9e"",
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
                    ""id"": ""243db3e7-953c-449c-a684-f15de28a4808"",
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
                    ""id"": ""4fec4583-b4eb-4cad-b996-53b30bddd15b"",
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
                    ""id"": ""2fe1c37e-bef4-4f51-9ae0-1df2fe025534"",
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
                    ""id"": ""13bdefaa-b32b-447c-aece-b4e6edc76902"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""556d4232-78f2-4fbe-bfc6-98bb3c914684"",
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
                    ""id"": ""0c9f8142-6598-40a8-a270-2665d9991935"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""656cd22f-9e8d-4299-9a74-80f0629ea0ea"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53b68c96-2d9e-47bc-bddd-60304f5e7cbd"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24a759fb-03b1-4071-ba37-29aa47c00835"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b717bfe-9f17-4534-b868-dca7dcce603c"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fa2d0b4-5722-408f-bd07-5a98e9e41ac2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bf8007c-f6d9-44ab-b5f7-fff70007369d"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7d331a8-b831-424c-9eaf-7d87f39bc145"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c438685-235b-4a19-88bc-d80385219013"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7efca18-d91d-4551-a723-f82eb6c48b45"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e68b5b62-5fcd-4844-a17c-d13b73615e8a"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""210700f3-cc0d-4646-ae80-5b82a5b99f72"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa55217c-ec57-408b-88cf-786293659a14"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d15f68a5-d03b-45b8-9b78-f88367d585d5"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55872a00-9752-4c08-9dd1-f8d7906a262a"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UiMobile"",
            ""id"": ""0ceb9c7d-ac8c-438b-87d3-e55865fdae62"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""325387b8-313a-4113-8850-70c75b149572"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""ec31400b-99d4-437c-b2dd-165d15c733b2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""590c262d-fdac-4ca4-94dd-e73289b90343"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""69229e1d-5482-4ae8-9a49-fd3e6d23e82c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""db6a74ae-7501-4a1b-88cf-a602ed159709"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UP"",
                    ""type"": ""Button"",
                    ""id"": ""bdc93f5f-b9f3-412f-8758-8f9781b50bfb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""868c8569-26cd-45db-9d34-d7dbd11a1658"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5508c57d-8bb1-4b29-9410-8449746ce566"",
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
                    ""id"": ""b01326a1-a4e0-44f5-bfcc-ce7d3cef1a4d"",
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
                    ""id"": ""f3db5768-e651-4aa0-a3e8-d881b25776f4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6df6f33e-8e3f-404c-b60c-6841e0db177c"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02874982-d49c-4928-874e-56dd82309c35"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d26e20df-41e2-49a5-a186-f2639713555a"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dae0c5bb-6541-4519-b745-dbebd269342f"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86c43e88-b300-43c0-946d-5eaa5766b6db"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85aa3c11-6fd2-46d9-a43b-203563b27971"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96a865da-6d6a-4d58-be4a-7a8e2a6f5fb4"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb38b3d3-e38c-40c1-8a9f-68aa18bc8e78"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6f30ebc-7c21-4f76-a141-885f56f5f0e7"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""093b0507-eb92-4c55-a112-1bb8f5507667"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a23282f-6fe5-4bbe-ba88-ba14244bb005"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4f1fd01-aa5d-48f2-aab6-54ecf89a52af"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // UiTvOs
        m_UiTvOs = asset.FindActionMap("UiTvOs", throwIfNotFound: true);
        m_UiTvOs_Submit = m_UiTvOs.FindAction("Submit", throwIfNotFound: true);
        m_UiTvOs_Start = m_UiTvOs.FindAction("Start", throwIfNotFound: true);
        m_UiTvOs_Right = m_UiTvOs.FindAction("Right", throwIfNotFound: true);
        m_UiTvOs_Left = m_UiTvOs.FindAction("Left", throwIfNotFound: true);
        m_UiTvOs_Up = m_UiTvOs.FindAction("Up", throwIfNotFound: true);
        m_UiTvOs_Down = m_UiTvOs.FindAction("Down", throwIfNotFound: true);
        m_UiTvOs_Back = m_UiTvOs.FindAction("Back", throwIfNotFound: true);
        // UiWindows/Editor
        m_UiWindowsEditor = asset.FindActionMap("UiWindows/Editor", throwIfNotFound: true);
        m_UiWindowsEditor_Submit = m_UiWindowsEditor.FindAction("Submit", throwIfNotFound: true);
        m_UiWindowsEditor_Start = m_UiWindowsEditor.FindAction("Start", throwIfNotFound: true);
        m_UiWindowsEditor_Back = m_UiWindowsEditor.FindAction("Back", throwIfNotFound: true);
        m_UiWindowsEditor_Right = m_UiWindowsEditor.FindAction("Right", throwIfNotFound: true);
        m_UiWindowsEditor_Left = m_UiWindowsEditor.FindAction("Left", throwIfNotFound: true);
        m_UiWindowsEditor_UP = m_UiWindowsEditor.FindAction("UP", throwIfNotFound: true);
        m_UiWindowsEditor_Down = m_UiWindowsEditor.FindAction("Down", throwIfNotFound: true);
        // UiWebgl
        m_UiWebgl = asset.FindActionMap("UiWebgl", throwIfNotFound: true);
        m_UiWebgl_Submit = m_UiWebgl.FindAction("Submit", throwIfNotFound: true);
        m_UiWebgl_Start = m_UiWebgl.FindAction("Start", throwIfNotFound: true);
        m_UiWebgl_Back = m_UiWebgl.FindAction("Back", throwIfNotFound: true);
        m_UiWebgl_Right = m_UiWebgl.FindAction("Right", throwIfNotFound: true);
        m_UiWebgl_Left = m_UiWebgl.FindAction("Left", throwIfNotFound: true);
        m_UiWebgl_UP = m_UiWebgl.FindAction("UP", throwIfNotFound: true);
        m_UiWebgl_Down = m_UiWebgl.FindAction("Down", throwIfNotFound: true);
        // UiMobile
        m_UiMobile = asset.FindActionMap("UiMobile", throwIfNotFound: true);
        m_UiMobile_Submit = m_UiMobile.FindAction("Submit", throwIfNotFound: true);
        m_UiMobile_Start = m_UiMobile.FindAction("Start", throwIfNotFound: true);
        m_UiMobile_Back = m_UiMobile.FindAction("Back", throwIfNotFound: true);
        m_UiMobile_Right = m_UiMobile.FindAction("Right", throwIfNotFound: true);
        m_UiMobile_Left = m_UiMobile.FindAction("Left", throwIfNotFound: true);
        m_UiMobile_UP = m_UiMobile.FindAction("UP", throwIfNotFound: true);
        m_UiMobile_Down = m_UiMobile.FindAction("Down", throwIfNotFound: true);
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

    // UiTvOs
    private readonly InputActionMap m_UiTvOs;
    private IUiTvOsActions m_UiTvOsActionsCallbackInterface;
    private readonly InputAction m_UiTvOs_Submit;
    private readonly InputAction m_UiTvOs_Start;
    private readonly InputAction m_UiTvOs_Right;
    private readonly InputAction m_UiTvOs_Left;
    private readonly InputAction m_UiTvOs_Up;
    private readonly InputAction m_UiTvOs_Down;
    private readonly InputAction m_UiTvOs_Back;
    public struct UiTvOsActions
    {
        private @UiInput m_Wrapper;
        public UiTvOsActions(@UiInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_UiTvOs_Submit;
        public InputAction @Start => m_Wrapper.m_UiTvOs_Start;
        public InputAction @Right => m_Wrapper.m_UiTvOs_Right;
        public InputAction @Left => m_Wrapper.m_UiTvOs_Left;
        public InputAction @Up => m_Wrapper.m_UiTvOs_Up;
        public InputAction @Down => m_Wrapper.m_UiTvOs_Down;
        public InputAction @Back => m_Wrapper.m_UiTvOs_Back;
        public InputActionMap Get() { return m_Wrapper.m_UiTvOs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiTvOsActions set) { return set.Get(); }
        public void SetCallbacks(IUiTvOsActions instance)
        {
            if (m_Wrapper.m_UiTvOsActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnSubmit;
                @Start.started -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnStart;
                @Right.started -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnLeft;
                @Up.started -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnDown;
                @Back.started -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UiTvOsActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_UiTvOsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public UiTvOsActions @UiTvOs => new UiTvOsActions(this);

    // UiWindows/Editor
    private readonly InputActionMap m_UiWindowsEditor;
    private IUiWindowsEditorActions m_UiWindowsEditorActionsCallbackInterface;
    private readonly InputAction m_UiWindowsEditor_Submit;
    private readonly InputAction m_UiWindowsEditor_Start;
    private readonly InputAction m_UiWindowsEditor_Back;
    private readonly InputAction m_UiWindowsEditor_Right;
    private readonly InputAction m_UiWindowsEditor_Left;
    private readonly InputAction m_UiWindowsEditor_UP;
    private readonly InputAction m_UiWindowsEditor_Down;
    public struct UiWindowsEditorActions
    {
        private @UiInput m_Wrapper;
        public UiWindowsEditorActions(@UiInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_UiWindowsEditor_Submit;
        public InputAction @Start => m_Wrapper.m_UiWindowsEditor_Start;
        public InputAction @Back => m_Wrapper.m_UiWindowsEditor_Back;
        public InputAction @Right => m_Wrapper.m_UiWindowsEditor_Right;
        public InputAction @Left => m_Wrapper.m_UiWindowsEditor_Left;
        public InputAction @UP => m_Wrapper.m_UiWindowsEditor_UP;
        public InputAction @Down => m_Wrapper.m_UiWindowsEditor_Down;
        public InputActionMap Get() { return m_Wrapper.m_UiWindowsEditor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiWindowsEditorActions set) { return set.Get(); }
        public void SetCallbacks(IUiWindowsEditorActions instance)
        {
            if (m_Wrapper.m_UiWindowsEditorActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnSubmit;
                @Start.started -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnStart;
                @Back.started -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnBack;
                @Right.started -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnLeft;
                @UP.started -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnUP;
                @UP.performed -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnUP;
                @UP.canceled -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnUP;
                @Down.started -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_UiWindowsEditorActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_UiWindowsEditorActionsCallbackInterface = instance;
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
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @UP.started += instance.OnUP;
                @UP.performed += instance.OnUP;
                @UP.canceled += instance.OnUP;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public UiWindowsEditorActions @UiWindowsEditor => new UiWindowsEditorActions(this);

    // UiWebgl
    private readonly InputActionMap m_UiWebgl;
    private IUiWebglActions m_UiWebglActionsCallbackInterface;
    private readonly InputAction m_UiWebgl_Submit;
    private readonly InputAction m_UiWebgl_Start;
    private readonly InputAction m_UiWebgl_Back;
    private readonly InputAction m_UiWebgl_Right;
    private readonly InputAction m_UiWebgl_Left;
    private readonly InputAction m_UiWebgl_UP;
    private readonly InputAction m_UiWebgl_Down;
    public struct UiWebglActions
    {
        private @UiInput m_Wrapper;
        public UiWebglActions(@UiInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_UiWebgl_Submit;
        public InputAction @Start => m_Wrapper.m_UiWebgl_Start;
        public InputAction @Back => m_Wrapper.m_UiWebgl_Back;
        public InputAction @Right => m_Wrapper.m_UiWebgl_Right;
        public InputAction @Left => m_Wrapper.m_UiWebgl_Left;
        public InputAction @UP => m_Wrapper.m_UiWebgl_UP;
        public InputAction @Down => m_Wrapper.m_UiWebgl_Down;
        public InputActionMap Get() { return m_Wrapper.m_UiWebgl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiWebglActions set) { return set.Get(); }
        public void SetCallbacks(IUiWebglActions instance)
        {
            if (m_Wrapper.m_UiWebglActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnSubmit;
                @Start.started -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnStart;
                @Back.started -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnBack;
                @Right.started -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnLeft;
                @UP.started -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnUP;
                @UP.performed -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnUP;
                @UP.canceled -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnUP;
                @Down.started -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_UiWebglActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_UiWebglActionsCallbackInterface = instance;
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
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @UP.started += instance.OnUP;
                @UP.performed += instance.OnUP;
                @UP.canceled += instance.OnUP;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public UiWebglActions @UiWebgl => new UiWebglActions(this);

    // UiMobile
    private readonly InputActionMap m_UiMobile;
    private IUiMobileActions m_UiMobileActionsCallbackInterface;
    private readonly InputAction m_UiMobile_Submit;
    private readonly InputAction m_UiMobile_Start;
    private readonly InputAction m_UiMobile_Back;
    private readonly InputAction m_UiMobile_Right;
    private readonly InputAction m_UiMobile_Left;
    private readonly InputAction m_UiMobile_UP;
    private readonly InputAction m_UiMobile_Down;
    public struct UiMobileActions
    {
        private @UiInput m_Wrapper;
        public UiMobileActions(@UiInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_UiMobile_Submit;
        public InputAction @Start => m_Wrapper.m_UiMobile_Start;
        public InputAction @Back => m_Wrapper.m_UiMobile_Back;
        public InputAction @Right => m_Wrapper.m_UiMobile_Right;
        public InputAction @Left => m_Wrapper.m_UiMobile_Left;
        public InputAction @UP => m_Wrapper.m_UiMobile_UP;
        public InputAction @Down => m_Wrapper.m_UiMobile_Down;
        public InputActionMap Get() { return m_Wrapper.m_UiMobile; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UiMobileActions set) { return set.Get(); }
        public void SetCallbacks(IUiMobileActions instance)
        {
            if (m_Wrapper.m_UiMobileActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnSubmit;
                @Start.started -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnStart;
                @Back.started -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnBack;
                @Right.started -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnLeft;
                @UP.started -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnUP;
                @UP.performed -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnUP;
                @UP.canceled -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnUP;
                @Down.started -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_UiMobileActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_UiMobileActionsCallbackInterface = instance;
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
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @UP.started += instance.OnUP;
                @UP.performed += instance.OnUP;
                @UP.canceled += instance.OnUP;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public UiMobileActions @UiMobile => new UiMobileActions(this);
    public interface IUiTvOsActions
    {
        void OnSubmit(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
    public interface IUiWindowsEditorActions
    {
        void OnSubmit(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnUP(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
    public interface IUiWebglActions
    {
        void OnSubmit(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnUP(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
    public interface IUiMobileActions
    {
        void OnSubmit(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnUP(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
}
