using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *  Attach this class to an object if you want
 *  the object's Rigidbody2D velocity to be controlled
 *  by the devices accelerometer. 
 *  
 *  Matthew K. Greene
 * 
 * */
[RequireComponent(typeof(Rigidbody2D))]
public class AccelerometerRigidbodyVelocity : MonoBehaviour {

    public float speed = 10.0f; 

    private Rigidbody2D rig = null;
    private Vector2 velocity = Vector2.zero; 

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>(); 
	}
	
	// Update is called once per frame
	void Update () {
        velocity.x = Input.acceleration.x;
        velocity.y = Input.acceleration.y; 
	}

    void FixedUpdate()
    {
        rig.velocity = velocity * speed; 
    }
}
