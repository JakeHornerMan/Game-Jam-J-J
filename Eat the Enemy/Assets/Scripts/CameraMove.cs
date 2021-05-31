using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pos;
    private GameObject player;

    private GameObject cam;

    public float valuechange;
   void Start()
    {
        player = GameObject.Find("player");
        cam = GameObject.Find("Main Camera");
        pos = player.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(pos.position.x, pos.position.y,cam.transform.position.z);

        if(Input.GetKeyDown(KeyCode.Q) && cam.transform.position.z <= -8){
            transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + valuechange);
        }
        else if(Input.GetKeyDown(KeyCode.E) && cam.transform.position.z >= -14){
            transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z - valuechange);
        }
    }
}
