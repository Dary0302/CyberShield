using System.Globalization;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject result;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private float timeStart = 30;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject secondtimer;
    [SerializeField] private GameObject grid;

    public bool timerStop;

    void Start()
    {
        timerText.text = timeStart.ToString(CultureInfo.InvariantCulture);
    }

    void Update()
    {
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
}
