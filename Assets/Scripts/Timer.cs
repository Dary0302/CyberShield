using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart = 30;
    public Text timerText;

    void Start()
    {
        timerText.text = timeStart.ToString();
    }

    void Update()
    {
        if (timeStart <= 0)
        {
            SceneManager.LoadScene("Desktop");
        }
        else
        {
            timeStart -= Time.deltaTime;
            timerText.text = Mathf.Round(timeStart).ToString();
        }
    }
}
