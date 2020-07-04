using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Maxhealth = 100;
    public int CurrentHealth;

    public EnemyHealthbarl EnemyHB;
    public GameObject deathEffect;


    public void Start()
    {
        CurrentHealth = Maxhealth;
        EnemyHB.SetEnemyMaxHealth(Maxhealth);
    }
    public void EnemyTakeDamage (int edamage)
    {
        CurrentHealth -= edamage;
        EnemyHB.SetEnemyHealth(CurrentHealth);
            
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Enemy enemy = other.GetComponent<Enemy>();

        //if (enemy != null)
        //{

        //}

        if (other.gameObject.CompareTag("FT"))
        {
            EnemyTakeDamage(5);
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
