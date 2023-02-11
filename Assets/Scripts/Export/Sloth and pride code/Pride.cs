using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Pride : MonoBehaviour
{
    private Transform player;
    BoxCollider box;
    NavMeshAgent nav;
    private float hp = 10f;
    float attackTime = 0f;
    Animator anim;
    bool attacking = false;
    Rigidbody rb;
    [SerializeField] ParticleSystem DevilsBlood;
    float speed = 5;
    bool invunrable = true;
    float invunrableTime = 5f;
    bool dontStpAttack;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
        box.enabled = false;
        nav.speed = speed;
        Debug.Log("should be working");
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            nav.SetDestination(rb.position);
            //checks if attack animation has finished put the float to 5 - the length of the attack anim and damage
            if (attackTime <= 1f)
            {
                attacking = false;
                anim.SetBool("Attacking", false);
                anim.SetBool("Walking", true);
            }
        }
        else if (!attacking && invunrable)
        {
            nav.SetDestination(player.position);
        }


        if (attackTime >= 0)
        {
            attackTime -= Time.deltaTime;
        }


        if (!invunrable)
        {
            invunrableTime -= Time.deltaTime;
            if (invunrableTime <= 0f)
            {
                invunrable = true;
                
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Bullet" && !invunrable)
        {
            hp--;
            DevilsBlood.Play();
            Debug.Log("damage dealt");
            if (hp == 45)
            {

            }
            else if (hp <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("YouWin");
                EnemyActivation.decreaseEnemy();
            }
        }
        else if (collision.collider.tag == "Bullet" && invunrable)
        {
            Debug.Log("im fuckin invincible");
        }

        if (collision.collider.tag == "Mirror")
        {
            Debug.Log("mirror trigger");
            invunrableTime = 5f;
            invunrable = false;
            nav.SetDestination(rb.position);
        }






    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (attackTime <= 0)
            {

                rb.velocity = new Vector3(0f, 0f, 0f);
                attackTime = 3f;
                anim.SetBool("Attacking", true);
                anim.SetBool("Walking", false);
                attacking = true;
            }
            else if (attackTime > 0f && !attacking)
            {
                anim.SetBool("Attacking", false);
                anim.SetBool("Walking", true);
            }

        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (attackTime <= 0)
            {


                attackTime = 3f;
                anim.SetBool("Attacking", true);
                anim.SetBool("Walking", false);
                attacking = true;
            }
            else if (attackTime > 0 && !attacking)
            {
                anim.SetBool("Attacking", false);
                anim.SetBool("Walking", true);
            }

        }

        
    }

    public void attack()
    {

        box.enabled = true;
    }

    public void EndAttack()
    {

        box.enabled = false;
    }
}

