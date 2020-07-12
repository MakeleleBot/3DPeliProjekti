using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar1 : MonoBehaviour
{
    public Slider Enemyslider2;

    public void SetEnemyMaxHealth2(int health2)
    {
        Enemyslider2.maxValue = health2;
        Enemyslider2.value = health2;
    }

    public void SetEnemyHealth2(int health2)
    {
        Enemyslider2.value = health2;
    }


}
