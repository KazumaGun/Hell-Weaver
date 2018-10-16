using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScroller : MonoBehaviour
{

    public float pathSpeed;
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 offset = new Vector2(Time.time * pathSpeed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
