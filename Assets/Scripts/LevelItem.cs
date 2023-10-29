using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelTypeText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Image levelImageRenderer;
    [SerializeField] private LevelType levelType;
    [SerializeField] private Sprite levelImage;
    void Start()
    {
        levelImageRenderer.sprite = levelImage;
        levelTypeText.SetText(levelType.ToString());
        highScoreText.SetText(HighScoreManager.GetHighScore(levelType).ToString());
    }

    public void OnLevelPlayClick()
    {
        SceneManager.LoadScene(levelType.ToString());
    }
}
