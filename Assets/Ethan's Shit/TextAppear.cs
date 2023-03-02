using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    [SerializeField] GameObject _image;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            _image.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            _image.gameObject.SetActive(false); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
