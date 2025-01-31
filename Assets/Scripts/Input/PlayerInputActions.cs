//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Resources/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""DefaultGameMap"",
            ""id"": ""8a5b9ea1-7b05-44c8-a3f7-509f9043fa5f"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""13ef5d75-b9ab-422f-a79a-e5da6e2dffb1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""b646a25e-584d-40ca-a9b7-ab6b4e2ffe23"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TurnRight"",
                    ""type"": ""Button"",
                    ""id"": ""eef3ee26-a3a4-4719-8c97-7ce213e7fa02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""a14d1b39-e309-4da5-b6a1-8f9c9591f413"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveBackward"",
                    ""type"": ""Button"",
                    ""id"": ""47056372-1835-47c2-a4e4-45dafba185d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e705701c-3d04-4f92-9983-5ed48dd32a8a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5be2fb29-adae-4dd4-a03f-ff6c1d516ed0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92403272-cf59-447c-9365-64acc07947b2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f9cec55-9e5b-4a8e-9eb7-39e4ecb0024a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b70a2550-2e12-4bc6-a70d-09e18398d01a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveBackward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // DefaultGameMap
        m_DefaultGameMap = asset.FindActionMap("DefaultGameMap", throwIfNotFound: true);
        m_DefaultGameMap_Shoot = m_DefaultGameMap.FindAction("Shoot", throwIfNotFound: true);
        m_DefaultGameMap_TurnLeft = m_DefaultGameMap.FindAction("TurnLeft", throwIfNotFound: true);
        m_DefaultGameMap_TurnRight = m_DefaultGameMap.FindAction("TurnRight", throwIfNotFound: true);
        m_DefaultGameMap_MoveForward = m_DefaultGameMap.FindAction("MoveForward", throwIfNotFound: true);
        m_DefaultGameMap_MoveBackward = m_DefaultGameMap.FindAction("MoveBackward", throwIfNotFound: true);
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

    // DefaultGameMap
    private readonly InputActionMap m_DefaultGameMap;
    private List<IDefaultGameMapActions> m_DefaultGameMapActionsCallbackInterfaces = new List<IDefaultGameMapActions>();
    private readonly InputAction m_DefaultGameMap_Shoot;
    private readonly InputAction m_DefaultGameMap_TurnLeft;
    private readonly InputAction m_DefaultGameMap_TurnRight;
    private readonly InputAction m_DefaultGameMap_MoveForward;
    private readonly InputAction m_DefaultGameMap_MoveBackward;
    public struct DefaultGameMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public DefaultGameMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_DefaultGameMap_Shoot;
        public InputAction @TurnLeft => m_Wrapper.m_DefaultGameMap_TurnLeft;
        public InputAction @TurnRight => m_Wrapper.m_DefaultGameMap_TurnRight;
        public InputAction @MoveForward => m_Wrapper.m_DefaultGameMap_MoveForward;
        public InputAction @MoveBackward => m_Wrapper.m_DefaultGameMap_MoveBackward;
        public InputActionMap Get() { return m_Wrapper.m_DefaultGameMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultGameMapActions set) { return set.Get(); }
        public void AddCallbacks(IDefaultGameMapActions instance)
        {
            if (instance == null || m_Wrapper.m_DefaultGameMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DefaultGameMapActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @TurnLeft.started += instance.OnTurnLeft;
            @TurnLeft.performed += instance.OnTurnLeft;
            @TurnLeft.canceled += instance.OnTurnLeft;
            @TurnRight.started += instance.OnTurnRight;
            @TurnRight.performed += instance.OnTurnRight;
            @TurnRight.canceled += instance.OnTurnRight;
            @MoveForward.started += instance.OnMoveForward;
            @MoveForward.performed += instance.OnMoveForward;
            @MoveForward.canceled += instance.OnMoveForward;
            @MoveBackward.started += instance.OnMoveBackward;
            @MoveBackward.performed += instance.OnMoveBackward;
            @MoveBackward.canceled += instance.OnMoveBackward;
        }

        private void UnregisterCallbacks(IDefaultGameMapActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @TurnLeft.started -= instance.OnTurnLeft;
            @TurnLeft.performed -= instance.OnTurnLeft;
            @TurnLeft.canceled -= instance.OnTurnLeft;
            @TurnRight.started -= instance.OnTurnRight;
            @TurnRight.performed -= instance.OnTurnRight;
            @TurnRight.canceled -= instance.OnTurnRight;
            @MoveForward.started -= instance.OnMoveForward;
            @MoveForward.performed -= instance.OnMoveForward;
            @MoveForward.canceled -= instance.OnMoveForward;
            @MoveBackward.started -= instance.OnMoveBackward;
            @MoveBackward.performed -= instance.OnMoveBackward;
            @MoveBackward.canceled -= instance.OnMoveBackward;
        }

        public void RemoveCallbacks(IDefaultGameMapActions instance)
        {
            if (m_Wrapper.m_DefaultGameMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDefaultGameMapActions instance)
        {
            foreach (var item in m_Wrapper.m_DefaultGameMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DefaultGameMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DefaultGameMapActions @DefaultGameMap => new DefaultGameMapActions(this);
    public interface IDefaultGameMapActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnMoveForward(InputAction.CallbackContext context);
        void OnMoveBackward(InputAction.CallbackContext context);
    }



}
