using UnityEngine;
using TMPro;

public class PasswordCheck : MonoBehaviour
{
    [SerializeField] private GameObject result;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_InputField tmpInputField;
    [SerializeField] private Timer timer;
    [SerializeField] private string validCharacters = "G734#26H";
    private bool isWin;

    private void ValidateInput()
    {
        if (isWin)
            return;
        var inputValue = tmpInputField.text;
        var trueSymbols = "";
        var isValid = true;

        // Проверяем, что длина строки четная (т.к. один элемент - это два символа)
        if (inputValue.Length != validCharacters.Length || inputValue.Length % 2 != 0)
        {
            return; // Завершаем проверку, если длина нечетная
        }

        // Проверяем каждую пару символов
        for (var i = 0; i < inputValue.Length; i += 2)
        {
            var element = inputValue.Substring(i, 2); // Получаем пару символов

            // Проверяем, что оба символа в допустимом наборе
            foreach (var c in element)
            {
                if (!validCharacters.Contains(c.ToString()))
                {
                    isValid = false; // Если нашли недопустимый символ
                    break; // Останавливаем проверку
                }

                trueSymbols += c;
            }

            if (!isValid)
                break; // Останавливаем, если хотя бы одна пара недопустима
        }

        if (trueSymbols != validCharacters)
            return;
        
        isWin = true;
        timer.timerStop = true;
        resultText.text = "Уровень пройден!";
        result.gameObject.SetActive(true);
        PlayerStats.LevelCompleted(1);
    }

    private void Update()
    {
        ValidateInput();
    }
}