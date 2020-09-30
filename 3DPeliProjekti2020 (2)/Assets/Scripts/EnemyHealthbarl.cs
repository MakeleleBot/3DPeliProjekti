using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbarl : MonoBehaviour
{
    public Slider Enemyslider;

    public void SetEnemyMaxHealth(int health)
    {
        Enemyslider.maxValue = health;
        Enemyslider.value = health;
    }

    public void SetEnemyHealth(int health)
    {
        Enemyslider.value = health;
    }


}
