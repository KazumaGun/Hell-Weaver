using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *  Place this class on any object you want
 *  to "look" in the direction of the touch. 
 *  
 *  Right axis (x) or Up axis (y) can be chosen 
 *  to be the axis facing the touch location
 *  
 *  Matthew K. Greene
 * 
 * */
public class LookAtTouch : MonoBehaviour {
	
    public enum LookAxis { Right, Up}
    public LookAxis lookAxis; 

	// Update is called once per frame
	void Update () {
        #if UNITY_EDITOR || UNITY_STANDALONE
                MouseLook();
        #endif

        #if UNITY_ANDROID || UNITY_IOS
                TouchLook(); 
        #endif
    }

    void MouseLook()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (lookAxis == LookAxis.Right)
            {
                // Convert mouse position to world position
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // Get angle between this object and the world position
                // https://docs.unity3d.com/ScriptReference/Mathf.Atan2.html
                float angle = Mathf.Atan2(worldPos.y - transform.position.y, worldPos.x - transform.position.x) * Mathf.Rad2Deg;
                // Set rotation of the object
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {
                // Convert mouse position to world position
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // Get angle between this object and the world position
                // https://docs.unity3d.com/ScriptReference/Mathf.Atan2.html
                float angle = Mathf.Atan2(worldPos.y - transform.position.y, worldPos.x - transform.position.x) * Mathf.Rad2Deg;
                // Subtract 90 from the angle so up axis faces world position
                angle -= 90; 
                // Set rotation of the object
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
        
    }

    void TouchLook()
    {
        // Do we have touches?
        if (Input.touchCount > 0)
        {
            // We only need to do this when the touch begins
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (lookAxis == LookAxis.Right)
                {
                    // Convert touch location to world position
                    Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    // Get angle between this object and the world position
                    // https://docs.unity3d.com/ScriptReference/Mathf.Atan2.html
                    float angle = Mathf.Atan2(worldPos.y - transform.position.y, worldPos.x - transform.position.x) * Mathf.Rad2Deg;
                    // Set rotation of the object
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                }
                else
                {
                    // Convert touch location to world position
                    Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    // Get angle between this object and the world position
                    // https://docs.unity3d.com/ScriptReference/Mathf.Atan2.html
                    float angle = Mathf.Atan2(worldPos.y - transform.position.y, worldPos.x - transform.position.x) * Mathf.Rad2Deg;
                    // Subtract 90 from the angle so up axis faces world position
                    angle -= 90;
                    // Set rotation of the object
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                }
            }
        }
    }
}
