using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
   public void WhenIClickTheMenuButton()
   {
       Time.timeScale = 0;
       pauseMenu.SetActive(true);
   }

   public void ResumeButton()
   {
       Time.timeScale = 1;
       pauseMenu.SetActive(false);
   }

    public void RestartButton()
   {
       
   }


   public void QuitButton()
   {
    SceneManager.LoadScene("Main Menu");
   }
}
