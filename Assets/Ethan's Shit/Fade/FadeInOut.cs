using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] public CanvasGroup canvasgroup;
    private bool _fadeIn = false;
    private bool _fadeOut = false;

    // Update is called once per frame
    void Update()
    {
        if (_fadeIn)
        {
            if (canvasgroup.alpha < 1)
            {
                canvasgroup.alpha += Time.deltaTime;
                if (canvasgroup.alpha >=1)
                {
                    _fadeIn = false;
                }
            }
        }

        if (_fadeOut)
        {
            if (canvasgroup.alpha >= 0)
            {
                canvasgroup.alpha += Time.deltaTime;
                if (canvasgroup.alpha == 0)
                {
                    _fadeOut = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        _fadeIn = true;
        Debug.Log ("pushed fade in");
    }

    public void FadeOut()
    {
        _fadeOut = true;
        Debug.Log("pushed fade out");
    }
}
