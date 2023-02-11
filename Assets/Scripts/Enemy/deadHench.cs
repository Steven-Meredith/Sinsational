using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class deadHench : MonoBehaviour
{
    [SerializeField] List<EnemyDeath> enemies;

    [SerializeField] GameObject wall;
    [SerializeField] GameObject wall2;
    public static int enemyCount1;


    // Start is called before the first frame update
    void Start()
    {
        enemyCount1 = enemies.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount1 == 0)
        {
            wall.SetActive(false);
            wall2.SetActive(false);
            Debug.Log("All enemies dead");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player crossed boundry");
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].enabled = true;


            }
 
            enemyCount1 = enemies.Count;
            
            Debug.Log(enemies.Count);
            wall.SetActive(true);
            wall2.SetActive(true);
        }



    }

    public static void decreaseEnemy()
    {
        enemyCount1 = enemyCount1 - 1;
        Debug.Log("One less enemy");
    }


}