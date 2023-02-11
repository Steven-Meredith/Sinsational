using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderManager : MonoBehaviour
{

    public Transform spawnParent;
    public List<Transform> spawnPoints = new List<Transform>();
    public GameObject boulder;
    Quaternion yRot;
    public float spawnTime = 3f;

    
    float Timer = 0.0f;

    private void Start()
    {
        yRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        
            
        //timer to track when to spawn boulder
        if(Timer >= spawnTime)
        {
            
            SpawnBoulder();
            Timer = 0.0f;
        }
        Timer += Time.deltaTime;
      
    }

    void SpawnBoulder()
    {
        int spawn = Random.Range(0, spawnPoints.Count);

        Instantiate(boulder, spawnPoints[spawn].position, spawnPoints[spawn].rotation, spawnPoints[spawn]);
    }


}
