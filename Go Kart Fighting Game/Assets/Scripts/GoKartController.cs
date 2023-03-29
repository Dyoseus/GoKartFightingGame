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
            
        }
    }

    [ServerRpc]
    private void TestServerRpc(){
        
    }
}
