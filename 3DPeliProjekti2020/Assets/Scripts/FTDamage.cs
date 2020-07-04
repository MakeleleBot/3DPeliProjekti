using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTDamage : MonoBehaviour
{

    public int damage = 1;



    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnParticleCollision(GameObject other)
    //{
    //    Enemy enemy = other.GetComponent<Enemy>();

    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        Debug.Log("Osuma");
    //        enemy.TakeDamage(damage);
    //    }
    //}

    //public void OnTriggerEnter(Collider other)
    //{
    //    Enemy enemy = other.GetComponent<Enemy>();

    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        Debug.Log("Osuma");
    //        enemy.EnemyTakeDamage(damage);
    //    }
    //}
}
