using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
   
    public bool eatable1 = false;
    public bool eatable2 = false;
    public bool eatable3 = false;

    public int action = 0;
    private bool isMoving;
    private Vector2 input;

    private Animator animator;
    public void Awake(){
        animator = GetComponent<Animator>();
    }

    //movement
    private void Update()
    {

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

            Destroy(gameObject); 

            if(eatable1 == false)
            {
                Debug.Log("I am dead");
            }


        }
        else if(collision.gameObject.tag == "Eatable1")
        {
            eatable1 = true;
            Destroy(collision.gameObject);

        }

    }

}
