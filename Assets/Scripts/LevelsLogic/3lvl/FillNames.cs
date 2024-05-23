using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FillNames : MonoBehaviour
{
    public TMP_Text[] nameTextElements;

    public string[] names = { "Alice", "Bob", "Charlie", "Diana", "Edward", "Fiona" };

    void Start()
    {
        ShuffleNames();
        DisplayNames();
    }
    
    void ShuffleNames()
    {
        System.Random random = new System.Random();
        for (int i = names.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            string temp = names[i];
            names[i] = names[j];
            names[j] = temp;
        }
    }

    void DisplayNames()
    {
        int count = Mathf.Min(names.Length, nameTextElements.Length);

        for (int i = 0; i < count; i++)
        {
            nameTextElements[i].text = names[i];
        }
    }
}
