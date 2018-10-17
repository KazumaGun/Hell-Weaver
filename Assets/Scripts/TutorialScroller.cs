using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScroller : MonoBehaviour
{

    //MOVEMENT\\
    private Rigidbody2D tutorialRigidBody = null;
    [SerializeField] private float tutorialSpeed = 2.0f;

    void Start()
    {
        tutorialRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        transform.Translate(Vector2.left * tutorialSpeed * Time.deltaTime);
    }

}
