using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionBeh : MonoBehaviour
{
    NavMeshAgent agen;
    GameObject Boss;
    float HP=1;
    // Start is called before the first frame update
    void Start()
    {
        agen = GetComponent<NavMeshAgent>();
        Boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {       
        agen.SetDestination(Boss.gameObject.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            HP--;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
