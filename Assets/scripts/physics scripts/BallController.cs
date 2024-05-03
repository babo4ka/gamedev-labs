using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField]
    private GameObject lepeshka;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            if(collision.gameObject.name == "Floor" || collision.gameObject.name == "Wall")
            {
                InstantiateMark(collision);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log($"On exit: {collision.gameObject.name}");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            if (collision.gameObject.name == "Floor" || collision.gameObject.name == "Wall")
            {
                InstantiateMark(collision);
            }
        }
    }


    private void InstantiateMark(Collision collision)
    {
        ContactPoint contactPoint = collision.contacts[0];
        GameObject g = Instantiate(lepeshka, contactPoint.point, lepeshka.transform.rotation);
        g.transform.up = contactPoint.normal;
    }
}
