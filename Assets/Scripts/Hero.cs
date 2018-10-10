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

    //SPEED BOOST\\
    [Header("Power-Ups")]
    [SerializeField] bool hermesShoe;
    [SerializeField] private float hermesSpeed;

    [SerializeField] bool aPomegranate;
    [SerializeField] Collider2D pomegranateCollider;

    private string theRules = " Tap to jump and hold down for longer jump " +
        " White ball is a speed boost " + " red ball allows you to walk through objects ";

    //VINE WHIP\\
    
    [SerializeField] private GameObject flowerBullet;
    [SerializeField] private float flowerDist;
    [SerializeField] private float m_CooldownDur = 1.0f;
    [SerializeField] private float m_CooldownTimer = 0.0f;


    void Start()
    {
        //Get rigid body at start of game\\
        heroRigidbody = GetComponent<Rigidbody2D>();

        heroCollider = GetComponent<Collider2D>(); //For checking ground\\

    }


    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 400, 50), theRules);
    }


    void Update()
    {

        isGrounded = Physics2D.IsTouchingLayers(heroCollider, thisIsGround); //checks the colliders in a layer\\


        //MOVEMENT\\
        //heroRigidbody.velocity = (Vector2.right * heroSpeed); //Only want the player to move a constant speed, not messing with Y value\\
        if (!hermesShoe)
        {
            heroRigidbody.gameObject.transform.Translate(Vector2.right * heroSpeed * Time.deltaTime);
        }
        else
        {
            heroRigidbody.gameObject.transform.Translate(Vector2.right * hermesSpeed * Time.deltaTime); //HERMES BOOST\\
        }


        //JUMPING\\
        if (Input.GetMouseButton(0))
        {
            Jump();
        }

        if (Input.touchCount > 0)
        {
            Jump();
        }

        /*if (Input.GetKey(KeyCode.Space))
        {
            GameObject vine;
            vine = Instantiate(flowerBullet);
            flowerBullet.transform.position = transform.position + flowerDist * Vector3.right;
        }*/

        m_CooldownTimer -= Time.deltaTime;

        if (m_CooldownTimer < 0.0f)
        {
            m_CooldownTimer = 0.0f;
            Destroy(flowerBullet);
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
        heroRigidbody.AddForce(Vector2.up * heroJump);
        //Debug.Log("Jump!");



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

   

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            gameObject.SetActive(false);
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "HermesShoe")
        {
            
            
        }
        
    }

    protected void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            print("Game over!");
        }

      
        
    }
}
