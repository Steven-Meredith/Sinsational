using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPre;
    public Transform FirePoint;
    public float BulletForce = 5;
    bool startFiring = false;
    public CamBeha shaker;
    public AudioSource gunSound;
    int BCount = 0;
    float ShootTimer;
    float shootCounter;
    public float fireRate = 0.2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startFiring = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            startFiring = false;
        }
        if (startFiring)
        {
            shootCounter -= Time.deltaTime;

            if (shootCounter <= 0)
            {
                shootCounter = fireRate;
                shoot();
            }
            else
                shootCounter -= Time.deltaTime;
        }
    }

    void shoot()
    {

        Vector3 fo = FirePoint.forward;
        GameObject Bullet = Instantiate(BulletPre, FirePoint.position, FirePoint.rotation);
        Rigidbody rb = Bullet.GetComponent<Rigidbody>();
        rb.AddForce(fo * BulletForce, ForceMode.Impulse);
        BCount--;
        gunSound.Play();
        StartCoroutine(shaker.Shake(0.1f, 0.1f));
    }
}

