using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    private IEnumerator coroutine;

    public bool canMove;
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
   
    public bool eatable1 = false;
    public bool eatable2 = false;
    public bool eatable3 = false;
  
       
    public GameObject gamemanager;
    public GameObject colorIndicator;

    public bool canPlaySound;
    

    /*public float win;
    public float winPoints = 0;
    public bool dead = false;*/

    

    public int action = 0;
    private bool isMoving;
    private Vector2 input;

    private Animator animator;
    public void Awake(){
        canPlaySound = true;
        animator = GetComponent<Animator>();
        canMove = true;
    }

   

    //movement
    private void Update()
    {
        if(canMove == true){
            checkMove();
        }
    }

    public void checkMove(){

        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //remove diagonal
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                
                animator.SetFloat("inputx", input.x);
                animator.SetFloat("inputy", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }
        animator.SetBool("isMoving", isMoving);

       /* if (dead == true)
        {
            winPoints = winPoints + 1;
        }

        dead = false;*/
    }

    //is character moving
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;

        
    }

    //can you walk on area yes/no
    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }


    //Eating and trap detection
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Trap1")
        {
            if (eatable1 == false)
            {
                Death();
                
                
            }
        }
        else if (collision.gameObject.tag == "Trap2")
        {
            if (eatable2 == false)
            {
                Death();
                
            }
        }
        else if (collision.gameObject.tag == "Trap3")
        {
            if (eatable3 == false)
            {
                Death();

            }
        }
        else if (collision.gameObject.tag == "Eatable1")
        {
            eatable1 = true;
            eatable2 = false;
            eatable3 = false;
            Destroy(collision.gameObject);
            //dead = true;
            colorIndicator.GetComponent<IconColorChange>().greenColor();
            if(canPlaySound ==true){
                SoundManager.PlaySound("chomp");
                coroutine = waittoPlay(0.5f); // wait one second
                StartCoroutine(coroutine);
            }


        }
        else if (collision.gameObject.tag == "Eatable2")
        {

            eatable1 = false;
            eatable2 = true;
            eatable3 = false;
            Destroy(collision.gameObject);
            //dead = true;
            colorIndicator.GetComponent<IconColorChange>().blueColor();
            SoundManager.PlaySound("chomp");

        }
        else if (collision.gameObject.tag == "Eatable3")
        {

            eatable1 = false;
            eatable2 = false;
            eatable3 = true;
            Destroy(collision.gameObject);
            //dead = true;
            colorIndicator.GetComponent<IconColorChange>().redColor();
            SoundManager.PlaySound("chomp");

        }
        else if (collision.gameObject.tag == "NonEatable")
        {
            gamemanager.GetComponent<GameManager>().GameOver();
        }
        else if (collision.gameObject.tag == "Winner")
        {
            SoundManager.PlaySound("winner");
            gamemanager.GetComponent<GameManager>().Winner();
        }
        

    }

    public void Death(){
        canMove = false;
        SoundManager.PlaySound("death");
        coroutine = waittoDeath(0.5f); // wait one second
        StartCoroutine(coroutine);
        
    }

    

    IEnumerator waittoDeath(float _waitTime){
        yield return new WaitForSeconds(_waitTime);
        gamemanager.GetComponent<GameManager>().GameOver();
    }

    IEnumerator waittoPlay(float _waitTime){
        canPlaySound = false;
        yield return new WaitForSeconds(_waitTime);
        canPlaySound = true;
    }

    
}
