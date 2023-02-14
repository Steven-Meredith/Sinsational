using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecker : MonoBehaviour
{
    public static string curLevel = "tutorial";
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SlothLevel1")
        {
            curLevel = "SlothLevel1";
            Debug.Log("sloth");
        }
        else if(SceneManager.GetActiveScene().name == "ROD")
        {
            curLevel = "ROD";
            Debug.Log("ROD");
        }
        else
        {
            Debug.Log("not proper level name");
        }
    }

    
}
