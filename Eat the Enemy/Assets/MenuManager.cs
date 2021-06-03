﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Start(){
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    public void PlayTutorial(){
        SceneManager.LoadScene("Tutorial");
    } 
    public void Level1(){
        SceneManager.LoadScene("Level 1");
    } 

    public void Level2(){
        SceneManager.LoadScene("Level 3");
    }
    public void Level3(){
        SceneManager.LoadScene("Level 2");
    } 
    public void Level4(){
        SceneManager.LoadScene("Level 4");
    }

    public void Level5(){
        SceneManager.LoadScene("Level 5");
    }   
}
