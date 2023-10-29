using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUIManager : MonoBehaviour
{
    public GameObject playerHudUI;
    public GameObject pauseMenuUI;
    public GameObject gameEndedUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameEndedScoreText;
    public TextMeshProUGUI gameEndedHighScoreText;
    public TextMeshProUGUI playerSpeedMultiplierText;
    public static PlayerUIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void FixedUpdate()
    {
        scoreText.SetText(GameManager.Instance.GetScore().ToString());
        playerSpeedMultiplierText.SetText(GameManager.Instance.GetPlayerSpeedMultiplier().ToString() + "x Speed");
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LastChangeBtnClicked()
    {

    }
    public void GameEnded()
    {
        gameEndedUI.SetActive(true);
        gameEndedScoreText.SetText(GameManager.Instance.GetScore().ToString());
        gameEndedHighScoreText.SetText(HighScoreManager.GetHighScore(GameManager.Instance.levelType).ToString());
    }
}
