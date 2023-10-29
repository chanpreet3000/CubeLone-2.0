using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinAmount = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        CoinManager.AddCoins(coinAmount);
        AudioManager.Instance.PlayAudio(Sound.Coin);
        Destroy(gameObject);
    }
}
