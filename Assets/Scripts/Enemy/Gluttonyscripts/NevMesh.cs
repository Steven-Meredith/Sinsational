using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NevMesh : MonoBehaviour
{
    public NavMeshAgent agen;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.gameObject.name);
        agen.SetDestination(player.gameObject.transform.position);
    }
}
