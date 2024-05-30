using UnityEngine;
using TMPro;

public class FillNames : MonoBehaviour
{
    public TMP_Text[] nameTextElements;

    public static string[] CorrectNames = {"Roman", "Anna", "Bob", "Petr", "Ivan", "Oleg"};
    public static string[] WrongNames = {"xx", "oo"};

    void Start()
    {
        ShuffleNames(CorrectNames);
        ShuffleNames(WrongNames);
        DisplayNames();
    }

    void ShuffleNames(string[] names)
    {
        var random = new System.Random();
        for (var i = names.Length - 1; i > 0; i--)
        {
            var j = random.Next(0, i + 1);
            (names[j], names[i]) = (names[i], names[j]);
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
