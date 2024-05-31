using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FillNames : MonoBehaviour
{
    public TMP_Text[] nameTextElements;

    public static string[] CorrectNames = {"Roman", "Anna", "Bob", "Petr", "Ivan", "Oleg"};
    public static string[] WrongNames = {"xx", "oo"};

    private void Start()
    {
        ShuffleNames(CorrectNames);
        ShuffleNames(WrongNames);
        DisplayNames();
    }

    private static void ShuffleNames(IList<string> names)
    {
        var random = new System.Random();
        for (var i = names.Count - 1; i > 0; i--)
        {
            var j = random.Next(0, i + 1);
            (names[j], names[i]) = (names[i], names[j]);
        }
    }

    private void DisplayNames()
    {
        var count = Mathf.Min(CorrectNames.Length, nameTextElements.Length);

        for (var i = 0; i < count; i++)
        {
            nameTextElements[i].text = CorrectNames[i];
        }
    }
}
