using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerHp : MonoBehaviour
{
    public static int hp = 5;
    [SerializeField] BoxCollider box;
    [SerializeField] ParticleSystem AngelBood;
    [SerializeField] List<Image> UIHealth;
     int hpNorm = hp;


    public Action OnDamageTaken { get; internal set; }

    public event System.Action DamageTaken;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {


            Destroy(gameObject);
            SceneManager.LoadScene("You Died Screen");

        }

        if (hp != hpNorm)
        {
            CheckHp();
            AngelBood.Play();
            hpNorm = hp;
        }

    }

    

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "damage obj")
        {
            hp--;

            // Call the OnDamageTaken event
            OnDamageTaken?.Invoke();
        }
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other == box)
        {
            hp = hp - 2;

            

        }
        else if (other.tag == "damage obj")
        {
            hp--;

            // Call the OnDamageTaken event
            OnDamageTaken?.Invoke();
        }
    }

    public static void DamagePlayer(int dam)
    {
        hp = hp - dam;

    }
  

    public static void ResetPlayer(int resetHP)
    {
        hp = resetHP;
    }

    public void CheckHp()
    {
        
        for (int i = 0; i < UIHealth.Count; i++)
        {
            UIHealth[i].enabled = false;
        }

        int k = hp - 1;

        UIHealth[k].enabled = true;

    }
}
