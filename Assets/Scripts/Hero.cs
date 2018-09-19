//KAZ WALSH\\
//PLAYER SCRIPT\\
//CONTAINS MOVEMENT, JUMPING


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Rigidbody2D heroRigidbody;

    public float heroSpeed;
    public float heroJump;

    void Start()
    {
        //Get rigid body at start of game\\
        heroRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        heroRigidbody.velocity = (Vector2.right * heroSpeed); //Only want the player to move a constant speed, not messing with Y value\\

        //JUMPING\\
        if (Input.GetMouseButtonDown(1))
        {
            heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, heroJump); //Y is the hero jumping\\
            //heroRigidbody.AddForce(Vector2.up * heroJump);
            Debug.Log("Jump!");
        }
    }


}
