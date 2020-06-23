using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    // config params
    float gameSpeed = 0.5f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;


    // state variables
    [SerializeField] int currentScore = 0;

    int numLevel = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Score") != null)
        {
            //Debug.Log(currentScore);
            currentScore = PlayerPrefs.GetInt("Score");
            scoreText.text = PlayerPrefs.GetInt("Score").ToString();   
        }else{
            scoreText.text = currentScore.ToString(); 
        }
        //Debug.Log(PlayerPrefs.GetInt("num_Level"));
    }

    // Update is called once per frame
    void Update () {
        if (PlayerPrefs.GetInt("NumLevel") != null)
        {
         numLevel = PlayerPrefs.GetInt("NumLevel");   
        }
        numLevel = numLevel /10;
        Time.timeScale = gameSpeed+numLevel;
	}

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
        PlayerPrefs.SetInt("Score",currentScore);
    }

    /*public void ResetGame()
    {
        Destroy(gameObject);
    }*/
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
