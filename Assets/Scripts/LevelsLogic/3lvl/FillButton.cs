using LevelsLogic._3lvl;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FillButton : MonoBehaviour, IPointerClickHandler
{
    private readonly string[] correctNames = FillNames.CorrectNames;
    private readonly string[] wrongNames = FillNames.WrongNames;
    [SerializeField] private Camera cameraToUse;
    [SerializeField] private TMP_Text request;
    [SerializeField] private HealthPointsManager healthPointsManager;
    [SerializeField] private ScoreCounter scoreCounter;

    private void Start()
    {
        FillButtonsWithRandomText();
    }

    private void FillButtonsWithRandomText()
    {
        /*var buttonText = buttons[0].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = correctNames[0];
        buttons[0].onClick.AddListener(healthPointsManager.WrongAnswer);*/

        var random = new System.Random();

        var indexCorrectName = 1;
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
                request.text = request.text.Insert(i, wrongNames[indexWrongName]);
                /*var wrongName = indexWrongName;
                button.onClick.AddListener(() => scoreCounter.CheckName(wrongNames[wrongName]));

                buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = wrongNames[indexWrongName];*/
                indexWrongName++;
            }
            else
            {
                request.text = request.text.Insert(i, $"<color=#F18F00><link=\"Correct\">{correctNames[indexCorrectName]}</link></color>");
                /*button.onClick.AddListener(healthPointsManager.WrongAnswer);

                buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = correctNames[indexCorrectName];*/
                indexCorrectName++;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var mousePosition = new Vector3(eventData.position.x, eventData.position.y, 0);
        var linkTaggedText = TMP_TextUtilities.FindIntersectingLink(request, mousePosition, cameraToUse);

        if (linkTaggedText != -1)
        {
            var linkInfo = request.textInfo.linkInfo[linkTaggedText];
            Debug.Log("Success");
        }
        Debug.Log("Success1");
    }
}