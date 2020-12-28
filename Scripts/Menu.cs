using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused = false;

    private void pauseGame()
    {
        if(isPaused)
        {
            ActivateMenu();
            
        }
        
        else
        {
            DeactivateMenu();
        } 
            
        
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        isPaused = false;
        pauseMenuUI.SetActive(true);
    }

    void DeactivateMenu()
    {
        Time.timeScale = 1;
        isPaused = true;
        pauseMenuUI.SetActive(false);
    }


}
