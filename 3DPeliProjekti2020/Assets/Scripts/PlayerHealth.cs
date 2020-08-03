using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentHealth < 0)
        //{
        //    KillMe();
        //}
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void HealthPickUp(int health)
    {
        currentHealth += health;

        if(currentHealth>100)
        {
            currentHealth = 100;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("apuaa");
            TakeDamage(1);
            healthBar.SetHealth(currentHealth);
        }
        if(other.gameObject.CompareTag("HP"))
        {
            HealthPickUp(20);
            healthBar.SetHealth(currentHealth);
            Destroy(other.gameObject);
        }
    }

    //public void KillMe()
    //{
    //        Destroy(gameObject);
    //}



}
