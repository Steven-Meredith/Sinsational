using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCircle : MonoBehaviour
{
    float attackTime = 0f;


        private void Update()
    {
        if (attackTime >= 0)
        {
            attackTime -= Time.deltaTime;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (attackTime <= 0)
            {
                
                attackTime = 1f;
                PlayerHp.DamagePlayer(1);
              

            }

        }
    }
}
