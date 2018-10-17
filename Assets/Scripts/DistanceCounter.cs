using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] public Transform finish;

    [SerializeField] public Text distanceText;

    private float distance;

    private void Update()
    {
        distance = (finish.transform.position.x - transform.position.x);
        distanceText.text = "Distance till finish: " + distance.ToString("F1") + " meters";

        if (distance <= 0)
        {
            distanceText.text = "Finish!";
        }
    }

}
