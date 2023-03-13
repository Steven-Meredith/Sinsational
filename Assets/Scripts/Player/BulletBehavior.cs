using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    Vector3 lastVel; //the last velocity of the bullet
    float speed; //speed of the bullet
    Vector3 direction; //direction of the bullet
    [SerializeField] Rigidbody rb; //bullets rigid body


    private void LateUpdate()
    {
        lastVel = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Bounce")
        {

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bounce")
        {
            speed = lastVel.magnitude;
            direction = Vector3.Reflect(lastVel.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0);

        }



        Destroy(gameObject, 5);
    }
}

