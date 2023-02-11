using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sloth : MonoBehaviour
{
    public GameObject shockwaveProjectile; 
    public GameObject bigBullet; 
    public GameObject shotgunBullet; 
    public float shockwaveProjectileSpeed = 10f;
    public float bigBulletSpeed = 20f;
    public float shotgunBulletSpeed = 10f;
    public float shootTime = 2f;
    public float scatterRange = 45f;
    public float shockwaveLifetime = 5f;
    

    

    public float hp = 10f;

    [SerializeField] ParticleSystem DevilsBlood;

    //player stuff
    private Transform playerTransform;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform; // Find the players position

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > shootTime)
        {
            
            Shoot();
            shootTime = Time.time + 2f;
        }

       
    }

    public void Shoot()
    {
        int bulletType = Random.Range(1, 4); // Choose a random bullet type

        switch (bulletType)
        {
            case 1:
                // shockwave
                // Calculate the direction to the player
                Vector3 waterDirection = playerTransform.position - this.transform.position;
                waterDirection.Normalize(); 

                // Create and throw the projectile
                GameObject Shock = Instantiate(shockwaveProjectile, this.transform.position, Quaternion.identity);



                // Rotate the projectile to face the player
                Shock.transform.LookAt(playerTransform);
                // Set the velocity of the projectile
                Shock.GetComponent<Rigidbody>().velocity = waterDirection * shockwaveProjectileSpeed;



                // Destroy the projectile after a certain amount of time
                Destroy(Shock, shockwaveLifetime);
                break;

            case 2:
                // big bullet
                // Calculate the direction to the player
                Vector3 BigBulletDirection = playerTransform.position - this.transform.position;
                BigBulletDirection.Normalize(); 

                // Create and throw the projectile
                GameObject bigBull = Instantiate(bigBullet, this.transform.position, Quaternion.identity);
                bigBull.GetComponent<Rigidbody>().velocity = BigBulletDirection * bigBulletSpeed;
                break;

            case 3:
                // Small bullet shot
                // Calculate the direction to the player
                Vector3 shotgunBulletDirection = playerTransform.position - this.transform.position;
                shotgunBulletDirection.Normalize(); 

                // Create and throw the small rock projectiles
                for (int i = 0; i < 6; i++)
                {
                    // Calculate a random direction within the scatter range
                    float scatterAngle = Random.Range(-scatterRange, scatterRange);
                    Quaternion scatterRotation = Quaternion.Euler(0f, scatterAngle, 0f);
                    Vector3 scatterDirection = scatterRotation * shotgunBulletDirection;

                    // Create and throw the projectile
                    GameObject smallRockGo = Instantiate(shotgunBullet, this.transform.position, Quaternion.identity);
                    smallRockGo.GetComponent<Rigidbody>().velocity = scatterDirection * shotgunBulletSpeed;
                }
                

                break;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            hp--;


            if (hp <= 5 && hp > 0)
            {


            }
            else if (hp <= 0)
            {
                Destroy(gameObject);

            }
        }
    }
}
