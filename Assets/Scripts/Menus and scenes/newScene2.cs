using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newScene2 : MonoBehaviour
{
    public int iLvlLoad2;
    public string sLvlLoad2;

    public bool IntToLoadLvl2 = false;

    private void OnTriggerEnter(Collider collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level1");
        }
    }

    void LoadScene()
    {
        if (IntToLoadLvl2)
        {
            SceneManager.LoadScene(iLvlLoad2);
        }
        else
        {
            SceneManager.LoadScene(sLvlLoad2);
        }
    }
}
