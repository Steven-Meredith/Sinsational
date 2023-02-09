using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlothBoss : MonoBehaviour
{
    public GameObject waterProjectile; // The object that the boss will throw at the player
    public GameObject rockProjectile; // The object that the boss will throw at the player
    public GameObject smallRockProjectile; // The object that the boss will throw at the player
    public Transform projectileSpawnPoint; // The location from which the projectiles will be spawned
    public float waterProjectileSpeed = 10f; // The speed at which the water projectile will be thrown
    public float rockProjectileSpeed = 20f; // The speed at which the rock projectile will be thrown
    public float smallRockProjectileSpeed = 10f; // The speed at which the small rock projectiles will be thrown
    public float throwDelay = 2f; // The time between each throw
    public float scatterRange = 45f; // The range in degrees around the player's position that the small rock projectiles can scatter
    public float waterLifetime = 5f; // The lifetime of the water projectile in seconds

    //health & others
    private float SlothHp = 100f;
    [SerializeField] ParticleSystem DevilsBlood;

    private Transform playerTransform; // The transform of the player
    private Vector3 playerPosition; // The position of the player at the time of the throw

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform; // Find the transform of the player object
    }

    // Update is called once per frame
    void Update()
    {
        // Check if it's time to throw a projectile
        if (Time.time > throwDelay)
        {
            int throwType = Random.Range(1, 4); // Choose a random throw type

            switch (throwType)
            {
                case 1:
                    // Water throw
                    // Calculate the direction to the player
                    Vector3 waterDirection = playerTransform.position - projectileSpawnPoint.position;
                    waterDirection.Normalize(); // Normalize the direction vector to ensure consistent speed

                    // Create and throw the projectile
                    GameObject waterGo = Instantiate(waterProjectile, projectileSpawnPoint.position, Quaternion.identity);


                    
                    // Rotate the projectile to face the player
                    waterGo.transform.LookAt(playerTransform);
                    // Set the velocity of the projectile
                    waterGo.GetComponent<Rigidbody>().velocity = waterDirection * waterProjectileSpeed;

                    

                    // Destroy the projectile after a certain amount of time
                    Destroy(waterGo, waterLifetime);
                    break;
               
                case 2:
                    // Rock throw
                    // Calculate the direction to the player
                    Vector3 rockDirection = playerTransform.position - projectileSpawnPoint.position;
                    rockDirection.Normalize(); // Normalize the direction vector to ensure consistent speed

                    // Create and throw the projectile
                    GameObject rockGo = Instantiate(rockProjectile, projectileSpawnPoint.position, Quaternion.identity);
                    rockGo.GetComponent<Rigidbody>().velocity = rockDirection * rockProjectileSpeed;
                    break;
                case 3:
                    // Small rock throw
                    // Calculate the direction to the player
                    Vector3 smallRockDirection = playerTransform.position - projectileSpawnPoint.position;
                    smallRockDirection.Normalize(); // Normalize the direction vector to ensure consistent speed

                    // Create and throw the small rock projectiles
                    for (int i = 0; i < 6; i++)
                    {
                        // Calculate a random direction within the scatter range
                        float scatterAngle = Random.Range(-scatterRange, scatterRange);
                        Quaternion scatterRotation = Quaternion.Euler(0f, scatterAngle, 0f);
                        Vector3 scatterDirection = scatterRotation * smallRockDirection;

                        // Create and throw the projectile
                        GameObject smallRockGo = Instantiate(smallRockProjectile, projectileSpawnPoint.position, Quaternion.identity);
                        smallRockGo.GetComponent<Rigidbody>().velocity = scatterDirection * smallRockProjectileSpeed;
                    }
                    break;
            }

            // Reset the throw delay
            throwDelay = Time.time + 2f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Bullet")
        {
            SlothHp--;
            DevilsBlood.Play();

            if (SlothHp == 45)
            {

                //fireCircle.SetActive(true);
              
            }
            else if (SlothHp <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("YouWin");
                EnemyActivation.decreaseEnemy();
            }
        }

    }
}
