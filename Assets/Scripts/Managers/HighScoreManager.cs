using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static int GetHighScore(LevelType levelType)
    {
        return PlayerPrefs.GetInt(levelType.ToString(), 0);
    }
    public static void SetHighScore(LevelType levelType, int score)
    {
        int currentHighScore = GetHighScore(levelType);
        PlayerPrefs.SetInt(levelType.ToString(), Mathf.Max(currentHighScore, score));
    }
}
