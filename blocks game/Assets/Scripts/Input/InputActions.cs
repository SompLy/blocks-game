//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Input/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Humanoid Land"",
            ""id"": ""9ead8f9a-8760-490f-a9d3-b1c1485a84a0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a98a875e-01b1-49f5-aa2a-02059cd32b0b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""254f9bf2-35bf-4f66-a2a0-5af9ab7f0a67"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ZoomCamera"",
                    ""type"": ""Value"",
                    ""id"": ""5e628cfb-75b5-421d-b761-cd130aeec6b4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PlaceBlock"",
                    ""type"": ""Button"",
                    ""id"": ""7d0f51f1-760a-407b-b9a2-90d4013970c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RemoveBlock"",
                    ""type"": ""Value"",
                    ""id"": ""92b02820-cbcd-419a-8de9-c46d718dcaae"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""e446ed12-485a-4511-89c7-2596158f8746"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""828e75a7-25d9-4fd7-bf0b-bd3322b8dadb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sneak"",
                    ""type"": ""Value"",
                    ""id"": ""a6fa72b7-4b5a-4f7f-8e8e-a16b76164326"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""10d51fdd-fac4-428b-8a4d-e8c1b3fb7039"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""1b6e350e-8389-47c1-8a92-5b94fe7d852f"",
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
                    ""id"": ""a167a66d-a3db-4642-9cc6-8a0badc56696"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""29a6cc20-5b78-4901-8884-459c860f43d5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""58a1318c-9707-4ef5-91a4-68d282cb17c3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ec745beb-8acd-4f70-a010-eeb2f2cf245d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1a427d03-b1d0-4a75-9494-f2b52d955811"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""593e1374-2eef-4c49-9ff1-39374ed569b4"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.03,y=0.03)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""424971a1-174f-4ed0-ad40-4f80cd20e0e5"",
                    ""path"": ""<Gamepad>/dpad/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2aa488f9-05e4-4f57-90e8-490bdbba8303"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-4,max=4)"",
                    ""groups"": """",
                    ""action"": ""ZoomCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""553d35cf-d49f-4a7e-bd5a-074a881c34df"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceBlock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a44615dc-3d90-4034-9eea-d05fe8fb0207"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bbc2209f-c744-4609-aff1-6af394803563"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04467288-e547-4776-91bf-afd5f9d40769"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sneak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a97a6059-77d3-4acd-b7ab-1aa366988a6b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RemoveBlock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Humanoid Land
        m_HumanoidLand = asset.FindActionMap("Humanoid Land", throwIfNotFound: true);
        m_HumanoidLand_Move = m_HumanoidLand.FindAction("Move", throwIfNotFound: true);
        m_HumanoidLand_Look = m_HumanoidLand.FindAction("Look", throwIfNotFound: true);
        m_HumanoidLand_ZoomCamera = m_HumanoidLand.FindAction("ZoomCamera", throwIfNotFound: true);
        m_HumanoidLand_PlaceBlock = m_HumanoidLand.FindAction("PlaceBlock", throwIfNotFound: true);
        m_HumanoidLand_RemoveBlock = m_HumanoidLand.FindAction("RemoveBlock", throwIfNotFound: true);
        m_HumanoidLand_Run = m_HumanoidLand.FindAction("Run", throwIfNotFound: true);
        m_HumanoidLand_Jump = m_HumanoidLand.FindAction("Jump", throwIfNotFound: true);
        m_HumanoidLand_Sneak = m_HumanoidLand.FindAction("Sneak", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Humanoid Land
    private readonly InputActionMap m_HumanoidLand;
    private IHumanoidLandActions m_HumanoidLandActionsCallbackInterface;
    private readonly InputAction m_HumanoidLand_Move;
    private readonly InputAction m_HumanoidLand_Look;
    private readonly InputAction m_HumanoidLand_ZoomCamera;
    private readonly InputAction m_HumanoidLand_PlaceBlock;
    private readonly InputAction m_HumanoidLand_RemoveBlock;
    private readonly InputAction m_HumanoidLand_Run;
    private readonly InputAction m_HumanoidLand_Jump;
    private readonly InputAction m_HumanoidLand_Sneak;
    public struct HumanoidLandActions
    {
        private @InputActions m_Wrapper;
        public HumanoidLandActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_HumanoidLand_Move;
        public InputAction @Look => m_Wrapper.m_HumanoidLand_Look;
        public InputAction @ZoomCamera => m_Wrapper.m_HumanoidLand_ZoomCamera;
        public InputAction @PlaceBlock => m_Wrapper.m_HumanoidLand_PlaceBlock;
        public InputAction @RemoveBlock => m_Wrapper.m_HumanoidLand_RemoveBlock;
        public InputAction @Run => m_Wrapper.m_HumanoidLand_Run;
        public InputAction @Jump => m_Wrapper.m_HumanoidLand_Jump;
        public InputAction @Sneak => m_Wrapper.m_HumanoidLand_Sneak;
        public InputActionMap Get() { return m_Wrapper.m_HumanoidLand; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HumanoidLandActions set) { return set.Get(); }
        public void SetCallbacks(IHumanoidLandActions instance)
        {
            if (m_Wrapper.m_HumanoidLandActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnLook;
                @ZoomCamera.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnZoomCamera;
                @ZoomCamera.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnZoomCamera;
                @ZoomCamera.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnZoomCamera;
                @PlaceBlock.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnPlaceBlock;
                @PlaceBlock.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnPlaceBlock;
                @PlaceBlock.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnPlaceBlock;
                @RemoveBlock.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRemoveBlock;
                @RemoveBlock.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRemoveBlock;
                @RemoveBlock.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRemoveBlock;
                @Run.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnJump;
                @Sneak.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnSneak;
                @Sneak.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnSneak;
                @Sneak.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnSneak;
            }
            m_Wrapper.m_HumanoidLandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @ZoomCamera.started += instance.OnZoomCamera;
                @ZoomCamera.performed += instance.OnZoomCamera;
                @ZoomCamera.canceled += instance.OnZoomCamera;
                @PlaceBlock.started += instance.OnPlaceBlock;
                @PlaceBlock.performed += instance.OnPlaceBlock;
                @PlaceBlock.canceled += instance.OnPlaceBlock;
                @RemoveBlock.started += instance.OnRemoveBlock;
                @RemoveBlock.performed += instance.OnRemoveBlock;
                @RemoveBlock.canceled += instance.OnRemoveBlock;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sneak.started += instance.OnSneak;
                @Sneak.performed += instance.OnSneak;
                @Sneak.canceled += instance.OnSneak;
            }
        }
    }
    public HumanoidLandActions @HumanoidLand => new HumanoidLandActions(this);
    public interface IHumanoidLandActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnZoomCamera(InputAction.CallbackContext context);
        void OnPlaceBlock(InputAction.CallbackContext context);
        void OnRemoveBlock(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSneak(InputAction.CallbackContext context);
    }
}
