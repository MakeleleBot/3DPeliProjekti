using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Maxhealth = 10000;
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
    public void OnParticleCollision(GameObject other)
    {
        int damage = other.GetComponent<ParticleDamage>().GetDamage();

        ProcessHit(damage);

        if (CurrentHealth <= 0)
        {
            Die();
        }

    }

    void ProcessHit(int damage)
    {
        CurrentHealth -= damage;
        EnemyHB.SetEnemyHealth(CurrentHealth);
    }
  

    void Die()
    {
        Scoretesting.pointCount += 100;
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
