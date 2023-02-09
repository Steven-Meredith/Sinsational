using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signer : MonoBehaviour
{
    public Text textField;
    public string input;


    private void Start()
    {
        //textField = GameObject.Find("textField").GetComponent<Text>();
        textField.text = "";
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("");
        if (collision.name.Contains("Player"))
        {
            textField.text = input;
            textField.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.name.Contains("Player"))
        {
            textField.text = "";
            textField.gameObject.SetActive(false);
        }
    }
}