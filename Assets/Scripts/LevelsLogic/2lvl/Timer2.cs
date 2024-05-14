using System.Globalization;
using LevelsLogic;
using TMPro;
using UnityEngine;

public class Timer2 : AbstractTimer
{
    [SerializeField] private GameObject result;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private float timeStart = 30;
    [SerializeField] private TMP_Text timerText;
    private bool isPause;

    public bool timerStop;

    void Start()
    {
        timerText.text = timeStart.ToString(CultureInfo.InvariantCulture);
    }

    void Update()
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