// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""0fa8008f-7f56-4ffd-8652-86c2ca6d9970"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""406deee9-8f1a-4e13-ba2d-393f1e8ca047"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""e5ad58c7-8b66-422e-9454-b765296d21bc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""89cf9366-5cfa-480c-9ad2-be0519ceedb8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""ad7127f9-36b8-4d9b-bd14-bc883bdefb55"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turn"",
                    ""type"": ""Value"",
                    ""id"": ""fc102219-bd9f-4690-a340-eb63c26e9349"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""588db2c8-4ad7-4b7f-b46d-58c14b8dfcbb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""09bc9d9c-d440-4145-b253-29a07763e82b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""1267fec7-339f-4112-92de-9d17f3635667"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RescueHostage"",
                    ""type"": ""Button"",
                    ""id"": ""9c63a084-34e9-428f-a645-2529174f2604"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""62caed1d-d888-447b-8256-d060435d5d07"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1aed2d27-84e9-4749-8475-d2f969641710"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""aaeff323-bb30-4ae5-9134-0bd3f3eab977"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a15bf381-a913-4cde-ac6d-5a05fbbbb313"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2bcd802c-ba73-4777-9533-823c75354972"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""ef678fee-9fec-4c3a-b9dc-43fe630b6115"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""44500889-1062-46e3-8b26-8091e946f6a5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cf45dffd-cc25-49f5-9e99-27a193d4c3da"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0e7205b9-cc1b-4f93-9c25-2d11664bd2a9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e90f9d36-cec3-495b-b158-f0f21bbe23fc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""58d958e3-d43d-453e-9491-523faf1441bf"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0377f338-9427-456c-b943-8e9662a876a1"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39b7c7eb-2a81-4677-9110-3d2238e763da"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecabc31e-3296-44e9-9a06-51f8d1acae81"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""080adf8b-8816-49e7-9ae3-2a21abf1f43d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9814d09d-b107-44fb-8e1f-a0684ffb1a4f"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55da5405-d555-4e93-b1c7-2e82e3b13283"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f61fc7a-6dba-40a9-bd10-0b1f7288fad7"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5a1d128-a0ff-456f-aaf3-4844f0d1134d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4255c1b7-0549-4df2-b213-129238ca754b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ca86b52-dd67-4ed3-8833-a266161e7390"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63ad3a7d-a926-4df2-8874-d82b3361d6d9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7173a68c-68f3-4d36-adcc-befd5e04dd2e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80f24bbe-2f9e-42e8-87e0-070492f94e0a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07238d7d-3143-4e4a-b2a4-866bac82b904"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa799c19-d5a8-453e-a714-be3c3117223b"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f084e0bc-cad2-4682-9a6f-9c84ac8074c5"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf59b7fe-2f63-4394-b4ad-e7b85ebc6d53"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""RescueHostage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea4f521f-7200-4ae5-bbf5-c051cac436de"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RescueHostage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Sound"",
            ""id"": ""87bb78a9-bf87-4740-9964-9427b34efb9f"",
            ""actions"": [
                {
                    ""name"": ""IncreaseSound"",
                    ""type"": ""Button"",
                    ""id"": ""626c4b59-f0e5-4939-9d06-a637ba291c89"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LowerSound"",
                    ""type"": ""Button"",
                    ""id"": ""c5ee8c23-2f57-4631-af1e-56a0f470b5e9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseMusic"",
                    ""type"": ""Button"",
                    ""id"": ""3299069f-c534-4af4-a1a5-c8674827b63c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LowerMusic"",
                    ""type"": ""Button"",
                    ""id"": ""a36c5969-2ffc-4679-ad07-27988ef999de"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2f19bfd5-7d8c-4720-8ab5-5d157fcf6066"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""IncreaseSound"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b2e435e-15be-4062-8a61-53b4ddef4b79"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LowerSound"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0e0fbff-b8aa-450f-adf1-2615999093bb"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""IncreaseMusic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f2c57ed-9dfd-4465-bd88-8a150af7e8d1"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LowerMusic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Turn = m_Player.FindAction("Turn", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
        m_Player_RescueHostage = m_Player.FindAction("RescueHostage", throwIfNotFound: true);
        // Sound
        m_Sound = asset.FindActionMap("Sound", throwIfNotFound: true);
        m_Sound_IncreaseSound = m_Sound.FindAction("IncreaseSound", throwIfNotFound: true);
        m_Sound_LowerSound = m_Sound.FindAction("LowerSound", throwIfNotFound: true);
        m_Sound_IncreaseMusic = m_Sound.FindAction("IncreaseMusic", throwIfNotFound: true);
        m_Sound_LowerMusic = m_Sound.FindAction("LowerMusic", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Turn;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_Aim;
    private readonly InputAction m_Player_Reload;
    private readonly InputAction m_Player_RescueHostage;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Turn => m_Wrapper.m_Player_Turn;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputAction @RescueHostage => m_Wrapper.m_Player_RescueHostage;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Turn.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurn;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Reload.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @RescueHostage.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRescueHostage;
                @RescueHostage.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRescueHostage;
                @RescueHostage.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRescueHostage;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @RescueHostage.started += instance.OnRescueHostage;
                @RescueHostage.performed += instance.OnRescueHostage;
                @RescueHostage.canceled += instance.OnRescueHostage;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Sound
    private readonly InputActionMap m_Sound;
    private ISoundActions m_SoundActionsCallbackInterface;
    private readonly InputAction m_Sound_IncreaseSound;
    private readonly InputAction m_Sound_LowerSound;
    private readonly InputAction m_Sound_IncreaseMusic;
    private readonly InputAction m_Sound_LowerMusic;
    public struct SoundActions
    {
        private @Controls m_Wrapper;
        public SoundActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @IncreaseSound => m_Wrapper.m_Sound_IncreaseSound;
        public InputAction @LowerSound => m_Wrapper.m_Sound_LowerSound;
        public InputAction @IncreaseMusic => m_Wrapper.m_Sound_IncreaseMusic;
        public InputAction @LowerMusic => m_Wrapper.m_Sound_LowerMusic;
        public InputActionMap Get() { return m_Wrapper.m_Sound; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SoundActions set) { return set.Get(); }
        public void SetCallbacks(ISoundActions instance)
        {
            if (m_Wrapper.m_SoundActionsCallbackInterface != null)
            {
                @IncreaseSound.started -= m_Wrapper.m_SoundActionsCallbackInterface.OnIncreaseSound;
                @IncreaseSound.performed -= m_Wrapper.m_SoundActionsCallbackInterface.OnIncreaseSound;
                @IncreaseSound.canceled -= m_Wrapper.m_SoundActionsCallbackInterface.OnIncreaseSound;
                @LowerSound.started -= m_Wrapper.m_SoundActionsCallbackInterface.OnLowerSound;
                @LowerSound.performed -= m_Wrapper.m_SoundActionsCallbackInterface.OnLowerSound;
                @LowerSound.canceled -= m_Wrapper.m_SoundActionsCallbackInterface.OnLowerSound;
                @IncreaseMusic.started -= m_Wrapper.m_SoundActionsCallbackInterface.OnIncreaseMusic;
                @IncreaseMusic.performed -= m_Wrapper.m_SoundActionsCallbackInterface.OnIncreaseMusic;
                @IncreaseMusic.canceled -= m_Wrapper.m_SoundActionsCallbackInterface.OnIncreaseMusic;
                @LowerMusic.started -= m_Wrapper.m_SoundActionsCallbackInterface.OnLowerMusic;
                @LowerMusic.performed -= m_Wrapper.m_SoundActionsCallbackInterface.OnLowerMusic;
                @LowerMusic.canceled -= m_Wrapper.m_SoundActionsCallbackInterface.OnLowerMusic;
            }
            m_Wrapper.m_SoundActionsCallbackInterface = instance;
            if (instance != null)
            {
                @IncreaseSound.started += instance.OnIncreaseSound;
                @IncreaseSound.performed += instance.OnIncreaseSound;
                @IncreaseSound.canceled += instance.OnIncreaseSound;
                @LowerSound.started += instance.OnLowerSound;
                @LowerSound.performed += instance.OnLowerSound;
                @LowerSound.canceled += instance.OnLowerSound;
                @IncreaseMusic.started += instance.OnIncreaseMusic;
                @IncreaseMusic.performed += instance.OnIncreaseMusic;
                @IncreaseMusic.canceled += instance.OnIncreaseMusic;
                @LowerMusic.started += instance.OnLowerMusic;
                @LowerMusic.performed += instance.OnLowerMusic;
                @LowerMusic.canceled += instance.OnLowerMusic;
            }
        }
    }
    public SoundActions @Sound => new SoundActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnTurn(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnRescueHostage(InputAction.CallbackContext context);
    }
    public interface ISoundActions
    {
        void OnIncreaseSound(InputAction.CallbackContext context);
        void OnLowerSound(InputAction.CallbackContext context);
        void OnIncreaseMusic(InputAction.CallbackContext context);
        void OnLowerMusic(InputAction.CallbackContext context);
    }
}
