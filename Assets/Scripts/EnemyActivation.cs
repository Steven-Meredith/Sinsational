using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyActivation : MonoBehaviour
{
    [SerializeField] List<Small_sin> enemies;
    [SerializeField] Wrath Boss;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject wall2;
    public static int enemyCount;


    // Start is called before the first frame update
    void Start()
    {
        enemyCount = enemies.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == 0)
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

            if (Boss != null)
            {
                Debug.Log("boss is here");
                Boss.enabled = true;


            }
            enemyCount = enemies.Count;
            if (Boss != null)
            {
                Debug.Log("count boss");

                enemyCount = enemyCount + 1;
            }
            Debug.Log(enemies.Count);
            wall.SetActive(true);
            wall2.SetActive(true);
        }



    }

    public static void decreaseEnemy()
    {
        enemyCount = enemyCount - 1;
        Debug.Log("One less enemy");
    }


}