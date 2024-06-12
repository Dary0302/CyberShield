using System.Globalization;
using TMPro;
using UnityEngine;

namespace LevelsLogic._1lvl
{
    public class Timer : AbstractTimer
    {
        [SerializeField] private AudioSource gameLoseSound;
        [SerializeField] private GameObject result;
        [SerializeField] private TMP_Text resultText;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private GameObject secondTimer;
        [SerializeField] private GameObject grid;
        private float timeStart;
        private bool isPause;
    
        public bool timerStop;

        private void Start()
        {
            timeStart = PlayerStats.GetTimePerLevelAmount();
            timerText.text = timeStart.ToString(CultureInfo.InvariantCulture);
        }

        private void Update()
        {
            if (isPause)
                return;
            if (timeStart <= 0)
            {
                secondTimer.SetActive(false);
                grid.SetActive(false);

                gameLoseSound.Play();
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
