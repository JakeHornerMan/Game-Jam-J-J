using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    
    private IEnumerator coroutine;
    public enum State {up, down, left, right}

    public GameObject gamemanager;
    public State action;

    public float distance;

    private RaycastHit2D view;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        Look();
        FoundPlayer();
    }

    public void Look(){
        if(action == State.up){
            view = Physics2D.Raycast(transform.position, Vector2.up * distance);
            Debug.DrawRay(transform.position, Vector2.up * distance, Color.green);
        }
        else if(action == State.down){
            view = Physics2D.Raycast(transform.position, -Vector2.up * distance);
            Debug.DrawRay(transform.position, -Vector2.up * distance, Color.green);
        } 
        else if(action == State.left){
            view = Physics2D.Raycast(transform.position, Vector2.left * distance);
            Debug.DrawRay(transform.position, Vector2.left * distance, Color.green);
        }
        else if(action == State.right){
            view = Physics2D.Raycast(transform.position, Vector2.right * distance);
            Debug.DrawRay(transform.position, Vector2.right * distance, Color.green);
        }  

        if (view.collider.tag == "Player"){
            //GameObject gamemanager = FindObjectOfType<GameManager>();
            //gamemanager.GetComponent<GameManager>().GameOver();
            Debug.Log(view.collider.tag);
        }
    }

    public void FoundPlayer(){
        
    }

}
