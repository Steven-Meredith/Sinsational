using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothWaterWaveBullet : MonoBehaviour
{
    public int damage = 1; // The amount of damage that the projectile will deal to the player

    void OnTriggerEnter(Collider other)
    {
        // Check if the projectile hit the player
        if (other.gameObject.tag == "Player")
        {

            // Deal damage to the player
            PlayerHp.DamagePlayer(1);
            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
