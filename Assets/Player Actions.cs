// GENERATED AUTOMATICALLY FROM 'Assets/Player Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Actions"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""a5e37215-5022-4c47-87f4-98ab4269d551"",
            ""actions"": [
                {
                    ""name"": ""Move Direction"",
                    ""type"": ""Value"",
                    ""id"": ""794e64d2-610d-4941-886e-5280d7c8d0ff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""A Button"",
                    ""type"": ""Button"",
                    ""id"": ""25cd6bbb-cd75-4ba1-987f-f725c66c79e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Y Button"",
                    ""type"": ""Button"",
                    ""id"": ""795d2c4d-6658-4b3c-9d26-b6272d535f42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LB+RB"",
                    ""type"": ""Button"",
                    ""id"": ""7d098c34-75f9-42b7-abc3-8b0e634eb6db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9ec76de3-f7ab-43c0-ba5c-524cad806a7e"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""76bc7540-ae0c-4cd2-ae37-83a44cd171b4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f1437aa1-8684-4668-a7b1-b3315e5f7a90"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e93b5dd0-f776-454c-a66f-875493b40384"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d3935b5f-a2c3-48c1-ac2b-164117cee23c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9ba46353-0065-447d-a45b-707c7bffc94c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""22fca7e9-f351-48a9-8fa3-037a88817300"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6e85728e-6968-4058-9881-cd520668bddd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""57cd9087-105d-49ce-aa56-bff1fb66bdd3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6d03275b-8484-4ca8-b2f4-42ccc158fd16"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""21ef7065-9e75-4292-bd20-2525a1f7f05f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a39247a1-ae4e-439d-ab98-0aff619487d8"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""A Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dfae8f5-9ddc-4ade-8986-66de7ba26cb0"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Y Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""LB+RB"",
                    ""id"": ""6a7423a6-95fd-4ab3-95e9-d0f2abc032bf"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LB+RB"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""c422e47d-d2e3-40b8-a71a-82b3f615b41f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""LB+RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""7a1766a6-4ae4-4355-8c2d-5bad75999755"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""LB+RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox Controller"",
            ""bindingGroup"": ""Xbox Controller"",
            ""devices"": []
        }
    ]
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_MoveDirection = m_Controls.FindAction("Move Direction", throwIfNotFound: true);
        m_Controls_AButton = m_Controls.FindAction("A Button", throwIfNotFound: true);
        m_Controls_YButton = m_Controls.FindAction("Y Button", throwIfNotFound: true);
        m_Controls_LBRB = m_Controls.FindAction("LB+RB", throwIfNotFound: true);
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

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_MoveDirection;
    private readonly InputAction m_Controls_AButton;
    private readonly InputAction m_Controls_YButton;
    private readonly InputAction m_Controls_LBRB;
    public struct ControlsActions
    {
        private @PlayerActions m_Wrapper;
        public ControlsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveDirection => m_Wrapper.m_Controls_MoveDirection;
        public InputAction @AButton => m_Wrapper.m_Controls_AButton;
        public InputAction @YButton => m_Wrapper.m_Controls_YButton;
        public InputAction @LBRB => m_Wrapper.m_Controls_LBRB;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @MoveDirection.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveDirection;
                @MoveDirection.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveDirection;
                @MoveDirection.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMoveDirection;
                @AButton.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAButton;
                @AButton.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAButton;
                @AButton.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAButton;
                @YButton.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnYButton;
                @YButton.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnYButton;
                @YButton.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnYButton;
                @LBRB.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLBRB;
                @LBRB.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLBRB;
                @LBRB.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLBRB;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveDirection.started += instance.OnMoveDirection;
                @MoveDirection.performed += instance.OnMoveDirection;
                @MoveDirection.canceled += instance.OnMoveDirection;
                @AButton.started += instance.OnAButton;
                @AButton.performed += instance.OnAButton;
                @AButton.canceled += instance.OnAButton;
                @YButton.started += instance.OnYButton;
                @YButton.performed += instance.OnYButton;
                @YButton.canceled += instance.OnYButton;
                @LBRB.started += instance.OnLBRB;
                @LBRB.performed += instance.OnLBRB;
                @LBRB.canceled += instance.OnLBRB;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    private int m_XboxControllerSchemeIndex = -1;
    public InputControlScheme XboxControllerScheme
    {
        get
        {
            if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("Xbox Controller");
            return asset.controlSchemes[m_XboxControllerSchemeIndex];
        }
    }
    public interface IControlsActions
    {
        void OnMoveDirection(InputAction.CallbackContext context);
        void OnAButton(InputAction.CallbackContext context);
        void OnYButton(InputAction.CallbackContext context);
        void OnLBRB(InputAction.CallbackContext context);
    }
}
