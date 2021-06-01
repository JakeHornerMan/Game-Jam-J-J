using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameovertext;
    public GameObject restartBtn;
    public GameObject menuBtn;
    void Start()
    {
        gameovertext.SetActive(false);
        restartBtn.SetActive(false);
        menuBtn.SetActive(false);
    }

    public void GameOver(){
        
        Time.timeScale = 0f;

        gameovertext.SetActive(true);
        restartBtn.SetActive(true);
        menuBtn.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene("Jake Test");
    }

    public void Menu(){
        SceneManager.LoadScene("Main Menu");
    }

}
