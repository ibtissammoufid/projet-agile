using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level : MonoBehaviour {

    // parameters
    [SerializeField] int breakableBlocks;  // Serialized for debugging purposes

    // cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("numLevel"));
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        int numLevel;
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            numLevel = PlayerPrefs.GetInt("NumLevel");   
            if(numLevel<4){
                numLevel += 1;
            }
            PlayerPrefs.SetInt("NumLevel",numLevel);
            PlayerPrefs.Save();
            sceneloader.LoadNextScene();
        }
    }

}
