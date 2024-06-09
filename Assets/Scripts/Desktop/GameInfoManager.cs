using TMPro;
using UnityEngine;

namespace Desktop
{
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

        public void FillGameInfo()
        {
            currentOfficeLevel.text = $"Уровень офиса: <color=#D34B06>{PlayerStats.GetOfficeLevel()}</color>";
            currentTimeOnLevel.text = $"Время на уровень: <color=#D34B06>{PlayerStats.GetTimePerLevelAmount()}</color>";
            currentHearthOnLevel.text = $"Количество жизней: <color=#D34B06>{PlayerStats.GetQuantityHealthPoints()}</color>";
            var countItemsPurchased = PlayerStats.GetCountItemsPurchased() % 2 == 0 ? 2 : 1;
            var item = countItemsPurchased % 2 == 0 ? "предмета" : "предмет";
            countItemForNewLevel.text = $"До нового уровня: <color=#D34B06>{countItemsPurchased}</color> {item}";
        }
    }
}