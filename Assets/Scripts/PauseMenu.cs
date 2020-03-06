
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

        Debug.Log("SCHEISSER");
    }


 
    public void ResumeButton()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }


    public void QuitButton()

    {
        SceneManager.LoadScene("Main Menu");
    }
}