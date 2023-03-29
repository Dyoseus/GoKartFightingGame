using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class GoKartController : NetworkBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float gravity = 9.81f;
    public float slopeForce = 5f;
    public float slopeForceRayLength = 1f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private Transform parentTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parentTransform = transform.parent;
    }

    void Update()
    {
        if (IsLocalPlayer){
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = transform.forward * vertical * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
            transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

            // Move the parent along with the child object
            parentTransform.position = rb.position;

            // Check for slope
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, slopeForceRayLength, groundLayer))
            {
                Vector3 slopeForceDirection = Vector3.Cross(hit.normal, transform.right).normalized;
                rb.AddForce(slopeForceDirection * slopeForce, ForceMode.Acceleration);
            }

            // Apply gravity
            rb.AddForce(Vector3.down * gravity);
        }
    }

    [ServerRpc]
    private void TestServerRpc(){
        
    }
}
