using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemyRigidBody = null;
    [SerializeField] private float enemySpeed = 2.0f;

    [SerializeField] Hero myHero = null;
    [SerializeField] int myHitPoints = 20;

    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 velocity = Vector3.zero;
        velocity += enemySpeed * Vector3.down;

        // The boss follows the player a little bit.

        if (transform.position.x < myHero.transform.position.x)
        {
            velocity += enemySpeed * Vector3.right;
        }
        else
        if (transform.position.x > myHero.transform.position.x)
        {
            velocity += enemySpeed * Vector3.left;
        }

        enemyRigidBody.velocity = velocity;
    }
}
