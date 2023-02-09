using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the projectile has collided with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}