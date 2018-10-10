using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBullet : MonoBehaviour
{

    private Rigidbody2D m_RigidBody = null;
    [SerializeField] private float m_Speed = 4.0f;

    public GameObject flowerBullet;

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 velocity = Vector3.zero;
        velocity += m_Speed * Vector3.right;

        m_RigidBody.velocity = velocity;

    }


    // Laser collided with an enemy!

    protected void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

