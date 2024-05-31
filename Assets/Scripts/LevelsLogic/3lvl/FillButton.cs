using System.Linq;
using LevelsLogic._3lvl;
using TMPro;
using UnityEngine;

public class FillButton : MonoBehaviour
{
    private readonly string[] correctNames = FillNames.CorrectNames;
    private readonly string[] wrongNames = FillNames.WrongNames;
    public UnityEngine.UI.Button[] buttons;
    [SerializeField] private HealthPointsManager healthPointsManager;
    [SerializeField] private ScoreCounter scoreCounter;

    private void Start()
    {
        FillButtonsWithRandomText();
    }

    private void FillButtonsWithRandomText()
    {
        var buttonText = buttons[0].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = correctNames[0];
        buttons[0].onClick.AddListener(healthPointsManager.WrongAnswer);

        var random = new System.Random();

        var indexCorrectName = 1;
        var indexWrongName = 0;

        foreach (var button in buttons.Skip(1))
        {
            var randomNumber = random.Next(0, 2);

            if (indexCorrectName == correctNames.Length)
                randomNumber = 0;

            if (indexWrongName == wrongNames.Length)
                randomNumber = 1;

            if (randomNumber == 0)
            {
                var wrongName = indexWrongName;
                button.onClick.AddListener(() => scoreCounter.CheckName(wrongNames[wrongName]));

                buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = wrongNames[indexWrongName];
                indexWrongName++;
            }
            else
            {
                button.onClick.AddListener(healthPointsManager.WrongAnswer);

                buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = correctNames[indexCorrectName];
                indexCorrectName++;
            }
        }
    }
}