using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    //STATIC WILL BE SHARED AMONGST ALL INSTANCES OF  CLASS

    public static TutorialManager Instance;

    private List<GameObject> activatedObjects = new List<GameObject>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void TutorialStart(List<GameObject> gameObjectsToActivate)
    {
        //ACTIVE THE UI ELEMENTS

        foreach(GameObject gObject in gameObjectsToActivate)
        {
            if (gObject.activeSelf == false)
                gObject.SetActive(true);

            activatedObjects.Add(gObject);
        }


        //PAUSE THE GAME

        Time.timeScale = 0;
    }

    public void TutorialEnd()
    {
        foreach (GameObject gObject in activatedObjects)
        {
            if (gObject.activeSelf == true)
                gObject.SetActive(false);
        }
        //RESUME GAME
        Time.timeScale = 1;

        //CLEAR LIST
        activatedObjects.Clear();

    }
}
