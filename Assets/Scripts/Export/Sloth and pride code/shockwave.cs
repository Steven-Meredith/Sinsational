using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockwave : MonoBehaviour
{
   
    void OnTriggerEnter(Collider other)
    {
        // Check if the projectile hit the player
        if (other.gameObject.tag == "Player")
        {

            
            PlayerHp.DamagePlayer(1);
            
           
        }
    }
}
