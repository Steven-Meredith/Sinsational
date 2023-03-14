using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject minions;
    public List<Transform> trans;
    public float spawnGap=60;
    public float spawnNumber=15;
    void Start()
    {
        StartCoroutine(starting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator starting()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnGap);
            for (int i = 0; i < spawnNumber; i++)
            {
                Instantiate(minions, trans[Random.Range(0, trans.Count - 1)]);
            }
            
        }      
    }
}
