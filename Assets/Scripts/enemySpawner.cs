using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public GameObject Enemy;
    private float spawnCountdown;
    public float enemySpawnTime;

    private void Update()
    {
        if (spawnCountdown <= 0)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            spawnCountdown = enemySpawnTime;
        }
        else
        {
            spawnCountdown -= Time.deltaTime;
        }
        
    }










}
