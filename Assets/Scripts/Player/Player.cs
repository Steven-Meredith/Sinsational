
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5;
    public Camera cam;
    Ray ray;
    RaycastHit hit;
    Animator anim;


    float dashCounter = 0;

    bool dashing;

    void Start()
    {
        anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
        StartCoroutine(timers());
    }

    public RaycastHit getHit()
    {
        return hit;
    }
    // Update is called once per frame
    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 temp;
        Physics.Raycast(ray, out hit);
        float x = 0;
        float y = rb.velocity.y;
        float z = 0;
        anim.SetBool("Walking", false);
        //Debug.Log(hit.point.x+","+hit.point.y+"," + hit.point.z);

        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddForce(Vector3.forward*speed,ForceMode.Force);
            z += speed;
            anim.SetBool("Walking", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // rb.AddForce(-Vector3.forward * speed, ForceMode.Force);
            z -= speed;
            anim.SetBool("Walking", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(-Vector3.right * speed, ForceMode.Force);
            x -= speed;
            anim.SetBool("Walking", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(Vector3.right * speed, ForceMode.Force);
            x += speed;
            anim.SetBool("Walking", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && dashCounter >= 0)
        {
            StartCoroutine(dash());
        }

        if (!dashing)
        {
            rb.velocity = new Vector3(x, y, z);
        }

        
        transform.LookAt(new Vector3(hit.point.x, transform.position.y + 0.05f, hit.point.z));

    }

    public RaycastHit GetRayHit()
    {
        return hit;
    }

    IEnumerator dash()
    {
        anim.SetBool("Dodge", true);
        dashing = true;
        dashCounter--;
        rb.AddForce(rb.velocity.normalized * 25, ForceMode.Impulse);
        yield return new WaitForSeconds(0.7f);
        dashing = false;
        anim.SetBool("Dodge", false);

    }
    IEnumerator timers()
    {
        while (1 == 1)
        {
            yield return new WaitForSeconds(3.0f);
            dashCounter = 1;
            Debug.Log("set");
        }
    }


}

