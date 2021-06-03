using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut1 : MonoBehaviour
{
    public GameObject controls;
    public GameObject enemies;
    public GameObject traps;
    public GameObject eye;

    private void Start()
    {
        controls.SetActive(false);
        enemies.SetActive(false);
        traps.SetActive(false);
        eye.SetActive(false);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TutControls")
        {
            controls.SetActive(true);
 

        }
        else if (collision.gameObject.tag == "TutEnemies")
        {
            enemies.SetActive(true);
    

        }
        else if (collision.gameObject.tag == "TutTraps")
        {
            traps.SetActive(true);
      
            
        }
        else if (collision.gameObject.tag == "TutEye")
        {
            eye.SetActive(true);


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TutControls")
        {
            controls.SetActive(false);
            

        }
        else if (collision.gameObject.tag == "TutEnemies")
        {
            enemies.SetActive(false);
            

        }
        else if (collision.gameObject.tag == "TutTraps")
        {
            traps.SetActive(false);

        }
        else if (collision.gameObject.tag == "TutEye")
        {
            eye.SetActive(false);

        }
    }









}
