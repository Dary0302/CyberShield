using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillButton : MonoBehaviour
{
    string[] i = FillNames.CorrectNames;
    string[] j = FillNames.WrongNames;
    public Button[] buttons;
    

    void Start()
    {
        FillButtonsWithRandomText();
    }

    void FillButtonsWithRandomText()
    {
        System.Random random = new System.Random();

        foreach (Button button in buttons)
        {
            string randomText1 = i[random.Next(i.Length)];
            string randomText2 = j[random.Next(j.Length)];

            var k = random.Next(0, 2);

            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

            if (buttonText != null)
            {
                if (k == 0)
                {
                    buttonText.text = $"{randomText1}";
                }
                else
                {
                    buttonText.text = $"{randomText2}";
                }
            }
            else
            {
                Debug.LogWarning("Button does not have a Text component");
            }
        }
    }
}
