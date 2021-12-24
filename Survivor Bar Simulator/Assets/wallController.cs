// GENERATED AUTOMATICALLY FROM 'Assets/wallController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @WallController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @WallController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""wallController"",
    ""maps"": [
        {
            ""name"": ""WallMaps"",
            ""id"": ""d704dc56-a439-4ee9-9f28-a59ad642f054"",
            ""actions"": [
                {
                    ""name"": ""DisableWalls"",
                    ""type"": ""Button"",
                    ""id"": ""f04103e5-e89f-40f0-b1da-f2bec21c852f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DisableWallsFront"",
                    ""type"": ""Button"",
                    ""id"": ""405cdffe-d55c-4aae-9049-3199710af9b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a45bca63-6c14-483b-8210-8ccac65b844d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DisableWalls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bb49677-4a95-427a-b075-652020ad0390"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DisableWallsFront"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // WallMaps
        m_WallMaps = asset.FindActionMap("WallMaps", throwIfNotFound: true);
        m_WallMaps_DisableWalls = m_WallMaps.FindAction("DisableWalls", throwIfNotFound: true);
        m_WallMaps_DisableWallsFront = m_WallMaps.FindAction("DisableWallsFront", throwIfNotFound: true);
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

    // WallMaps
    private readonly InputActionMap m_WallMaps;
    private IWallMapsActions m_WallMapsActionsCallbackInterface;
    private readonly InputAction m_WallMaps_DisableWalls;
    private readonly InputAction m_WallMaps_DisableWallsFront;
    public struct WallMapsActions
    {
        private @WallController m_Wrapper;
        public WallMapsActions(@WallController wrapper) { m_Wrapper = wrapper; }
        public InputAction @DisableWalls => m_Wrapper.m_WallMaps_DisableWalls;
        public InputAction @DisableWallsFront => m_Wrapper.m_WallMaps_DisableWallsFront;
        public InputActionMap Get() { return m_Wrapper.m_WallMaps; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WallMapsActions set) { return set.Get(); }
        public void SetCallbacks(IWallMapsActions instance)
        {
            if (m_Wrapper.m_WallMapsActionsCallbackInterface != null)
            {
                @DisableWalls.started -= m_Wrapper.m_WallMapsActionsCallbackInterface.OnDisableWalls;
                @DisableWalls.performed -= m_Wrapper.m_WallMapsActionsCallbackInterface.OnDisableWalls;
                @DisableWalls.canceled -= m_Wrapper.m_WallMapsActionsCallbackInterface.OnDisableWalls;
                @DisableWallsFront.started -= m_Wrapper.m_WallMapsActionsCallbackInterface.OnDisableWallsFront;
                @DisableWallsFront.performed -= m_Wrapper.m_WallMapsActionsCallbackInterface.OnDisableWallsFront;
                @DisableWallsFront.canceled -= m_Wrapper.m_WallMapsActionsCallbackInterface.OnDisableWallsFront;
            }
            m_Wrapper.m_WallMapsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DisableWalls.started += instance.OnDisableWalls;
                @DisableWalls.performed += instance.OnDisableWalls;
                @DisableWalls.canceled += instance.OnDisableWalls;
                @DisableWallsFront.started += instance.OnDisableWallsFront;
                @DisableWallsFront.performed += instance.OnDisableWallsFront;
                @DisableWallsFront.canceled += instance.OnDisableWallsFront;
            }
        }
    }
    public WallMapsActions @WallMaps => new WallMapsActions(this);
    public interface IWallMapsActions
    {
        void OnDisableWalls(InputAction.CallbackContext context);
        void OnDisableWallsFront(InputAction.CallbackContext context);
    }
}
