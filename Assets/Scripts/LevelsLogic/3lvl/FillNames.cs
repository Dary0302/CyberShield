using UnityEngine;
using TMPro;

public class FillNames : MonoBehaviour
{
    public string[] CorrectNames = {"Roman", "Anna", "Bob", "Petr", "Ivan", "Oleg", "Polina", "Denis", "Sergey", "Yusif", "Kirill", "Alex", "Max", "Artem"};
    [SerializeField] private int countCorrectNamesInGame; 
    public string[] WrongNames = {"Dima", "Artur", "Fedor", "Semyon", "Timur", "Yura", "Ulyana"};
    [SerializeField] private int countWrongNamesInGame; 
    public TMP_Text[] nameTextElements;

    private void Start()
    {
        ShuffleNames(ref CorrectNames, countCorrectNamesInGame);
        ShuffleNames(ref WrongNames, countWrongNamesInGame);
        DisplayNames();
    }

    private static void ShuffleNames(ref string[] names, int countNames)
    {
        var random = new System.Random();
        for (var i = names.Length - 1; i > 0; i--)
        {
            var j = random.Next(0, i + 1);
            (names[j], names[i]) = (names[i], names[j]);
        }
        names = names[..countNames];
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
