using UnityEngine;
using UnityEngine.UI;
using TMPro; // Для TextMesh Pro

public class ButtonToTMPInputField : MonoBehaviour
{
    public TMP_InputField targetInputField; // Поле ввода TextMesh Pro

    // Метод для копирования текста в поле ввода
    public void CopyTextToInputField(string text)
    {
        if (targetInputField != null)
        {
            targetInputField.text += text; // Устанавливаем текст в поле ввода
        }
    }
}
