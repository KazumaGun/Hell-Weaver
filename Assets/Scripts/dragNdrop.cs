//KAZ WALSH\\
//DRAG N' DROP SCRIPT\\

//This script allows for the basic function of drag and object somewhere,\\
//and letting it go to drop it in your desired location\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragNdrop : MonoBehaviour
{

    private Vector3 offset;



	void OnMouseDown ()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)); //distance of the object from the camera\\
	}
	
	
	void OnMouseDrag ()
    {
		Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    }
}
