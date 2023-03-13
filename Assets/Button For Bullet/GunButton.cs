using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunButton : MonoBehaviour
{
    //the light is basically a light for the switch, so you can toggle the switch on and off visually, and the object is the object that is being activated or deactivated ofc
    //[SerializeField] GameObject _lightObj;
    [SerializeField] List<GameObject> _object = new List<GameObject>();
    [SerializeField] GameObject _lightObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            for (int i = 0; i < _object.Count; i++)
            {
                _object[i].SetActive(false);
                _lightObj.SetActive(false);
            }
            // if the object is hit with a bullet
            /*if (_lightObj.activeSelf != true)
            {
                _lightObj.SetActive(true);
                
            }
            else
            {
                _lightObj.SetActive(false);
            } */
        }
    }
}
