using System;
using TMPro;
using UnityEngine;

namespace LevelsLogic._1lvl
{
    public class SecondTimer : AbstractTimer
    {
        private float timerDuration;
        private float timer; // ������� ����� �� �������
        private bool isTimerRunning; // ���� ������� �������
        private bool isPause;

        [SerializeField] private GameObject grid;
        [SerializeField] private TMP_Text timerText; // ������ �� ��������� ���� ��� ����������� �������

        private void Start()
        {
            timerDuration = PlayerStats.GetTimePerLevelAmount() / 5;
        }

        private void Update()
        {
            // ���������, ���� �� ������
            if (isTimerRunning && !isPause)
            {
                // ��������� ������
                timer -= Time.deltaTime;

                // ��������� �������� ������� � ������� ��� � ��������� ����
                timerText.text = Mathf.Round(timer).ToString();

                // ���� ����� ������� �������
                if (timer <= 0f)
                {
                    // ��������� ������
                    grid.SetActive(false);

                    // ������������� ������
                    isTimerRunning = false;

                    timerText.text = string.Empty;
                }
            }
        }

        public override void Pause() => isPause = !isPause;

        // ����� ��� ������� �������
        public void StartTimer()
        {
            // ������������� ��������� ����� ������� � ��������� ���
            timer = timerDuration;
            isTimerRunning = true;
        }
    }
}
