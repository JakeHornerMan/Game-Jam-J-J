using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
     private IEnumerator coroutine;
    public List<MovePoint> MovePointList = new List<MovePoint>();
    private int PosNum; 

    public float moveSpeed;
    public float resttime;

    void Start()
    {
        PosNum = 1;

        MoveToPoint(PosNum);
    }

    // Update is called once per frame
    public void MoveToPoint(int i){
        Movement(MovePointList[i].StopPoint);
        Facing(MovePointList[i].FacingDirection);
    } 

    IEnumerator Movement(Vector3 targetPos)
    {
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        coroutine = waittomove(resttime);
        StartCoroutine(coroutine);
    }

    IEnumerator waittomove(float _waitTime){
        yield return new WaitForSeconds(_waitTime);

        if(PosNum < MovePointList.Count){
            PosNum = PosNum + 1;
            MoveToPoint(PosNum);
        }
        else if (PosNum == MovePointList.Count){
            PosNum = PosNum - 1;
            MoveToPoint(PosNum);
        }
        else if (PosNum == 0){
            PosNum = PosNum + 1;
            MoveToPoint(PosNum);
        }  
    }

    public void Facing(string facingDir){

    }
}

