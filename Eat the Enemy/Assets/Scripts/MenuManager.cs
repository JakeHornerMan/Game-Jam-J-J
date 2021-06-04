using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject soundmanager;

    public void Start(){
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    public void PlayTutorial(){
        SceneManager.LoadScene("Tutorial");
        soundmanager.GetComponent<SoundManager>().PlaySound("chomp");

    }
    public void Level1(){
        SceneManager.LoadScene("Level 1");
        soundmanager.GetComponent<SoundManager>().PlaySound("chomp");

    }

    public void Level2(){
        SceneManager.LoadScene("Level 2");
        soundmanager.GetComponent<SoundManager>().PlaySound("chomp");

    }
    public void Level3(){
        SceneManager.LoadScene("Level 3");
        soundmanager.GetComponent<SoundManager>().PlaySound("chomp");

    }
    public void Level4(){
        SceneManager.LoadScene("Level 4");
        soundmanager.GetComponent<SoundManager>().PlaySound("chomp");

    }

    public void Level5(){
        SceneManager.LoadScene("Level 5");
        soundmanager.GetComponent<SoundManager>().PlaySound("chomp");

    }
}
