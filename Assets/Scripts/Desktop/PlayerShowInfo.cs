using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Desktop
{
    public class PlayerShowInfo : MonoBehaviour
    {
        [SerializeField] private AudioSource notificationSound;
        [SerializeField] private GameInfoManager gameInfoManager;
        [SerializeField] private GameObject levelUpNotification;
        [SerializeField] private TMP_Text infoAboutLevelOffice;
        [SerializeField] private TMP_Text infoAboutLevelTime;
        [SerializeField] private TMP_Text infoAboutLevelHeart;
        [SerializeField] private Button hideLevelUpNotificationButton;

        private void Start()
        {
            hideLevelUpNotificationButton.onClick.AddListener(() => levelUpNotification.gameObject.SetActive(false));
        }

        public void SuccessItemBought(ShopItemView shopItemView)
        {
            var countItemsPurchased = PlayerStats.GetCountItemsPurchased();
        
            countItemsPurchased++;
            PlayerStats.AddItemsPurchased();

            if (countItemsPurchased / 2 <= PlayerStats.GetOfficeLevel() - 1)
                return;
        
            notificationSound.Play();
            PlayerStats.UpdateOfficeLevel();
            gameInfoManager.FillGameInfo();

            infoAboutLevelOffice.text = $"Текущий уровень офиса: <color=#D34B06>{PlayerStats.GetOfficeLevel()}</color>";
            infoAboutLevelTime.text = $"Время на прохождение уровня увеличено до: <color=#D34B06>{PlayerStats.GetTimePerLevelAmount()}</color> секунд";
            infoAboutLevelHeart.text = $"Количество жизней увеличено до: <color=#D34B06>{PlayerStats.GetQuantityHealthPoints()}</color>";
            levelUpNotification.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            hideLevelUpNotificationButton.onClick.RemoveAllListeners();
        }
    }
}
