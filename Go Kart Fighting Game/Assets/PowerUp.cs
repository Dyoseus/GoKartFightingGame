using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float rotationSpeed = 10f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            
            Pickup(other);
        }
    }

    void Pickup(Collider player){
        Transform firePoint = player.transform.Find("firePoint");

        if (firePoint != null) {
            if(Input.GetKey(KeyCode.Space)){
                Instantiate(projectile, firePoint.position, firePoint.rotation);
            }
            
        }

        Destroy(gameObject);

    }
}
