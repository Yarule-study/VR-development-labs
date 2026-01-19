using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInfo : MonoBehaviour
{
    [Header("UI Reference")]
    public GameObject infoCanvas;

    [Header("Input Action")]
    public InputActionProperty toggleAction;
    private bool isHovered = false;

    void Start()
    {
        if (infoCanvas != null) infoCanvas.SetActive(false);
    }

    void Update()
    {
        if (isHovered && toggleAction.action.WasPressedThisFrame())
        {
            if (infoCanvas != null)
                infoCanvas.SetActive(!infoCanvas.activeSelf);
        }
    }

    public void OnHoverEnter() => isHovered = true;

    public void OnHoverExit() 
    {
        isHovered = false;
        if (infoCanvas != null) infoCanvas.SetActive(false);
    }
}