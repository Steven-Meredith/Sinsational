using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{

    public List<Transform> spawnPoints = new List<Transform>();
    int currentPos;
    int randomNum;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Pride")
        {
            Teleport();
        }
        
    }

    void Teleport()
    {
        Debug.Log("tt");
        currentPos = randomNum;
        randomNum = Random.Range(0, spawnPoints.Count);
        if (randomNum == currentPos)
        {
            Teleport();

        }
        else
        {
            this.transform.position = spawnPoints[randomNum].transform.position;
        }
    }
}
