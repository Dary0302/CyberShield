using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text money;

    private void Update()
    {
        money.text = PlayerStats.GetMoney().ToString() + '$';
    }
}
