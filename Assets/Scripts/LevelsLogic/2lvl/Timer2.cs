using System.Globalization;
using LevelsLogic;
using TMPro;
using UnityEngine;

public class Timer2 : AbstractTimer
{
    [SerializeField] private GameObject result;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text timerText;
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