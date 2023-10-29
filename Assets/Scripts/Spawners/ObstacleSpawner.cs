using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Obstacle[] obstacles;
    [SerializeField] private int distanceBetweenObstacles = 10;
    [SerializeField] private int totalObstaclesAhead = 6;
    private Transform player;
    private int obstacleSpawnPosition = 10;
    private List<int> obstacleProbabilities;
    private void Start()
    {
        player = GameManager.Instance.player.transform;
        int sum = 0;
        obstacleProbabilities = new List<int>();
        foreach (Obstacle obstacle in obstacles)
        {
            sum += obstacle.spawnProbabilty;
            obstacleProbabilities.Add(sum);
        }
    }
    void Update()
    {
        if (obstacleSpawnPosition - player.position.x < totalObstaclesAhead * distanceBetweenObstacles)
        {
            int obstacleIndex = GetObstacleIndex();
            if (obstacleIndex == -1)
            {
                Debug.LogError("Please add obstacles");
                return;
            }
            float randomZPosition = Random.Range(obstacles[obstacleIndex].spawnPosition.x, obstacles[obstacleIndex].spawnPosition.y);
            Instantiate(obstacles[obstacleIndex].obstaclePrefab, new Vector3(obstacleSpawnPosition, 0.5f, randomZPosition), Quaternion.identity, transform);
            obstacleSpawnPosition += distanceBetweenObstacles;
        }
    }
    private int GetObstacleIndex()
    {
        int lo = 0, hi = obstacleProbabilities.Count - 1;
        int ans = -1;
        int target = Random.Range(0, obstacleProbabilities[^1]);
        while (lo <= hi)
        {
            int mid = (lo + hi + 1) / 2;
            if (obstacleProbabilities[mid] >= target)
            {
                hi = mid - 1;
                ans = mid;
            }
            else
            {
                lo = mid + 1;
            }
        }
        return ans;
    }
}
