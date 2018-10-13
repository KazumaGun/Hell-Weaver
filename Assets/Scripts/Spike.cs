using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    //MOVEMENT\\
    private Rigidbody2D spikeRigidBody = null;
    [SerializeField] private float spikeSpeed = 2.0f;

    //ENEMY HIT POINTS\\
    [SerializeField] public int enemyDamage = 1;

    void Start()
    {
        spikeRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * spikeSpeed * Time.deltaTime);
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

