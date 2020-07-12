using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int Maxhealth2 = 1000;
    public int CurrentHealth2;

    public EnemyHealthbar1 EnemyHB2;
    public GameObject deathEffect;


    public void Start()
    {
        CurrentHealth2 = Maxhealth2;
        EnemyHB2.SetEnemyMaxHealth2(Maxhealth2);
    }
    public void EnemyTakeDamage(int edamage)
    {
        CurrentHealth2 -= edamage;
        EnemyHB2.SetEnemyHealth2(CurrentHealth2);

        if (CurrentHealth2 <= 0)
        {
            Die2();
        }
    }
    public void OnParticleCollision(GameObject other)
    {
        int damage2 = other.GetComponent<ParticleDamage>().GetDamage();

        ProcessHit2(damage2);

        if (CurrentHealth2 <= 0)
        {
            Die2();
        }

    }

    void ProcessHit2(int damage2)
    {
        CurrentHealth2 -= damage2;
        EnemyHB2.SetEnemyHealth2(CurrentHealth2);
    }


    void Die2()
    {
        Scoretesting.pointCount += 50;
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
