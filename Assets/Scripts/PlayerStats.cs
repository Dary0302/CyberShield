using UnityEngine;

public static class PlayerStats
{
    private static int money;
    private static int quantityHealthPoints = 1;
    private static int levelsCompletedNumber;
    private static int timePerLevelAmount = 30;
    private const string MoneyKey = "money";
    private const string HealthPointsKey = "healthPoints";
    private const string TimePerLevelAmountKey = "timePerLevelAmount";
    private const string LevelsCompletedNumber = "levelsCompletedNumber";

    public static void LevelCompleted(int numberLevel)
    {
        money += 100;
        if (levelsCompletedNumber < numberLevel)
            levelsCompletedNumber++;
        PlayerPrefs.SetInt(LevelsCompletedNumber, levelsCompletedNumber);
        PlayerPrefs.SetInt(MoneyKey, money);
        PlayerPrefs.Save();
    }

    public static int GetLevelsCompletedNumber()
    {
        if (PlayerPrefs.HasKey(LevelsCompletedNumber))
            levelsCompletedNumber = PlayerPrefs.GetInt(LevelsCompletedNumber);
        return levelsCompletedNumber;
    }

    public static void ItemBuy(string nameItem, int price)
    {
        if (price > money || PlayerPrefs.HasKey(nameItem))
            return;

        money -= price;
        PlayerPrefs.SetInt(nameItem, 1);
        PlayerPrefs.SetInt(MoneyKey, money);
        PlayerPrefs.Save();
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
}
