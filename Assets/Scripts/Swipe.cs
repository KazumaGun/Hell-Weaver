using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector3 startTouch;   //First touch position\\
    private Vector3 endTouch;   //Last touch position\\
    private float swipeDistance;  //minimum distance for a swipe to be registered\\

                                 
    void Start ()
    {
        //swipeDistance = ;
	}
	
	
	void Update ()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch

            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                startTouch = touch.position;
                endTouch = touch.position;
            }

            else 
            if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                endTouch = touch.position;
            }

            else 
            if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                endTouch = touch.position;  //last touch position. Ommitted if you use list
            }
        }
    }
}
