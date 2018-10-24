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
    public bool floating;


    //POWER UPS\\
    [Header("Power-Ups")]
    [SerializeField] bool hermesShoe;
    [SerializeField] private float hermesSpeed;
    [SerializeField] bool aPomegranate;
    [SerializeField] Collider2D pomegranateCollider;
    [SerializeField] private TutorialScroller tutScroll;


    //VINE WHIP\\
    
    [SerializeField] private GameObject flowerBullet;
    [SerializeField] private float flowerDist;
    [SerializeField] private float m_CooldownDur = 1.0f;
    [SerializeField] private float m_CooldownTimer = 0.0f;

    //HERO HEALTH\\
    [SerializeField] public int heroHealth = 3;


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
            if (!hermesShoe)
            {
            tutScroll.tutorialSpeed = heroSpeed;
            }
            else
            {
            tutScroll.tutorialSpeed = hermesSpeed;
            }


            //JUMPING\\
            if (Input.GetMouseButton(0))
            {
                Jump();
            }
             if (Input.GetMouseButtonUp(0))
            {
                floating = false;
            }

            if (Input.touchCount > 0)
            {
                Jump();
            }

            m_CooldownTimer -= Time.deltaTime;

            if (m_CooldownTimer < 0.0f)
            {
                m_CooldownTimer = 0.0f;
                //Destroy(flowerBullet);
            }

            if (Input.GetKey(KeyCode.Space) && (m_CooldownTimer == 0.0f))
            {
                GameObject vine;
                vine = Instantiate(flowerBullet);
                vine.transform.position = transform.position + flowerDist * Vector3.right;
                m_CooldownTimer = m_CooldownDur;

            }





            






}

//HERMES BOOST\\
public IEnumerator HermesBoost()
    {
        Debug.Log("THNING TIGN");
        hermesShoe = true;
        yield return new WaitForSeconds(4);
        hermesShoe = false;
    }
    public IEnumerator PomegranateBoost()
    {
        Physics2D.IgnoreLayerCollision(8, 10, true);
        aPomegranate = true;
        yield return new WaitForSeconds(7);
        Physics2D.IgnoreLayerCollision(8, 10, false);
        aPomegranate = false;

    }


    void Jump()
    {
        //heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, heroJump); //Y is the hero jumping\\
        //Debug.Log("Jump!");



        if (isGrounded)
        {
            heroRigidbody.AddForce(Vector2.up * heroJump);
            floating = true;
        }


        if (timer < countdown && floating)
        {
            heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, heroJump);
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            floating = false;
        }
    }



   /* protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            gameObject.SetActive(false);
            print("Game over!");
        }
    }*/

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "HermesShoe")
        {
            
            
        }
        
    }

   /* protected void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            print("Game over!");
        }

      
        
    }*/
}
