using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;


public class Wrath : MonoBehaviour
{
    private Transform player;
    BoxCollider box;
    NavMeshAgent nav;
    private float hp = 100f;
    float attackTime = 0f;
    Animator anim;
    public GameObject fireCircle;
    public GameObject lavaBall1;
    public GameObject lavaBall2;
    bool attacking = false;
    Rigidbody rb;
    [SerializeField] ParticleSystem DevilsBlood;
    public float speed;

    bool dontStpAttack;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        fireCircle.SetActive(false);
        lavaBall1.SetActive(false);
        lavaBall2.SetActive(false);
        box = GetComponent<BoxCollider>();
        box.enabled = false;
        nav.speed = speed;
       
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
        else if(!attacking)
        {
            nav.SetDestination(player.position);
        }
        

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
            
            if (hp == 45)
            {
                
                fireCircle.SetActive(true);
                lavaBall1.SetActive(true);
                lavaBall2.SetActive(true);
            }
            else if (hp <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("YouWin");
                EnemyActivation.decreaseEnemy();
            }
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
            else if(attackTime > 0f && !attacking)
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
            else if(attackTime > 0 && !attacking)
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
