using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int points;
    public static GameMaster status;
    public Text pointsText;
    public static string currentLevel;
    public float health;
    public float previousHealth;
    public float maxHealth;


    void Awake()
    {
        //Tämä varmistaa että on olemassa vain 1 gamemaster, jos peli yrittää tehdä toisen, se tuhotaan.
        if (status == null)
        {
            DontDestroyOnLoad(gameObject);
            status = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        pointsText.text = "Points: ";
    }
    void Update()
    {
        pointsText.text = ("Points: " + points);
    }
}
