using UnityEngine;
using TMPro; // Для TextMesh Pro

public class ButtonPassword : MonoBehaviour
{
    public TMP_InputField targetInputField; // Поле ввода TextMesh Pro
    [SerializeField] private TMP_Text enterPassword;

    // Метод для копирования текста в поле ввода
    public void CopyTextToInputField(string text)
    {
        if (targetInputField != null)
        {
            enterPassword.text = "";
            targetInputField.text += text; // Устанавливаем текст в поле ввода
        }
    }
}
