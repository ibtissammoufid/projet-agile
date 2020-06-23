using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    int numLevel;



	public void LoadNextScene()
    {
        numLevel = PlayerPrefs.GetInt("NumLevel");   
        SceneManager.LoadScene(numLevel+1);
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
    }

    public void LoadStartScene()
    {
        
        SceneManager.LoadScene(numLevel);
        //FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public static int ActualLevel(){
        return PlayerPrefs.GetInt("NumLevel");
    }

    public static int ActualScore(){
        return PlayerPrefs.GetInt("Score");
    }
}
