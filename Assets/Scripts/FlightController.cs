// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: Taha Kocak | Student ID: 220444013

using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed  = 45f;  // degrees/second
    [SerializeField] private float yawSpeed    = 45f;  // degrees/second
    [SerializeField] private float rollSpeed   = 45f;  // degrees/second
    [SerializeField] private float thrustSpeed = 5f;   // units/second

    // Task 3-A: Rigidbody reference for physics integration
    private Rigidbody rb;

    void Start()
    {
        // Task 3-B: Cache Rigidbody and disable physics-driven rotation
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // Pitch — Arrow Up/Down rotates around the X-axis
        float pitch = Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right, pitch);

        // Yaw — Arrow Left/Right rotates around the Y-axis
        float yaw = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw);

        // Roll — Q/E keys rotate around the Z-axis
        float roll = 0f;
        if (Input.GetKey(KeyCode.Q))
            roll = rollSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.E))
            roll = -rollSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, roll);
    }

    private void HandleThrust()
    {
        // TODO (Task 3-D): Thrust will be added in a later commit
    }
}
