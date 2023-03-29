using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFIre : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(projectile, firePoint.position, transform.rotation);
        }
        
    }
}
