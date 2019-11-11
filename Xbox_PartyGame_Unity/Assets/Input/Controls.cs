// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Controls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d38a3edb-569e-4d30-aadf-bce8b1a1ccf1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b748aacb-5946-4a22-a8f6-fbf46000110a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button South"",
                    ""type"": ""Button"",
                    ""id"": ""51fd0895-4444-4b04-91c2-6685d238219b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button East"",
                    ""type"": ""Button"",
                    ""id"": ""ff6be3df-cb2a-466e-8b33-b317ade0c37b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button North"",
                    ""type"": ""Button"",
                    ""id"": ""f25420f2-ab25-4556-8dfb-25b9ca12b1da"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button West"",
                    ""type"": ""Button"",
                    ""id"": ""5bad13df-9b35-4541-84f1-92a18a02d9e1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit To Menu"",
                    ""type"": ""Button"",
                    ""id"": ""41b0e420-94e6-47fe-b12e-0cfe288228de"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Trigger Left"",
                    ""type"": ""Value"",
                    ""id"": ""b877a5cc-b11a-4150-8e7c-a654d8a8c43c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Trigger Right"",
                    ""type"": ""Value"",
                    ""id"": ""83b736a5-a034-4ddf-9229-2de5c32c56c4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""45f7090d-6a81-4adb-b43a-ed63108619d2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""09229822-c8b3-45b5-9b45-5bebb46d452d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""659cd02c-aba2-460f-892b-e7dadbcac8c5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""501d28c3-0fb7-4ef9-b2c7-6ba36995da0b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb3cb92d-76c0-4b94-a073-11d739b2612a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80a6cfa0-87cf-4f8d-963c-4edba2a70431"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0da30a01-e2ab-4e81-bf15-8c90fc67e3c9"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit To Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eae89bdc-1a9c-4f0e-8ddf-a24e33c2712d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4a62f19-a1b1-4f5c-9dce-e0e373fd6194"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trigger Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""619a7fd3-596b-4001-a539-df8c9320982a"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""79275d72-2255-4524-beef-d93d63e301db"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""82fa229b-7168-40af-97dd-c422187286b9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""51fb1fac-0ca2-4bb1-a61a-8eb87bad8d5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""654de2f8-d1ba-4ce5-9b73-05362c722a15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d119ef54-642f-4a60-819c-7808ad8b6e30"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6d9ece2d-4c05-41ba-892f-1965c1aeee6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""119c4a0b-843b-45c9-8466-48d650ef6fda"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f031ce99-d77e-4207-a661-47aa14a6a074"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c4ba562e-f494-48c3-a3c0-030dd5c9ceea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e525ae03-65d5-42e1-b989-b1ae155f20de"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b5688366-263e-46ab-b496-394a25a40300"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceSelect"",
                    ""type"": ""PassThrough"",
                    ""id"": ""273d7fe5-5c2d-47b9-862a-91660f25f2f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Stick"",
                    ""id"": ""642ae611-0533-46f2-9025-08fa8df2ef05"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ebd7eb7f-93c0-4b6d-9a8f-1d3452ebec67"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2e353f6b-b809-4ee8-89c9-bfd54b260dce"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ae462391-f5ab-4370-bf18-ed51cc4982c1"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""15dca962-1b86-4339-ab1c-d430436538ed"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dc6a16c7-b983-40c1-8c59-18deed9c4567"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""38c18af2-b110-4d1b-81bf-1b76c760eb39"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b2a437f3-61a6-47cb-898f-4860c4802b85"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f7d0a676-e728-4802-9de3-126024a9f166"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8cb20349-e325-4829-ada0-b48b535ebf29"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""26e30389-faec-43b0-9391-6c3b9665572e"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0e8490a5-8ad0-45f1-b48f-3158e40b3786"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31cbbab3-b6bd-476b-8f5d-850f6c59039c"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6eb081eb-91e8-4db5-af62-e061342cfa34"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f93006c-7daa-4e6c-bf4d-6491fbda2f89"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3292e9ce-c089-4666-8510-2ee84ba7edca"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5f3910c-cbb6-402f-b206-5de1724a2108"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30f13a8a-311b-46d0-a6b4-2f61b26033ca"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3fcabb4-2a2d-4b5c-9fe7-4a79ba51f749"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a704cb37-1ffe-437c-8d75-b0036fdb9177"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dde57f96-9778-4d63-ad36-c49e3a920da5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27761577-fd08-4d9e-8844-6c959a26d642"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6dfa999-de19-4289-87a6-e06183ed4caf"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""547b86ba-867f-49f4-8151-f4f958ec3bc4"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackedDeviceSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_ButtonSouth = m_Player.FindAction("Button South", throwIfNotFound: true);
        m_Player_ButtonEast = m_Player.FindAction("Button East", throwIfNotFound: true);
        m_Player_ButtonNorth = m_Player.FindAction("Button North", throwIfNotFound: true);
        m_Player_ButtonWest = m_Player.FindAction("Button West", throwIfNotFound: true);
        m_Player_ExitToMenu = m_Player.FindAction("Exit To Menu", throwIfNotFound: true);
        m_Player_TriggerLeft = m_Player.FindAction("Trigger Left", throwIfNotFound: true);
        m_Player_TriggerRight = m_Player.FindAction("Trigger Right", throwIfNotFound: true);
        m_Player_Start = m_Player.FindAction("Start", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
        m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
        m_UI_TrackedDeviceSelect = m_UI.FindAction("TrackedDeviceSelect", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_ButtonSouth;
    private readonly InputAction m_Player_ButtonEast;
    private readonly InputAction m_Player_ButtonNorth;
    private readonly InputAction m_Player_ButtonWest;
    private readonly InputAction m_Player_ExitToMenu;
    private readonly InputAction m_Player_TriggerLeft;
    private readonly InputAction m_Player_TriggerRight;
    private readonly InputAction m_Player_Start;
    public struct PlayerActions
    {
        private Controls m_Wrapper;
        public PlayerActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @ButtonSouth => m_Wrapper.m_Player_ButtonSouth;
        public InputAction @ButtonEast => m_Wrapper.m_Player_ButtonEast;
        public InputAction @ButtonNorth => m_Wrapper.m_Player_ButtonNorth;
        public InputAction @ButtonWest => m_Wrapper.m_Player_ButtonWest;
        public InputAction @ExitToMenu => m_Wrapper.m_Player_ExitToMenu;
        public InputAction @TriggerLeft => m_Wrapper.m_Player_TriggerLeft;
        public InputAction @TriggerRight => m_Wrapper.m_Player_TriggerRight;
        public InputAction @Start => m_Wrapper.m_Player_Start;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                ButtonSouth.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonSouth;
                ButtonSouth.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonSouth;
                ButtonSouth.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonSouth;
                ButtonEast.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonEast;
                ButtonEast.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonEast;
                ButtonEast.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonEast;
                ButtonNorth.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonNorth;
                ButtonNorth.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonNorth;
                ButtonNorth.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonNorth;
                ButtonWest.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonWest;
                ButtonWest.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonWest;
                ButtonWest.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonWest;
                ExitToMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitToMenu;
                ExitToMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitToMenu;
                ExitToMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitToMenu;
                TriggerLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerLeft;
                TriggerLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerLeft;
                TriggerLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerLeft;
                TriggerRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerRight;
                TriggerRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerRight;
                TriggerRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerRight;
                Start.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStart;
                Start.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStart;
                Start.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStart;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                ButtonSouth.started += instance.OnButtonSouth;
                ButtonSouth.performed += instance.OnButtonSouth;
                ButtonSouth.canceled += instance.OnButtonSouth;
                ButtonEast.started += instance.OnButtonEast;
                ButtonEast.performed += instance.OnButtonEast;
                ButtonEast.canceled += instance.OnButtonEast;
                ButtonNorth.started += instance.OnButtonNorth;
                ButtonNorth.performed += instance.OnButtonNorth;
                ButtonNorth.canceled += instance.OnButtonNorth;
                ButtonWest.started += instance.OnButtonWest;
                ButtonWest.performed += instance.OnButtonWest;
                ButtonWest.canceled += instance.OnButtonWest;
                ExitToMenu.started += instance.OnExitToMenu;
                ExitToMenu.performed += instance.OnExitToMenu;
                ExitToMenu.canceled += instance.OnExitToMenu;
                TriggerLeft.started += instance.OnTriggerLeft;
                TriggerLeft.performed += instance.OnTriggerLeft;
                TriggerLeft.canceled += instance.OnTriggerLeft;
                TriggerRight.started += instance.OnTriggerRight;
                TriggerRight.performed += instance.OnTriggerRight;
                TriggerRight.canceled += instance.OnTriggerRight;
                Start.started += instance.OnStart;
                Start.performed += instance.OnStart;
                Start.canceled += instance.OnStart;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    private readonly InputAction m_UI_TrackedDeviceSelect;
    public struct UIActions
    {
        private Controls m_Wrapper;
        public UIActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputAction @TrackedDeviceSelect => m_Wrapper.m_UI_TrackedDeviceSelect;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                TrackedDeviceSelect.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
                TrackedDeviceSelect.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
                TrackedDeviceSelect.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceSelect;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                Navigate.started += instance.OnNavigate;
                Navigate.performed += instance.OnNavigate;
                Navigate.canceled += instance.OnNavigate;
                Submit.started += instance.OnSubmit;
                Submit.performed += instance.OnSubmit;
                Submit.canceled += instance.OnSubmit;
                Cancel.started += instance.OnCancel;
                Cancel.performed += instance.OnCancel;
                Cancel.canceled += instance.OnCancel;
                Point.started += instance.OnPoint;
                Point.performed += instance.OnPoint;
                Point.canceled += instance.OnPoint;
                Click.started += instance.OnClick;
                Click.performed += instance.OnClick;
                Click.canceled += instance.OnClick;
                ScrollWheel.started += instance.OnScrollWheel;
                ScrollWheel.performed += instance.OnScrollWheel;
                ScrollWheel.canceled += instance.OnScrollWheel;
                MiddleClick.started += instance.OnMiddleClick;
                MiddleClick.performed += instance.OnMiddleClick;
                MiddleClick.canceled += instance.OnMiddleClick;
                RightClick.started += instance.OnRightClick;
                RightClick.performed += instance.OnRightClick;
                RightClick.canceled += instance.OnRightClick;
                TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
                TrackedDeviceSelect.started += instance.OnTrackedDeviceSelect;
                TrackedDeviceSelect.performed += instance.OnTrackedDeviceSelect;
                TrackedDeviceSelect.canceled += instance.OnTrackedDeviceSelect;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnButtonSouth(InputAction.CallbackContext context);
        void OnButtonEast(InputAction.CallbackContext context);
        void OnButtonNorth(InputAction.CallbackContext context);
        void OnButtonWest(InputAction.CallbackContext context);
        void OnExitToMenu(InputAction.CallbackContext context);
        void OnTriggerLeft(InputAction.CallbackContext context);
        void OnTriggerRight(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
        void OnTrackedDeviceSelect(InputAction.CallbackContext context);
    }
}
