using UnityEngine;

public static class PlayerStats
{
    public static int MaxHealthPoints => 4;
    private static int money = 10000; // Заменить на ноль
    private static int quantityHealthPoints = 1;
    private static int levelsCompletedNumber;
    private static int timePerLevelAmount = 30;
    private static int officeLevel = 1;
    private static int countItemsPurchased;
    private const string MoneyKey = "money";
    private const string HealthPointsKey = "healthPoints";
    private const string TimePerLevelAmountKey = "timePerLevelAmount";
    private const string LevelsCompletedNumberKey = "levelsCompletedNumber";
    private const string OfficeLevelKey = "levelsCompletedNumber";
    private const string CountItemsPurchasedKey = "countItemsPurchased";

    public static void LevelCompleted(int numberLevel)
    {
        money += 100;
        if (levelsCompletedNumber < numberLevel)
            levelsCompletedNumber++;
        PlayerPrefs.SetInt(LevelsCompletedNumberKey, levelsCompletedNumber);
        PlayerPrefs.SetInt(MoneyKey, money);
        PlayerPrefs.Save();
    }

    public static int GetLevelsCompletedNumber()
    {
        if (PlayerPrefs.HasKey(LevelsCompletedNumberKey))
            levelsCompletedNumber = PlayerPrefs.GetInt(LevelsCompletedNumberKey);
        return levelsCompletedNumber;
    }

    public static bool TryItemBuy(string nameItem, int price)
    {
        if (price > money || PlayerPrefs.HasKey(nameItem))
            return false;

        money -= price;
        PlayerPrefs.SetInt(nameItem, 1);
        PlayerPrefs.SetInt(MoneyKey, money);
        PlayerPrefs.Save();
        return true;
    }

    public static int GetMoney()
    {
        if (PlayerPrefs.HasKey(MoneyKey))
            money = PlayerPrefs.GetInt(MoneyKey);
        return money;
    }

    public static int GetQuantityHealthPoints()
    {
        if (PlayerPrefs.HasKey(HealthPointsKey))
            quantityHealthPoints = PlayerPrefs.GetInt(HealthPointsKey);
        return quantityHealthPoints;
    }

    public static void UpdateQuantityHealthPoints()
    {
        if (PlayerPrefs.HasKey(HealthPointsKey))
            quantityHealthPoints = PlayerPrefs.GetInt(HealthPointsKey);

        if (quantityHealthPoints == MaxHealthPoints)
            return;

        quantityHealthPoints++;
        PlayerPrefs.SetInt(HealthPointsKey, quantityHealthPoints);
        PlayerPrefs.Save();
    }

    public static int GetTimePerLevelAmount()
    {
        if (PlayerPrefs.HasKey(TimePerLevelAmountKey))
            timePerLevelAmount = PlayerPrefs.GetInt(TimePerLevelAmountKey);

        return timePerLevelAmount;
    }

    public static void UpdateTimePerLevelAmount()
    {
        if (PlayerPrefs.HasKey(TimePerLevelAmountKey))
            timePerLevelAmount = PlayerPrefs.GetInt(TimePerLevelAmountKey);
        timePerLevelAmount += 5;
    }

    public static void SuccessItemBought(ShopItemView shopItemView)
    {
        if (PlayerPrefs.HasKey(CountItemsPurchasedKey))
            countItemsPurchased = PlayerPrefs.GetInt(CountItemsPurchasedKey);

        countItemsPurchased++;
        if (countItemsPurchased / 2 > GetOfficeLevel() - 1)
            UpdateOfficeLevel();
        PlayerPrefs.SetInt(CountItemsPurchasedKey, countItemsPurchased);
        PlayerPrefs.Save();
    }

    public static int GetOfficeLevel()
    {
        if (PlayerPrefs.HasKey(OfficeLevelKey))
            officeLevel = PlayerPrefs.GetInt(OfficeLevelKey);

        return officeLevel;
    }

    private static void UpdateOfficeLevel()
    {
        if (PlayerPrefs.HasKey(OfficeLevelKey))
            officeLevel = PlayerPrefs.GetInt(OfficeLevelKey);
        officeLevel++;
        Debug.Log(officeLevel);
    }
}