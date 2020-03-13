
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class
PauseMenu : MonoBehaviour



{

    

    public void WhenIClickTheMenuButton()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }


 
    public void ResumeButton()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }


    public void RestartButton()
    {
        SceneManager.LoadScene("FinalScene");
        Time.timeScale = 1;
    }


    public void QuitButton()

    {
        SceneManager.LoadScene("Main Menu");
    }
}