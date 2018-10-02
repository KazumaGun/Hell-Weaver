using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float enemySpeed = 1.0f;
    [SerializeField] private Vector2 enemyDirection = Vector3.right;

    private Rigidbody2D enemyRigidbody;


    void Start ()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyRigidbody.velocity = enemySpeed * enemyDirection;
	}
	
	
	void Update ()
    {
		
	}

    /*protected void OnCollisionEnter(Collision aCollision)
    {
        GameObject aCollisionObject;
        aCollisionObject = aCollision.gameObject;

        //Enemy destroys hero???????\\

        Hero aHero;
        aHero = aCollisionObject.GetComponent<Hero>();

        if (aHero != null)
        {
            Destroy(gameObject);
        }
    }*/
}
