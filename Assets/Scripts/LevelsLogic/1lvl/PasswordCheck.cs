using System;
using LevelsLogic;
using LevelsLogic._1lvl;
using UnityEngine;
using TMPro;

public class PasswordCheck : MonoBehaviour
{
    [SerializeField] private GameObject result;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_InputField tmpInputField;
    [SerializeField] private Timer timer;
    [SerializeField] private HealthPointsManager healthPointsManager;
    [SerializeField] private GameLose gameLose;
    [SerializeField] private string validCharacters = "G734#26H";
    private bool isWin;

    private void Start()
    {
        healthPointsManager.GameLose += gameLose.LoseGame;
    }

    private void Update()
    {
        ValidateInput();
    }
    private void ValidateInput()
    {
        if (isWin)
            return;
        
        var inputValue = tmpInputField.text;

        if (inputValue.Length != validCharacters.Length)
            return;

        if (inputValue.Length > validCharacters.Length || inputValue != validCharacters)
        {
            tmpInputField.text = string.Empty;
            healthPointsManager.WrongAnswer();
            return;
        }
        
        isWin = true;
        timer.timerStop = true;
        resultText.text = "Уровень пройден!";
        result.gameObject.SetActive(true);
        PlayerStats.LevelCompleted(1);
    }

    private void OnDestroy()
    {
        healthPointsManager.GameLose -= gameLose.LoseGame;
    }
}