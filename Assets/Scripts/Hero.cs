//KAZ WALSH\\
//PLAYER SCRIPT\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Rigidbody2D heroRigidBody2D;
    public float heroSpeed = 2.0f;

    public Vector3 myHero;

	// Use this for initialization
	void Start ()
    {
        myHero = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myHero = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            myHero.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, myHero, heroSpeed * Time.deltaTime);
    }
}
