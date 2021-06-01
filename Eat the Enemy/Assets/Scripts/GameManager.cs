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
    public GameObject quitBtn;

    

    void Start()
    {
        gameovertext.SetActive(false);
        restartBtn.SetActive(false);
        menuBtn.SetActive(false);
        wintext.SetActive(false);
        quitBtn.SetActive(true);
    }

    public void GameOver(){
        
        Time.timeScale = 0f;

        gameovertext.SetActive(true);
        restartBtn.SetActive(true);
        menuBtn.SetActive(true);
    }

    public void Restart(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Menu(){
        SceneManager.LoadScene("Main Menu");
        Debug.Log("button works");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Winner()
    {
        Time.timeScale = 0f;

        menuBtn.SetActive(true);
        restartBtn.SetActive(true);
        wintext.SetActive(true);
    }

    

}
