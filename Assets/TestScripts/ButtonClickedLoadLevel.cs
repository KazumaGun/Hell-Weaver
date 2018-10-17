using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClickedLoadLevel : MonoBehaviour
{
    public string levelName;
    

	// Use this for initialization
	void Start ()
    {
        if (GetComponent<Button>())
            this.GetComponent<Button>().onClick.AddListener(delegate { LoadLevel(); });
        else
            Debug.LogWarning("Object is not a button: " + gameObject.name, gameObject);
	}


    void LoadLevel()
    {
        SceneManager.LoadScene(levelName); //will take int (build setting) or name of the level PUT LEVEL NAME HERE

    }


	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
