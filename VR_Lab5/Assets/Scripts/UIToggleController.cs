using UnityEngine;
using UnityEngine.InputSystem;

public class UIToggleController : MonoBehaviour
{
    [Header("UI Manager")]
    public UIFormManager uiManager;

    [Header("Input Action")]
    public InputActionProperty toggleUIAction;

    void OnEnable()
    {
        toggleUIAction.action.Enable();
        toggleUIAction.action.performed += OnToggleUI;
    }

    void OnDisable()
    {
        toggleUIAction.action.performed -= OnToggleUI;
        toggleUIAction.action.Disable();
    }

    void OnToggleUI(InputAction.CallbackContext context)
    {
        uiManager.ToggleUI();
    }
}