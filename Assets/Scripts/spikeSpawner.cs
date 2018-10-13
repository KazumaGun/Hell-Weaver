using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeSpawner : MonoBehaviour
{

    public GameObject[] spikeSpawnPoints;
    private float spikeCountdown;
    public float spikeSpawnTime;

    private void Update()
    {
        if (spikeCountdown <= 0)
        {
            int SP = Random.Range(0, spikeSpawnPoints.Length);
            Instantiate(spikeSpawnPoints[SP], transform.position, Quaternion.identity);
            spikeCountdown = spikeSpawnTime;
        }
        else
        {
            spikeCountdown -= Time.deltaTime;
        }

    }
}
