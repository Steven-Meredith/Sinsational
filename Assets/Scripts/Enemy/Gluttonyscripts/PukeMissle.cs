using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeMissle : MonoBehaviour
{
    Rigidbody rb;
    Transform player;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(player.position-gameObject.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Head")
        {
            Instantiate(explosion,gameObject.transform.position,Quaternion.Euler(new Vector3(45, 0, 0)));
            Destroy(gameObject);
            //Instantiate
        }
    }
}
