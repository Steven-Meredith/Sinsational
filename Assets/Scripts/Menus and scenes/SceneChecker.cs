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
            
        }
        else if(SceneManager.GetActiveScene().name == "ROD")
        {
            curLevel = "ROD";
            
        }
        else if (SceneManager.GetActiveScene().name == "Gluttony LVL")
        {
            curLevel = "Gluttony LVL";
            
        }
        else if(SceneManager.GetActiveScene().name == "SlothBoss")
        {
            curLevel = "SlothBoss";
        }
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            curLevel = "Level1";

        }
        if (SceneManager.GetActiveScene().name == "bossLevel")
        {
            curLevel = "bossLevel";

        }
        else
        {
            Debug.Log("not proper level name");
        }
    }

    
}
