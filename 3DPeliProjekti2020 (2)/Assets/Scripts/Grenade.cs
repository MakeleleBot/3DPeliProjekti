using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    float countdown;
    bool hasExploded = false;
    public float radius = 5f;
    public float force = 700f;

    public GameObject ExplosoinEff;

    private void Start()
    {
        countdown = delay;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(ExplosoinEff, transform.position, transform.rotation);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObjects in collidersToDestroy)
        {

            Enemy enem = nearbyObjects.GetComponent<Enemy>();
            if(enem != null)
            {
                enem.CurrentHealth -= 50;
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObjects in collidersToMove)
        {
            Rigidbody rb = nearbyObjects.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}
