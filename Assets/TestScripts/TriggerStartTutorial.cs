using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStartTutorial : MonoBehaviour
{
    public List<GameObject> objectsToActivate = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TutorialManager.Instance.TutorialStart(objectsToActivate);
    }

}
