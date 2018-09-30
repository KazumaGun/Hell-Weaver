using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackground : MonoBehaviour
{

    public float backgroundSpeed;
    public float startBackground;
    public float endBackground;



	void Update ()
    {
        transform.Translate(Vector2.left * backgroundSpeed * Time.deltaTime);

        if (transform.position.x <= endBackground)
        {
            //Vector2.position = new Vector2(startBackground , transform.position.y);
            //transform.position = position;
        }
	}
}
