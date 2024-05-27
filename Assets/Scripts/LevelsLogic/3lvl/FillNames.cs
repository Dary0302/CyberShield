using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FillNames : MonoBehaviour
{
    public TMP_Text[] nameTextElements;

    public static string[] CorrectNames = {"Roman", "Anna", "Bob", "Petr", "Ivan", "Oleg"};
    public static string[] WrongNames = {"xxxxxx", "oooooo"};

    void Start()
    {
        ShuffleNames();
        DisplayNames();
    }

    void ShuffleNames()
    {
        var random = new System.Random();
        for (var i = CorrectNames.Length - 1; i > 0; i--)
        {
            var j = random.Next(0, i + 1);
            (CorrectNames[j], CorrectNames[i]) = (CorrectNames[i], CorrectNames[j]);
        }
    }

    void DisplayNames()
    {
        var count = Mathf.Min(CorrectNames.Length, nameTextElements.Length);

        for (var i = 0; i < count; i++)
        {
            nameTextElements[i].text = CorrectNames[i];
        }
    }
}
