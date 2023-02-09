using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    private float hp = 3f;
    [SerializeField] ParticleSystem DevilsBlood;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Bullet")
        {
            hp--;
            DevilsBlood.Play();
            if (hp <= 0)
            {
                Destroy(gameObject);
                deadHench.decreaseEnemy();

            }
        }
    }
}
