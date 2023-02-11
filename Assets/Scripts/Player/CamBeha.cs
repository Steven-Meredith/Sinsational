using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBeha : MonoBehaviour
{
    // Start is called before the first frame update
    public Player pla;
    float MousX;
    float MousZ;
    float drag = 2;
    Vector3 mousePos;
    Vector3 camPos;
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        mousePos = pla.getHit().point;
        camPos = (pla.transform.position + mousePos) / 2f;

        camPos.x = Mathf.Clamp(camPos.x, -drag + pla.transform.position.x, drag + pla.transform.position.x);
        camPos.y = 12 + pla.transform.position.y;
        camPos.z = Mathf.Clamp(camPos.z, -drag + pla.transform.position.z, drag + pla.transform.position.z);
    }
    private void LateUpdate()
    {


        //StartCoroutine(Shake(1f, 0.2f));
        this.transform.position = camPos;
    }
    public Vector3 getFace()
    {
        return mousePos - pla.transform.position;
    }

    public IEnumerator Shake(float duration, float mag)
    {
        Vector3 originalPos = transform.position;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * mag;
            float z = Random.Range(-1f, 1f) * mag;

            camPos += new Vector3(x, 0, z);

            elapsed += Time.deltaTime;

            yield return null;
        }
    }
}
