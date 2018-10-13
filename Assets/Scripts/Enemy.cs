using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //MOVEMENT\\
    private Rigidbody2D enemyRigidBody = null;
    [SerializeField] private float enemySpeed = 2.0f;

    //HERO\\
    //[SerializeField] Hero myHero = null;

    //ENEMY HIT POINTS\\
    [SerializeField] public int enemyDamage = 1;

    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*Vector3 velocity = Vector3.zero;
        velocity += enemySpeed * Vector3.down;
        // The ENEMY follows the player a little bit.
        if (transform.position.x < myHero.transform.position.x)
        {
            velocity += enemySpeed * Vector3.right;
        }
        else
        if (transform.position.x > myHero.transform.position.x)
        {
            velocity += enemySpeed * Vector3.left;
        }
        enemyRigidBody.velocity = velocity;*/

        transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Hero"))
        {
            other.collider.GetComponent<Hero>().heroHealth -= enemyDamage;
            Debug.Log(other.collider.GetComponent<Hero>().heroHealth);
            Destroy(gameObject);
        }
    }

}
