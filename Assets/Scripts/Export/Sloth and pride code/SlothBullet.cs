using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            //deal damage then delete bullet
            PlayerHp.DamagePlayer(1);
            Destroy(gameObject);
        }
        else if (collision.collider.tag != "Ground" && collision.collider.tag != "Sloth") 
        {
            //delete bullet if it hits anything but the ground or player
            Destroy(gameObject);
        }
    }
}
