using UnityEngine;
public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private int totalTiles;
    private Transform player;
    private float newSpawnPoint;
    private float tileSize;
    void Start()
    {
        player = GameManager.Instance.player.transform;
        newSpawnPoint = 0f;
        tileSize = groundPrefab.transform.localScale.x;
    }
    void FixedUpdate()
    {
        if (newSpawnPoint - player.position.x < totalTiles * tileSize)
        {
            Instantiate(groundPrefab, new Vector3(newSpawnPoint, 0, 0), Quaternion.identity, transform);
            newSpawnPoint += tileSize;
        }
    }
}
