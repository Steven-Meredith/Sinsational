using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public GameObject Death;
    public GameObject DeathScreen;
    public void Restart()
    {
        SceneManager.LoadScene("ROD");
        PlayerHp.ResetPlayer(5);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }
    void Update()
    {
        if (Death.activeInHierarchy)
        {
            StartCoroutine("DeathScreenLoader");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public IEnumerator DeathScreenLoader()
    {
        yield return new WaitForSeconds(2);
        DeathScreen.SetActive(true);
    }
    void Start()
    {
        DeathScreen.SetActive(false);
    }
}
