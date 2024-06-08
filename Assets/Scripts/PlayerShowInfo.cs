using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShowInfo : MonoBehaviour
{
    [SerializeField] private GameObject levelUpNotification;
    [SerializeField] private TMP_Text levelUpNotificationText;
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
        
        PlayerStats.UpdateOfficeLevel();

        levelUpNotificationText.text = $"Ваш текущий уровень офиса {PlayerStats.GetOfficeLevel()}<br>Время на прохождение уровня увеличено до: {PlayerStats.GetTimePerLevelAmount()} секунд<br>Количество ваших жизней также увеличено до: {PlayerStats.GetQuantityHealthPoints()}";
        levelUpNotification.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        hideLevelUpNotificationButton.onClick.RemoveAllListeners();
    }
}
