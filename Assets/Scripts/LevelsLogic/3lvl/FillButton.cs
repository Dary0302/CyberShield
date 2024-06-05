using LevelsLogic._3lvl;
using TMPro;
using UnityEngine;

public class FillButton : MonoBehaviour
{
    private readonly string[] correctNames = FillNames.CorrectNames;
    private readonly string[] wrongNames = FillNames.WrongNames;
    [SerializeField] private RequestClickCheck requestClickCheck;
    [SerializeField] private TMP_Text request;
    [SerializeField] private HealthPointsManager healthPointsManager;
    [SerializeField] private ScoreCounter scoreCounter;

    private void Start()
    {
        FillButtonsWithRandomText();
        requestClickCheck.Initialize(request);
        requestClickCheck.LinkedWordClicked.AddListener(CheckLinkedWord);
    }

    private void CheckLinkedWord(string linkId, string linkText)
    {
        if (linkId == "Correct")
        {
            healthPointsManager.WrongAnswer();
        }
        else if (linkId == "Wrong")
        {
            scoreCounter.CheckName(linkText);
        }
    }

    private void FillButtonsWithRandomText()
    {
        var random = new System.Random();

        var indexCorrectName = 0;
        var indexWrongName = 0;

        for (var i = 0; i < request.text.Length; i++)
        {
            if (request.text[i] != '-')
                continue;

            request.text = request.text[..i] + request.text[(i + 1)..^1];
            var randomNumber = random.Next(0, 2);

            if (indexCorrectName == correctNames.Length)
                randomNumber = 0;

            if (indexWrongName == wrongNames.Length)
                randomNumber = 1;

            if (randomNumber == 0)
            {
                request.text = request.text.Insert(i, $"<link=\"Wrong\"><color=#F18F00>{wrongNames[indexWrongName]}</color></link>");
                indexWrongName++;
            }
            else
            {
                request.text = request.text.Insert(i, $"<link=\"Correct\"><color=#F18F00>{correctNames[indexCorrectName]}</color></link>");
                indexCorrectName++;
            }
        }
    }
}