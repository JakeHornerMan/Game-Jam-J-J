using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameovertext;
    public GameObject restartBtn;
    public GameObject menuBtn;
    public GameObject wintext;
    public GameObject pauseBtn;
    public GameObject resumeBtn;
    public GameObject pausetext;
    public GameObject nextLevelBtn;
    



    void Start()
    {
        gameovertext.SetActive(false);
        restartBtn.SetActive(false);
        menuBtn.SetActive(false);
        wintext.SetActive(false);
        pauseBtn.SetActive(true);
        resumeBtn.SetActive(false);
        pausetext.SetActive(false);
        nextLevelBtn.SetActive(false);
    }

    public void GameOver(){
        
        Time.timeScale = 0f;

        gameovertext.SetActive(true);
        restartBtn.SetActive(true);
        menuBtn.SetActive(true);
        pauseBtn.SetActive(false);
    }

    public void Restart(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    } 

    public void Menu(){
        SceneManager.LoadScene("Main Menu");
        Debug.Log("button works");
    }

    public void NextLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;

        menuBtn.SetActive(true);
        restartBtn.SetActive(true);
        pausetext.SetActive(true);
        pauseBtn.SetActive(false);
        resumeBtn.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;

        menuBtn.SetActive(false);
        restartBtn.SetActive(false);
        pausetext.SetActive(false);
        pauseBtn.SetActive(true);
        resumeBtn.SetActive(false);

    }

    public void Winner()
    {
        Time.timeScale = 0f;

        pauseBtn.SetActive(false);
        menuBtn.SetActive(true);
        nextLevelBtn.SetActive(true);
        restartBtn.SetActive(true);
        wintext.SetActive(true);
    }

    

}
