using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void ButtonStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ButtonCredit()
    {
        SceneManager.LoadScene(2);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

}
