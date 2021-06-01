using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameovertext;
    public GameObject restartBtn;
    public GameObject menuBtn;
    void Start()
    {
        gameovertext = GameObject.Find("Game Over");
        restartBtn = GameObject.Find("Restart");
        menuBtn = GameObject.Find("Main Menu");


        gameovertext.SetActive(false);
        restartBtn.SetActive(false);
        menuBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver(){
        
        Time.timeScale = 0f;

        gameovertext.SetActive(true);
        restartBtn.SetActive(true);
        menuBtn.SetActive(true);
    }

    public void Restart(){
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Menu(){

    }

}
