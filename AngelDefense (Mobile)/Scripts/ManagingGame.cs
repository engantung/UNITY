using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagingGame : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 5f;
    public float nextDelay = 5f;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", 10f);
            //Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ProceedNextLevel()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("NEXT LEVEL");
            Invoke("NextLevel", 10f);
            //NextLevel();
        }
    }
    
    void NextLevel()
    {
        //yield return new WaitForSeconds(nextDelay);
        Scene sceneLoaded=SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneLoaded.buildIndex +1);
    }
}
