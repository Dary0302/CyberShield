using UnityEngine;

public static class PlayerStats
{
    private static int Money { get; set; }
    public static int LevelsCompletedNumber { get; private set; }
    public static int[] UpgradesPurchasedNumber { get; set; }
    public static int  TimePerLevelAmount { get; set; }
    private const string MoneyKey = "money"; 

    public static void LevelCompleted(int numberLevel)
    {
        Money += 100;
        if (LevelsCompletedNumber < numberLevel)
            LevelsCompletedNumber++;
        PlayerPrefs.SetInt("levelsCompletedNumber", LevelsCompletedNumber);
        PlayerPrefs.SetInt(MoneyKey, Money);
        PlayerPrefs.Save();
    }

    public static int GetMoney()
    {
        if (PlayerPrefs.HasKey(MoneyKey))
            Money = PlayerPrefs.GetInt(MoneyKey);
        return Money;
    }
}
