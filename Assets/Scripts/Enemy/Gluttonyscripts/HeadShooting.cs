using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShooting : MonoBehaviour
{
    
    public GameObject Shots;
    public Transform PukePoint;
    public int FoodStored=3;
    public float FireSpeed;
    void Start()
    {
        StartCoroutine(starting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator starting()
    {
        while (true)
        {
            yield return new WaitForSeconds(FireSpeed);
            for (int i = 0; i < FoodStored; i++)
            {
                yield return new WaitForSeconds(0.5f);
                GameObject pukeshot = Instantiate(Shots, PukePoint.transform.position, PukePoint.transform.rotation) as GameObject;
                Rigidbody rb = pukeshot.GetComponent<Rigidbody>();
                rb.AddForce(transform.up * 500, ForceMode.Force);
            }

        }
    }
}
