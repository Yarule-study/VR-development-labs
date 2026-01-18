using UnityEngine;
using TMPro;

public class UIFormManager : MonoBehaviour
{
    [Header("UI References")]
    public Canvas mainCanvas;
    public TMP_InputField nameInput;
    public TMP_InputField emailInput;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI displayDataText;

    private bool isOpen = false;

    void Start()
    {
        mainCanvas.enabled = false;
        if (displayDataText != null) displayDataText.text = "";
    }

    public void ToggleUI()
    {
        isOpen = !isOpen;
        mainCanvas.enabled = isOpen;
    }

    public void SubmitForm()
    {
        string name = nameInput.text;
        string email = emailInput.text;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
        {
            if (feedbackText != null)
                feedbackText.text = "Будь ласка, заповніть усі поля";
            return;
        }

        SaveData(name, email);
        
        if (feedbackText != null)
            feedbackText.text = "Дані успішно збережено!";
    }

    public void LoadAndDisplayData()
    {
        if (PlayerPrefs.HasKey("UserName") && PlayerPrefs.HasKey("UserEmail"))
        {
            string savedName = PlayerPrefs.GetString("UserName");
            string savedEmail = PlayerPrefs.GetString("UserEmail");

            nameInput.text = savedName;
            emailInput.text = savedEmail;

            if (displayDataText != null)
                displayDataText.text = $"Збережено: {savedName} ({savedEmail})";
            
            if (feedbackText != null)
                feedbackText.text = "Дані завантажено!";
        }
        else
        {
            if (feedbackText != null)
                feedbackText.text = "Немає збережених даних";
        }
    }

    public void CloseForm()
    {
        isOpen = false;
        mainCanvas.enabled = false;
    }

    void SaveData(string name, string email)
    {
        PlayerPrefs.SetString("UserName", name);
        PlayerPrefs.SetString("UserEmail", email);
        PlayerPrefs.Save();
    }
}