using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace LevelsLogic
{
    public class OrdinaryTimer : AbstractTimer
    {
        [SerializeField] private TMP_Text textTime;
        private float timeStart;
        private bool isPause;

        public event Action GameLose;
        public bool timerStop;

        private void Start()
        {
            timeStart = PlayerStats.GetTimePerLevelAmount();
            textTime.text = timeStart.ToString(CultureInfo.InvariantCulture);
        }
        
        private void Update()
        {
            if (isPause)
                return;

            if (timeStart <= 0)
            {
                GameLose?.Invoke();
            }
            else if (!timerStop)
            {
                timeStart -= Time.deltaTime;
                textTime.text = Mathf.Round(timeStart).ToString(CultureInfo.InvariantCulture);
            }
        }

        public override void Pause() => isPause = !isPause;
    }
}