using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    // The heart image that will be shaking
    public Image heartImage;

    public Image heartImage2;

    public Image heartImage3;

    public Image heartImage4;

    public Image heartImage5;

    // The amount of time the heart image will shake for
    public float shakeDuration = 0.5f;

    // The maximum distance the heart image will shake
    public float shakeAmount = 5f;

    // A reference to the player's health script
    public PlayerHp playerHealth;

    // A reference to the original position of the heart image
    private Vector3 originalPosition;

    void Start()
    {
        // Store the original position of the heart image
        originalPosition = heartImage.transform.position;
        originalPosition = heartImage2.transform.position;
        originalPosition = heartImage3.transform.position;
        originalPosition = heartImage4.transform.position;
        originalPosition = heartImage5.transform.position;

        // Subscribe to the OnDamageTaken event of the player's health script
        playerHealth.DamageTaken += DamageTaken;
    }

    void DamageTaken()
    {
        // Start shaking the heart image
        StartCoroutine(ShakeHeart());
    }

    IEnumerator ShakeHeart()
    {
        // Keep shaking the heart image for the specified duration
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            // Calculate a new position for the heart image using Perlin noise
            float x = Mathf.PerlinNoise(Time.time, 0f) * shakeAmount * 2 - shakeAmount;
            float y = Mathf.PerlinNoise(0f, Time.time) * shakeAmount * 2 - shakeAmount;
            Vector3 newPosition = new Vector3(x, y, 0f);

            // Set the new position of the heart image
            heartImage.transform.position = originalPosition + newPosition;
            heartImage2.transform.position = originalPosition + newPosition;
            heartImage3.transform.position = originalPosition + newPosition;
            heartImage4.transform.position = originalPosition + newPosition;
            heartImage5.transform.position = originalPosition + newPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Return the heart image to its original position
        heartImage.transform.position = originalPosition;
        heartImage2.transform.position = originalPosition;
        heartImage3.transform.position = originalPosition;
        heartImage4.transform.position = originalPosition;
        heartImage5.transform.position = originalPosition;

    }
}
