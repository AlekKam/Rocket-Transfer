using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 spawnArea = new Vector3(50, 50, 50);
    public int numberOfObstacles = 10;

    private void Start()
    {
        for (int i = 0; i < numberOfObstacles; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );
            Quaternion spawnRotation = Quaternion.Euler(
                0,
                Random.Range(0, 360),
                0
            );
            Instantiate(obstaclePrefab, spawnPosition, spawnRotation);
        }
    }
}