using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum PickupType
    {
        HermesShoe,
        Pomegranate,
        HadesHelm,
        CerberusCoin,
        VOID,
    }

    public PickupType typeOfPickup;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject aCollisionObject = collision.gameObject;
        if(aCollisionObject.tag == "Hero")
        {
            switch(typeOfPickup)
            {
                case PickupType.HermesShoe:
                    StartCoroutine(aCollisionObject.GetComponent<Hero>().HermesBoost());
                    break;
                case PickupType.Pomegranate:
                    StartCoroutine(aCollisionObject.GetComponent<Hero>().PomegranateBoost());
                    break;
                case PickupType.HadesHelm:
                    //call Hades function
                    break;
                case PickupType.CerberusCoin:
                    //call cerberusfunction
                    break;
            }
        }
    }



}
