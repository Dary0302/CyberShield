using System.Globalization;
using TMPro;
using UnityEngine;

namespace LevelsLogic._1lvl
{
    public class Timer : AbstractTimer
    {
        [SerializeField] private GameObject result;
        [SerializeField] private TMP_Text resultText;
        [SerializeField] private float timeStart = 30;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private GameObject secondtimer;
        [SerializeField] private GameObject grid;
        private bool isPause;
    
        public bool timerStop;

        private void Start()
        {
            timerText.text = timeStart.ToString(CultureInfo.InvariantCulture);
        }

        private void Update()
        {
            if (isPause)
                return;
            if (timeStart <= 0)
            {
                secondtimer.SetActive(false);
                grid.SetActive(false);

                resultText.text = "Уровень провален!";
                result.gameObject.SetActive(true);
            }
            else if (!timerStop)
            {
                timeStart -= Time.deltaTime;
                timerText.text = Mathf.Round(timeStart).ToString(CultureInfo.InvariantCulture);
            }
        }

        public override void Pause() => isPause = !isPause;
    }
}
