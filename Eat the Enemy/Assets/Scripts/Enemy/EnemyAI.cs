using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public MovePoint[] moveSpots;
    private int nextSpot;

    

    private void Start()
    {
        waitTime = startWaitTime;
        nextSpot = 1;
        GetComponent<EnemyView>().changeState(moveSpots[nextSpot].FacingDirection);
        
    }

    private void Update()
    {
        
        for (int counter = 0; counter < moveSpots.Length; counter++)
        {

            

            if (nextSpot >= moveSpots.Length)
            {
                nextSpot = 0;
                GetComponent<EnemyView>().changeState(moveSpots[nextSpot].FacingDirection);
            }

            transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].StopPoint, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[nextSpot].StopPoint) < 0.2f)
            {
                

                if (waitTime <= 0)
                {

                    waitTime = startWaitTime;
                    nextSpot = nextSpot + 1;
                    GetComponent<EnemyView>().changeState(moveSpots[nextSpot].FacingDirection);
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


[System.Serializable]
public class MovePoint {
    public string FacingDirection;
    public Vector2 StopPoint;
}
