using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour
{
    public static float hp = 3f;
    [SerializeField] BoxCollider WrathBox;

    
    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == WrathBox)
        {
            hp = hp - 2;
        }
    }

}
