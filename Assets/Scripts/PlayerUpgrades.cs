using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "WrathUpgrade")
        {

            
            
            Destroy(collision.gameObject);
        }
    }
}
