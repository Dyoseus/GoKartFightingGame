using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    private float height = 3.0f;
    private float damping = 5.0f;
    private bool smoothRotation = true;
    private bool followBehind = true;
    private float rotationDamping = 10.0f;
    public float angle = -23f;

    void LateUpdate()
    {
        Vector3 wantedPosition;
        if (followBehind)
            wantedPosition = target.TransformPoint(0, height, -distance);
        else
            wantedPosition = target.TransformPoint(0, height, distance);

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        if (smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
            wantedRotation *= Quaternion.Euler(angle, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else
        {
            transform.LookAt(target, target.up);
            transform.RotateAround(target.position, transform.right, angle);
        }
    }
}
