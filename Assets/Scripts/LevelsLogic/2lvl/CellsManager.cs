using System.Text;
using TMPro;
using UnityEngine;

public class CellsManager : MonoBehaviour
{
    [SerializeField] private TextCell[] textCells;
    [SerializeField] private string answer;
    [SerializeField] private GameObject resultMenu;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private Timer2 timer2;

    private void Start()
    {
        foreach (var textCell in textCells)
        {
            textCell.TextChanged += OnTextChanged;
        }
    }

    private void OnTextChanged()
    {
        var result = new StringBuilder();
        
        foreach (var textCell in textCells)
        {
            result.Append(textCell.GetCurrentText());
        }
        
        if (result.ToString() != answer)
            return;
        
        PlayerStats.LevelCompleted(2);
        timer2.timerStop = true;
        resultText.text = "Уровень пройден!";
        resultMenu.SetActive(true);
    }
    
    private void OnDestroy()
    {
        foreach (var textCell in textCells)
        {
            textCell.TextChanged -= OnTextChanged;
        }
    }
}
