﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    
    public enum State {up, down, left, right, blind}

    public Transform castpointUp;
    public Transform castpointDown;
    public Transform castpointRight;
    public Transform castpointLeft;

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

    }

    public void Look(){

        if(action == State.up){
            Vector2 endPos = castpointUp.position + Vector3.up * distance;
            RaycastHit2D hit = Physics2D.Linecast(castpointUp.position, endPos, 1 << LayerMask.NameToLayer("SolidObjects"));
            
            if (hit.collider != null){
                if(hit.collider.tag == "Player"){
                    Debug.DrawLine(castpointUp.position, endPos, Color.red);
                    Debug.Log(hit.collider.tag);
                    gamemanager.GetComponent<GameManager>().GameOver();
                }
            }
            else{
                Debug.DrawLine(castpointUp.position, endPos, Color.green);
            }   
        }

        else if(action == State.down){
            Vector2 endPos = castpointDown.position - Vector3.up * distance;
            RaycastHit2D hit = Physics2D.Linecast(castpointDown.position, endPos, 1 << LayerMask.NameToLayer("SolidObjects"));
            
            if (hit.collider != null){
                if(hit.collider.tag == "Player"){
                    Debug.DrawLine(castpointDown.position, endPos, Color.red);
                    Debug.Log(hit.collider.tag);
                    gamemanager.GetComponent<GameManager>().GameOver();
                }
            }
            else{
                Debug.DrawLine(castpointDown.position, endPos, Color.green);
            }
        }

        else if(action == State.left){
            Vector2 endPos = castpointLeft.position + Vector3.left * distance;
            RaycastHit2D hit = Physics2D.Linecast(castpointLeft.position, endPos, 1 << LayerMask.NameToLayer("SolidObjects"));
            
            if (hit.collider != null){
                if(hit.collider.tag == "Player"){
                    Debug.DrawLine(castpointLeft.position, endPos, Color.red);
                    Debug.Log(hit.collider.tag);
                    gamemanager.GetComponent<GameManager>().GameOver();
                }
                else{
                    Debug.DrawLine(castpointLeft.position, endPos, Color.green);
                }
            }
        }
        else if(action == State.blind){

        }

        else if(action == State.right){
            Vector2 endPos = castpointRight.position + Vector3.right * distance;
            RaycastHit2D hit = Physics2D.Linecast(castpointRight.position, endPos, 1 << LayerMask.NameToLayer("SolidObjects"));
            
            if (hit.collider != null){
                if(hit.collider.tag == "Player"){
                    Debug.DrawLine(castpointRight.position, endPos, Color.red);
                    Debug.Log(hit.collider.tag);
                    gamemanager.GetComponent<GameManager>().GameOver();
                }
            }
            else{
                Debug.DrawLine(castpointRight.position, endPos, Color.green);
            } 
        }  
    }

    public void CanSeePlayer(float distance){
        //bool ans = false;

        Vector2 endPos = castpointRight.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(castpointRight.position, endPos, 1 << LayerMask.NameToLayer("SolidObjects"));
        
        if (hit.collider != null){
            Debug.Log(hit.collider.tag);
        }

    }

}


