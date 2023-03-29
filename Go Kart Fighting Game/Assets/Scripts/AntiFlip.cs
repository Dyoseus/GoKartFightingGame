using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiFlip : MonoBehaviour {

    // The maximum amount of rotation allowed before the go-kart is prevented from flipping over completely.
    public float maxRotation = 30f;

    // The speed at which the go-kart rocks back and forth.
    public float rockSpeed = 10f;

    // The maximum angle at which the go-kart can rock back and forth.
    public float maxRockAngle = 10f;

    // The current angle of the go-kart's body.
    private float currentAngle = 0f;

    // Update is called once per frame
    void Update () {
        // Get the rotation around the z-axis of the go-kart's body.
        float zRotation = transform.rotation.eulerAngles.z;

        // If the zRotation is greater than the maxRotation or less than -maxRotation, prevent the go-kart from flipping over.
        if (zRotation > maxRotation && zRotation < 360f - maxRotation || zRotation < -maxRotation && zRotation > -360f + maxRotation) {
            // Reset the rotation of the go-kart's body to the maximum allowed rotation.
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Sign(zRotation) * maxRotation);
        }

        // Rotate the go-kart's body back and forth.
        currentAngle += Time.deltaTime * rockSpeed;
        currentAngle = Mathf.Clamp(currentAngle, -maxRockAngle, maxRockAngle);
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }
}
