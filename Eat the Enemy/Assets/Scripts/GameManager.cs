using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameovertext;
    void Start()
    {
        gameovertext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver(){
        gameovertext.SetActive(true);
    }

}
