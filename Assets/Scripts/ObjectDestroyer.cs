using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] private float distanceToDestory = 50f;
    private Transform player;
    void Start()
    {
        player = GameManager.Instance.player.transform;
    }
    void Update()
    {
        if (player.position.x - distanceToDestory > transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
