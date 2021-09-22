using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject PausePanel, ButtonPause;


    public void tekanButtonPause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void tekanButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void tekanButtonNextStage1()
    {
        SceneManager.LoadScene(1);
    }

    public void tekanButtonNextStage2()
    {
        SceneManager.LoadScene(2);
    }

    public void tekanButtonBackToStage()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void tekanButtonResume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
