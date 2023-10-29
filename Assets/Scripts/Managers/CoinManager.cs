using UnityEngine;
public class CoinManager
{
    private readonly static string COIN_KEY = "COIN_KEY";
    public static int GetTotalCoins()
    {
        return PlayerPrefs.GetInt(COIN_KEY, 0);
    }
    public static void AddCoins(int amount)
    {
        PlayerPrefs.SetInt(COIN_KEY, GetTotalCoins() + amount);
    }
}
