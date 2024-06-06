using TMPro;
using UnityEngine;

public class GameInfoManager : MonoBehaviour
{
    [SerializeField] private TMP_Text currentOfficeLevel;
    [SerializeField] private TMP_Text currentTimeOnLevel;
    [SerializeField] private TMP_Text currentHearthOnLevel;
    [SerializeField] private TMP_Text countItemForNewLevel;

    private void Update()
    {
        FillGameInfo();
    }

    private void FillGameInfo()
    {
        currentOfficeLevel.text = $"Уровень офиса: {PlayerStats.GetOfficeLevel()}";
        currentTimeOnLevel.text = $"Время на уровень: {PlayerStats.GetTimePerLevelAmount()}";
        currentHearthOnLevel.text = $"Количество жизней: {PlayerStats.GetQuantityHealthPoints()}";
        countItemForNewLevel.text = $"Количество покупок для нового уровня: {PlayerStats.GetCountItemForNewOfficeLevel()}";
    }
}