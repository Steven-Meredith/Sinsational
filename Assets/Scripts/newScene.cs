using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newScene : MonoBehaviour
{
    public int iLvlLoad;
    public string sLvlLoad;

    public bool IntToLoadLvl = false;

    private void OnTriggerEnter(Collider collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "Player")
        {
            SceneManager.LoadScene("ROD");
        }
    }

    void LoadScene()
    {
        if (IntToLoadLvl)
        {
            SceneManager.LoadScene(iLvlLoad);
        }
        else
        {
            SceneManager.LoadScene(sLvlLoad);
        }
    }
}

