using TMPro;
using UnityEngine;

public class SecondTimer : MonoBehaviour
{
    public float timerDuration = 6f; // Длительность таймера в секундах
    private float timer; // Текущее время на таймере
    private bool isTimerRunning = false; // Флаг запуска таймера

    [SerializeField] private GameObject grid;
    [SerializeField] private TMP_Text timerText; // Ссылка на текстовое поле для отображения времени

    private void Update()
    {
        // Проверяем, идет ли таймер
        if (isTimerRunning)
        {
            // Уменьшаем таймер
            timer -= Time.deltaTime;

            // Округляем значение таймера и выводим его в текстовое поле
            timerText.text = Mathf.Round(timer).ToString();

            // Если время таймера истекло
            if (timer <= 0f)
            {
                // Выключаем объект
                grid.SetActive(false);

                // Останавливаем таймер
                isTimerRunning = false;

                timerText.text = string.Empty;
            }
        }
    }

    // Метод для запуска таймера
    public void StartTimer()
    {
        // Устанавливаем начальное время таймера и запускаем его
        timer = timerDuration;
        isTimerRunning = true;
    }
}
