using UnityEngine;

public static class PlayerStats
{
    private static int Money { get; set; }
    public static int LevelsCompletedNumber { get; set; }
    public static int[] UpgradesPurchasedNumber { get; set; }
    public static int  TimePerLevelAmount { get; set; }
    private const string moneyKey = "money"; 

    public static void LevelCompleted(int numberLevel)
    {
        Money += 100;
        if (LevelsCompletedNumber < numberLevel)
            LevelsCompletedNumber++;
        PlayerPrefs.SetInt("levelsCompletedNumber", LevelsCompletedNumber);
        PlayerPrefs.SetInt(moneyKey, Money);
        PlayerPrefs.Save();
    }

    public static int GetMoney()
    {
        if (PlayerPrefs.HasKey(moneyKey))
            Money = PlayerPrefs.GetInt(moneyKey);
        return Money;
    }
}
