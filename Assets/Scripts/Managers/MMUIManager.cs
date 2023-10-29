using TMPro;
using UnityEngine;

public class MMUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    void Start()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlayAudio(Sound.MainMenu);
    }
    public void OnPlayerExitBtnClicked()
    {
        Application.Quit();
    }
    private void FixedUpdate()
    {
        coinText.SetText(CoinManager.GetTotalCoins().ToString());
    }
}
