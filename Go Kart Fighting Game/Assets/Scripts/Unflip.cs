using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unflip : MonoBehaviour
{
    public float liftForce = 5.0f;
    public float torqueForce = 10.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Apply upward force to lift the car
            rb.AddForce(Vector3.up * liftForce, ForceMode.Impulse);

            // Calculate torque to apply to flip the car
            Vector3 torque = new Vector3(0, 0, -rb.rotation.z * torqueForce);
            rb.AddTorque(torque, ForceMode.Impulse);
        }
    }
}