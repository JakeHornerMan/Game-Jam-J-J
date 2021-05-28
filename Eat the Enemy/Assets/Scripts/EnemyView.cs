using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public enum State {up, down, left, right}

    public float distance;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        Look();
    }

    public void Look(){
        
        RaycastHit2D view = Physics2D.Raycast(transform.position, Vector2.up, distance);
        Debug.DrawRay(transform.position, Vector2.up * distance, Color.green);
    }
}
