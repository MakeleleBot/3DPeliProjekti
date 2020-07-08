using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIACTIONS : MonoBehaviour
{
    public GameObject DeathPanel;
    public GameObject PausePanel;

    public PlayerHealth PH;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(PH.currentHealth <0)
        {
            Time.timeScale = 0;
            DeathPanel.SetActive(true);
        }

        if(Input.GetKeyDown("escape"))
        {
            GameIsPaused();
        }

    }

    public void GameIsPaused()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);

    }

    

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
