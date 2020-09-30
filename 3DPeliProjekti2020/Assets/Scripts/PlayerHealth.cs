using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentHealth < 0)
        //{
        //    KillMe();
        //}
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void HealthPickUp(int health)
    {
        currentHealth += health;

        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Enemy")
        //{
        //    Debug.Log("apuaa");
        //    TakeDamage(1);
        //    healthBar.SetHealth(currentHealth);
        //}
        if(other.gameObject.CompareTag("HP"))
        {
            HealthPickUp(20);
            healthBar.SetHealth(currentHealth);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("AttackSphere"))
        {
            TakeDamage(20);
        }

        if (other.gameObject.CompareTag("asd"))
        {
            gm.points += 100;
        }
    }

    //public void KillMe()
    //{
    //        Destroy(gameObject);
    //}



}
