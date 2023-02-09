using UnityEngine;

public class ScaleBoxCollider : MonoBehaviour
{
    public BoxCollider boxCollider;
    private Vector3 originalScale;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        originalScale = transform.localScale;
        boxCollider.isTrigger = true; // Set the BoxCollider as a trigger
    }

    void Update()
    {
        boxCollider.size = originalScale;
    }
}




