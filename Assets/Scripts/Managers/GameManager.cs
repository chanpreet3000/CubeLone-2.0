using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public LevelType levelType;
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject playerDeathPrefab = null;
    [SerializeField] private Vector3 playerStartPosition = Vector3.zero;
    [SerializeField] private float scoreMultiplier = 1f;
    [SerializeField] private float initialPlayerSpeedMultiplier = 1f;
    [SerializeField] private float playerSpeedMultiplierIncrement = 0.05f;
    [SerializeField] private float playerSpeedMultiplierIncrementInterval = 10f;
    public static GameManager Instance;
    private bool playerDead = false;
    [HideInInspector] public GameObject player;
    private float localTime;
    private void Awake()
    {
        Instance = this;
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 144;
        Time.timeScale = 1;
        GameObject obj = Instantiate(playerPrefab, playerStartPosition, Quaternion.identity);
        player = obj.GetComponentInChildren<PlayerMovement>().gameObject;
        localTime = 0f;
    }
    private void Update()
    {
        if (playerDead) return;
        localTime += Time.deltaTime;
        if (localTime >= playerSpeedMultiplierIncrementInterval)
        {
            localTime = 0;
            IncreaseScoreMultiplier();
        }
    }
    private void Start()
    {
        PlayerUIManager.Instance.playerHudUI.SetActive(true);
        if (levelType == LevelType.NeonNexus)
        {
            AudioManager.Instance.PlayAudio(Sound.NeonNexus);
        }
        else if (levelType == LevelType.AbyssalOdyssey)
        {
            AudioManager.Instance.PlayAudio(Sound.AbyssalOdyssey);
        }
        else if (levelType == LevelType.CosmicCascade)
        {
            AudioManager.Instance.PlayAudio(Sound.CosmicCascade);
        }
        else if (levelType == LevelType.InfernoMatrix)
        {
            AudioManager.Instance.PlayAudio(Sound.InfernoMatrix);
        }
    }
    public void PlayerDead()
    {
        if (playerDead) return;
        HighScoreManager.SetHighScore(levelType, GetScore());
        playerDead = true;
        player.SetActive(false);
        Instantiate(playerDeathPrefab, player.transform.position, Quaternion.identity);
        Invoke("LevelFailedUI", 2f);
    }
    private void LevelFailedUI()
    {
        PlayerUIManager.Instance.GameEnded();
    }
    public int GetScore()
    {
        return (int)((player.transform.position.x - playerStartPosition.x) * scoreMultiplier);
    }
    private void IncreaseScoreMultiplier()
    {
        initialPlayerSpeedMultiplier += playerSpeedMultiplierIncrement;
    }
    public float GetPlayerSpeedMultiplier()
    {
        return initialPlayerSpeedMultiplier;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerStartPosition, 0.5f);
    }
}
