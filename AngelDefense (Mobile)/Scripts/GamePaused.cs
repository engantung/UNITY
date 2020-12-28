using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class GamePaused : MonoBehaviour
{
  
    public GameObject pausedMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pausedMenu.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("F11") || Input.GetKey(KeyCode.F11))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseTheGame();
            }

        }
        
    }

    public void PauseTheGame()
    {
        pausedMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    /*
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
    */
    public void QuitGame()
    {
        Debug.Log("Has Quit Game");
        Application.Quit();

    }
}





