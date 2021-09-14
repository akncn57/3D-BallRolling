using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;

    private void Start()
    {
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(0, 3);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstacle, spawnPoint.position, Quaternion.identity, transform);
    }
}
