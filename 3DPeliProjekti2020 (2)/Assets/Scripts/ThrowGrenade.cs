using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject grenadePrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Throw();
        }
    }

    void Throw()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
