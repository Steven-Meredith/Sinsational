using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterStretching : MonoBehaviour
{

    [SerializeField] ParticleSystem Water;
    public Transform projectileSpawnPoint;
    private Transform playerTransform;
    public float waterSpeed = 10f;
    public float waterLifetime = 5f;

    public float throwDelay = 2f; // The time between each throw



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > throwDelay)
        {
            // Water throw
            // Calculate the direction to the player
            Vector3 waterDirection = playerTransform.position - projectileSpawnPoint.position;
        waterDirection.Normalize(); // Normalize the direction vector to ensure consistent speed

        // Play the particle system
        Water.Play();
        // Set the velocity of the particle system
        Water.GetComponent<Rigidbody>().velocity = waterDirection * waterSpeed;
        // Destroy the particle system after a certain amount of time
        Destroy(Water.gameObject, waterLifetime);
        }           
    }
}
