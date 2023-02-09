using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBall : MonoBehaviour
{
    public List<Transform> points;


    private const float timeMin = 0.0f;
    private const float timeMax = 5.0f;
    float t = 0;

    //private bool right = true;
    
    private Vector3 p0;
    private Vector3 p1;
    private Vector3 p2;
    private Vector3 p3;

    public Transform Obj0;
    public Transform Obj1;
    public Transform Obj2;
    public Transform Obj3;


    void Start()
    {
        p0 = Obj0.position;
        p1 = Obj1.position;
        p2 = Obj2.position;
        p3 = Obj3.position;

    }

    void Update()
    {
        //float t = right ? time / timeMax : 1.0f - (time / timeMax);
        //Quaternion rotSrc = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //Quaternion rotDst = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        //transform.rotation = Quaternion.Slerp(rotSrc, rotDst, t);
        //transform.position = Vector3.Lerp(src.position, dst.position, t);

        t = Mathf.Cos(Time.realtimeSinceStartup) * 0.5f + 0.5f;

        Vector3 pp = 0.5f * (2.0f * p1 + t * (-p0 + p2)
        + t * t * (2.0f * p0 - 5.0f * p1 + 4.0f * p2 - p3)
        + t * t * t * (-p0 + 3.0f * p1 - 3.0f * p2 + p3));


        transform.position = pp;





    }

    
}
