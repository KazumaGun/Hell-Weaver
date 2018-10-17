using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSP : MonoBehaviour
{
    public GameObject Level;

    void Start()
    {
        Instantiate(Level, transform.position, Quaternion.identity);
    }
}
