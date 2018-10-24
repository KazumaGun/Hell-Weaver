using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    public string levelName;


    // Use this for initialization
    void Start()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hero")
        {
            LoadLevel();
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(levelName); //will take int (build setting) or name of the level PUT LEVEL NAME HERE

    }
}
