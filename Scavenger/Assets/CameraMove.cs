using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {


        if (StageManager.current == StageState.EVENT)
            return;

        if(StageManager.current == StageState.INTRO)
        {
            
            return;
        }

        //transform.position = new Vector3(player.position.x, 
        //    player.position.y + 6.0f -player.transform.position.z*0.3f,
        //    -22);
        //GetComponent<Camera>().orthographicSize = 5.0f - player.transform.position.z / 5f;
        //transform.rotation = Quaternion.Euler(12- player.transform.position.z*1.0f, 0,0);

        transform.position = new Vector3(player.position.x,
            player.position.y + 1.2f, -21.7f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
