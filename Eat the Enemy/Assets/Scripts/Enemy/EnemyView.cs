using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    

    public enum State {up, down, left, right, blind}
    public State action;
    public Transform castpointUp;
    public Transform castpointDown;
    public Transform castpointRight;
    public Transform castpointLeft;

    private IEnumerator coroutine;

    public GameObject gamemanager;

    public GameObject soundmanager;

    public float distance;

    private RaycastHit2D view;

    private Animator animator;
    public void Awake(){
        animator = GetComponent<Animator>();
        gamemanager = GameObject.Find("GameManager");
        soundmanager = GameObject.Find("Sound Handler");
    }

    

    // Update is called once per frame
    public void FixedUpdate()
    {
        Look();

    }

    public void Look(){

        if(action == State.up){

            animator.SetInteger("dir", 1);
            

            Vector2 endPos = castpointUp.position + Vector3.up * distance;
            RaycastHit2D hit = Physics2D.Linecast(castpointUp.position, endPos, 1 << LayerMask.NameToLayer("SolidObjects"));
            Debug.DrawLine(castpointUp.position, endPos, Color.blue);

            if (hit.collider != null){
                if(hit.collider.tag == "Player"){
                    Debug.DrawLine(castpointUp.position, endPos, Color.red);
                    Debug.Log(hit.collider.tag);
                    gamemanager.GetComponent<GameManager>().GameOver();
                    
                    soundmanager.GetComponent<SoundManager>().PlaySound("spotted");
                }
            }
            else{
                Debug.DrawLine(castpointUp.position, endPos, Color.green);
            }   
        }

        else if(action == State.down){

            animator.SetInteger("dir", 2);

            Vector2 endPos = castpointDown.position - Vector3.up * distance;
            RaycastHit2D hit = Physics2D.Linecast(castpointDown.position, endPos, 1 << LayerMask.NameToLayer("SolidObjects"));
            Debug.DrawLine(castpointDown.position, endPos, Color.blue);

            if (hit.collider != null){
                if(hit.collider.tag == "Player"){
                    Debug.DrawLine(castpointDown.position, endPos, Color.red);
                    Debug.Log(hit.collider.tag);
                    gamemanager.GetComponent<GameManager>().GameOver();
                    soundmanager.GetComponent<SoundManager>().PlaySound("spotted");
                }
            }
            else{
                Debug.DrawLine(castpointDown.position, endPos, Color.green);
            }
        }

        else if(action == State.left){

            animator.SetInteger("dir", 3);

            Vector2 endPos = castpointLeft.position + Vector3.left * distance;
            RaycastHit2D hit = Physics2D.Linecast(castpointLeft.position, endPos, 1 << LayerMask.NameToLayer("SolidObjects"));
            Debug.DrawLine(castpointLeft.position, endPos, Color.blue);

            if (hit.collider != null){
                if(hit.collider.tag == "Player"){
                    Debug.DrawLine(castpointLeft.position, endPos, Color.red);
                    Debug.Log(hit.collider.tag);
                    gamemanager.GetComponent<GameManager>().GameOver();
                    soundmanager.GetComponent<SoundManager>().PlaySound("spotted");
                }
                else{
                    Debug.DrawLine(castpointLeft.position, endPos, Color.green);
                }
            }
        }
        else if(action == State.blind){

        }

        else if(action == State.right){
            
            animator.SetInteger("dir", 4);

            Vector2 endPos = castpointRight.position + Vector3.right * distance;
            RaycastHit2D hit = Physics2D.Linecast(castpointRight.position, endPos, 1 << LayerMask.NameToLayer("SolidObjects"));
            Debug.DrawLine(castpointRight.position, endPos, Color.blue);

            if (hit.collider != null){
                if(hit.collider.tag == "Player"){
                    Debug.DrawLine(castpointRight.position, endPos, Color.red);
                    Debug.Log(hit.collider.tag);
                    gamemanager.GetComponent<GameManager>().GameOver();
                    soundmanager.GetComponent<SoundManager>().PlaySound("spotted");
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

    public void changeState(string dir){
        if (dir == "up"){
            action = State.up;
        }
        else if (dir == "down"){
            action = State.down;
        }
        else if (dir == "left"){
            action = State.left;
        }
        else if (dir == "right"){
            action = State.right;
        } 
    }

    /*public void Spotted()
    {
        Time.timeScale = 0f;

        SoundManager.PlaySound("spotted");
        coroutine = waittoSpotted(2f); // wait one second
        StartCoroutine(coroutine);

    }

    IEnumerator waittoSpotted(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        gamemanager.GetComponent<GameManager>().GameOver();
    }*/

}


