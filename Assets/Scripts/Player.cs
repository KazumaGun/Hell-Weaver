//KAZ WALSH\\
//PLAYER SCRIPT\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigidBody2D;
    public float playerSpeed = 2.0f;

    public Vector3 moving;

	// Use this for initialization
	void Start ()
    {
        moving = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moving = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, moving, playerSpeed * Time.deltaTime);
    }
}
