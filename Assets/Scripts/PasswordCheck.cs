using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class TMP_InputValidator : MonoBehaviour
{
    public TMP_InputField tmpInputField; 
    public Text outputText; // Поле для вывода результатов проверки

    // Допустимый набор символов
    private readonly string validCharacters = "G734#26H";

    public void ValidateInput()
    {
        string inputValue = tmpInputField.text; 
        string TrueSymbols = "";
        bool isValid = true;

        // Проверяем, что длина строки четная (т.к. один элемент - это два символа)
        if (inputValue.Length % 2 != 0)
        {
            outputText.text = "Input length must be even!";
            return; // Завершаем проверку, если длина нечетная
        }

        // Проверяем каждую пару символов
        for (int i = 0; i < inputValue.Length; i += 2)
        {
            string element = inputValue.Substring(i, 2); // Получаем пару символов

            // Проверяем, что оба символа в допустимом наборе
            foreach (char c in element)
            {
                if (!validCharacters.Contains(c.ToString()))
                {
                    isValid = false; // Если нашли недопустимый символ
                    break; // Останавливаем проверку
                }
                if (isValid)
                {
                    TrueSymbols += c;
                }
            }

            if (!isValid) break; // Останавливаем, если хотя бы одна пара недопустима
        }

        if (TrueSymbols.Contains(validCharacters))
        {
            outputText.text = "Input is valid!"; // Все пары допустимы
        }
    }

    private void Update()
    {
        ValidateInput();
    }
}
