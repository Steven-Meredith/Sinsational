using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class Small_sin : MonoBehaviour
{
    private Transform player;
    NavMeshAgent nav;
    private float hp = 3f;
    float attackTime = 0f;
    Animator anim;
    [SerializeField] ParticleSystem DevilsBlood;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);

        if (attackTime >= 0)
        {
            attackTime -= Time.deltaTime;
        }
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
                EnemyActivation.decreaseEnemy();
                
            }
        }

      
   
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (attackTime <= 0)
            {
                
                PlayerHp.DamagePlayer(1);
                attackTime = 5f;
                anim.SetBool("Attacking", true);
                anim.SetBool("Walking", false);

            }

        }
    }




    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {

            anim.SetBool("Attacking", false);
            anim.SetBool("Walking", true);
        }
    }
}
