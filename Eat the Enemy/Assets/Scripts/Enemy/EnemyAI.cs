using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int nextSpot;

    private void Start()
    {
        waitTime = startWaitTime;
        nextSpot = 1;
        
        
    }

    private void Update()
    {

        for (int counter = 0; counter < moveSpots.Length; counter++)
        {
            if (nextSpot >= moveSpots.Length)
            {
                nextSpot = 0;
            }

            transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f)
            {


                if (waitTime <= 0)
                {

                    waitTime = startWaitTime;
                    nextSpot = nextSpot + 1;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                


            }


            Debug.Log(nextSpot);
            

        }



       

    }

}
