using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Maxhealth = 1000;
    public int CurrentHealth;

    public EnemyHealthbarl EnemyHB;
    public GameObject deathEffect;

    private GameMaster gm;


    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        CurrentHealth = Maxhealth;
        EnemyHB.SetEnemyMaxHealth(Maxhealth);
    }
    public void EnemyTakeDamage (int edamage)
    {
        CurrentHealth -= edamage;
        EnemyHB.SetEnemyHealth(CurrentHealth);
            
        if (CurrentHealth <= 0)
        {
 
        }
    }
    public void OnParticleCollision(GameObject other)
    {
        Debug.Log("ottaadamagee");
        int damage = other.GetComponent<ParticleDamage>().GetDamage();

        ProcessHit(damage);

        if (CurrentHealth <= 0)
        {

        }
    }

    void ProcessHit(int damage)
    {
        CurrentHealth -= damage;
        EnemyHB.SetEnemyHealth(CurrentHealth);
    }
  

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        gm.points += 100;
        Destroy(gameObject);
    }
}
