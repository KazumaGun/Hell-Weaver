using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] levelSpawnPoints;
    private float levelCountdown;
    public float levelSpawnTime;

    private void Update()
    {
        if (levelCountdown <= 0)
        {
            int SP = Random.Range(0, levelSpawnPoints.Length);
            Instantiate(levelSpawnPoints[SP], transform.position, Quaternion.identity);
            levelCountdown = levelSpawnTime;
        }
        else
        {
            levelCountdown -= Time.deltaTime;
        }

    }
}
