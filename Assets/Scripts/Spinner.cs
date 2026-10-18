using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f; // Speed of rotation in degrees per second
    [SerializeField] private float pulseSpeed = 3f; // Speed of pulsing effect
    [SerializeField] private float pulseAmplitude = 0.2f; // Amount of pulsing effect
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 baseScale;
    void Start()
    {
        baseScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World); // Rotate the object around the Y-axis
        float s = 1f+ pulseAmplitude * Mathf.Sin(Time.time * pulseSpeed); // Calculate the pulsing scale factor
        transform.localScale = baseScale * s; // Apply the pulsing scale factor
    }
}
