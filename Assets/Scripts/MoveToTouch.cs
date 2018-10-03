using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *  Place this class on any object you want
 *  to move to the touch location
 *  
 *  Matthew K. Greene
 * 
 * */
public class MoveToTouch : MonoBehaviour {

    public float speed = 2.5f; 

	// Update is called once per frame
	void Update () {
    #if UNITY_EDITOR || UNITY_STANDALONE
            MouseMove();
    #endif

    #if UNITY_ANDROID || UNITY_IOS
            TouchMove(); 
    #endif
    }

    void MouseMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Stop the current movement
            StopCoroutine("MoveToLocation");
            // Convert mouse position to world position
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartCoroutine("MoveToLocation", worldPos); 
        }
    }

    void TouchMove()
    {
        // Do we have touches?
        if (Input.touchCount > 0)
        {
            // We only need to do this when the touch begins
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Stop the current movement
                StopCoroutine("MoveToLocation");
                // Convert touch location to world position
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                StartCoroutine("MoveToLocation", worldPos);
            }
        }
    }

    public IEnumerator MoveToLocation(Vector2 worldPos)
    {
        // Distance between this object and the world position
        float distanceToTarget = Vector2.Distance(transform.position, worldPos); 
        // If we aren't close enough keep moving towards the target
        while(distanceToTarget > .25f)
        {
            transform.position = Vector2.MoveTowards(transform.position, worldPos, speed * Time.deltaTime); 
            yield return null;
        }
    }
}
