using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextCell : MonoBehaviour
{
    public event Action TextChanged; 
    [SerializeField] private TMP_Text text;
    [SerializeField] private string[] strings;
    [SerializeField] private Button button;
    private int index;
    
    public void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        text.text = strings[index++];
        if (index == strings.Length)
            index = 0;
        TextChanged?.Invoke();
    }

    public string GetCurrentText() => text.text;

    private void OnDestroy() => button.onClick.RemoveListener(OnButtonClicked);
}
