using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeSP : MonoBehaviour
{
    public GameObject Spike;

    void Start()
    {
        Instantiate(Spike, transform.position, Quaternion.identity);
    }
}
