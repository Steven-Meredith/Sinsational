using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoulderMove : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 6f;
    public float deleteTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        Destroy(gameObject, deleteTime);
    }

    
}
