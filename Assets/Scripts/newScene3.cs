using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newScene3 : MonoBehaviour
{
    public int iLvlLoad3;
    public string sLvlLoad3;

    public bool IntToLoadLvl3 = false;

    private void OnTriggerEnter(Collider collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "Player")
        {
            SceneManager.LoadScene("bossLevel");
        }
    }

    void LoadScene()
    {
        if (IntToLoadLvl3)
        {
            SceneManager.LoadScene(iLvlLoad3);
        }
        else
        {
            SceneManager.LoadScene(sLvlLoad3);
        }
    }
}