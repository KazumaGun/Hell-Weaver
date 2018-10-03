using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *  This class is for Kaz's jump mechanic
 *  
 *  Matthew K. Greene
 * 
 * */
[RequireComponent(typeof(Rigidbody2D))]
public class KazJump : MonoBehaviour {

    public float jumpTime = 3.0f;
    public float acceleration;
    private Rigidbody2D rig = null;
    private Collider2D col = null;
    private float distanceToGround = 0.0f; 

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        distanceToGround = col.bounds.extents.y; 
    }

    // Update is called once per frame
    void Update () {
        #if UNITY_EDITOR || UNITY_STANDALONE
                MouseJump();
        #endif

        #if UNITY_ANDROID || UNITY_IOS
                TouchJump(); 
        #endif
    }

    void MouseJump()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(IsGrounded())
            {
                StartCoroutine("Jump");
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine("Jump"); 
        }
        Debug.DrawRay(transform.position, -transform.up * (distanceToGround + .1f));
    }

    void TouchJump()
    {
        // Do we have touches?
        if (Input.touchCount > 0)
        {
            // When touch begins
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if(IsGrounded())
                {
                    StartCoroutine("Jump");
                }
            }
            // When touch ends
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                StopCoroutine("Jump");
            }
        }
    }

    /// <summary>
    /// Coroutine applies acceleration force through duration of timer. 
    /// </summary>
    /// <returns></returns>
    public IEnumerator Jump()
    {
        float timer = jumpTime; 
        while(timer > 0.0f)
        {
            timer -= Time.deltaTime;
            rig.AddForce(transform.up * acceleration, ForceMode2D.Force);
            Debug.Log("Time : " + timer);
            yield return new WaitForFixedUpdate();
        } 
    }

    /// <summary>
    /// Check if the player is grounded
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -transform.up, distanceToGround + .1f);
    }

}
