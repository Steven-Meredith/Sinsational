using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProperties : MonoBehaviour
{
    public float HP = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {      
        if (collision.gameObject.name.Contains("Bullet"))
        {
            HP--;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Contains("Minion"))
        {
            HP+=10;
            if (HP > 100)
            {
                HP = 100;
            }
            Destroy(collision.gameObject);
        }
    }

    
}
