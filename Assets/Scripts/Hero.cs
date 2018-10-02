//KAZ WALSH\\
//PLAYER SCRIPT\\
//CONTAINS MOVEMENT, JUMPING


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    //MOVEMENT\\
    private Rigidbody2D heroRigidbody;
    public float heroSpeed;
    public float heroJump;

    //CHECKING GROUND\\
    public bool isGrounded; //check if true, uncheck if false\\
    public LayerMask thisIsGround; //selection of layers availble\\
    private Collider2D heroCollider;

    //JUMPING TIMER\\
    public float countdown;
    [SerializeField] public float timer;




    void Start()
    {
        //Get rigid body at start of game\\
        heroRigidbody = GetComponent<Rigidbody2D>();

        heroCollider = GetComponent<Collider2D>(); //For checking ground\\
    }





    void Update()
    {



        isGrounded = Physics2D.IsTouchingLayers(heroCollider, thisIsGround); //checks the colliders in a layer\\


        //MOVEMENT\\
        //heroRigidbody.velocity = (Vector2.right * heroSpeed); //Only want the player to move a constant speed, not messing with Y value\\
        heroRigidbody.gameObject.transform.Translate(Vector2.right * heroSpeed * Time.deltaTime);

        //JUMPING\\
        if (Input.GetMouseButton(0))
        {
            Jump(); 
        }

        if(Input.touchCount > 0)
        {
            Jump(); 
        }

        

        
    }

    void Jump()
    {
        //heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, heroJump); //Y is the hero jumping\\
        heroRigidbody.AddForce(Vector2.up * heroJump);
        Debug.Log("Jump!");



        if (isGrounded)
        {
            if (timer < countdown)
            {
                heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, heroJump);
                timer += Time.deltaTime;
            }
        }
        else
        {
            timer = 0;
        }
    }

    protected void OnCollsionEnter(Collision aCollision)
    {
        GameObject aCollisionObject;
        aCollisionObject = aCollision.gameObject;

        //When enemy runs into hero, deactive the hero\\

        Enemy aEnemy;
        aEnemy = aCollisionObject.GetComponent<Enemy>();

        if (aEnemy != null)
        {
            gameObject.SetActive(false);
            print("YOU DIED!!!");
        }
    }
        

}
