using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMoveEvent : EventVisualParent
{
    
    public Vector3 playerMove;
    public Camera destiCam;
    public static Camera blendCam;
    public float temp;
    public bool afterPlayerRotate;
    public static Camera usingCam;
    float possessview = 0;
    float playerZpos;
    bool opened;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerZpos = player.transform.position.z;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        if(blendCam==null)
        {
            blendCam = GameObject.FindGameObjectWithTag("BlendCam").GetComponent<Camera>();
            blendCam.gameObject.SetActive(false);
            if(usingCam==null)
            usingCam = Camera.main;
        }
        isHappened = false;
        opened = false;
        temp = 2.0f;
        Debug.Log(transform.position);
        
    }
    public override void Execute()
    {
        
        base.Execute();
        if (!isHappened)
        {
            isHappened = true;
            player.GetComponent<PlayerCharacterController>().SetState(States.IDLE);
            player.GetComponent<PlayerCharacterController>().anim.SetInteger("Run", 1);
            
            Vector3 possessPos = usingCam.transform.position;
            Vector3 possessRot = usingCam.transform.rotation.eulerAngles;
            Debug.Log("Possess");
            possessview = usingCam.fieldOfView;
            usingCam.gameObject.SetActive(false);
            blendCam.gameObject.SetActive(true);
            blendCam.transform.position = possessPos;
            blendCam.fieldOfView = possessview;
            blendCam.transform.rotation = Quaternion.Euler(possessRot.x, possessRot.y, possessRot.z);
            float angle = afterPlayerRotate ? 180 : 0;
            player.transform.GetChild(0).rotation = Quaternion.Euler(0, angle, 0);
            if(!opened)
            {
                opened = true;
                if(GetComponentInParent<Animator>()!=null)
                  GetComponentInParent<Animator>().SetTrigger("Open");
            }
            if (!afterPlayerRotate)
                player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);

        }
        temp -= Time.deltaTime;

        blendCam.transform.position +=
            (destiCam.transform.position - blendCam.transform.position) * Time.deltaTime*1.5f;

        blendCam.transform.rotation =
            Quaternion.Lerp(blendCam.transform.rotation, destiCam.transform.rotation, Time.deltaTime*1.5f);

        player.transform.position += playerMove * Time.deltaTime;
        Debug.Log(destiCam.fieldOfView - possessview);
        blendCam.fieldOfView += (destiCam.fieldOfView - possessview) * Time.deltaTime/2;

        if(temp<=0)
        {
            
            player.GetComponent<PlayerCharacterController>().horizon = afterPlayerRotate;
            blendCam.gameObject.SetActive(false);
            destiCam.gameObject.SetActive(true);
            usingCam = destiCam;
            isHappened = false;
            temp = 2.0f;
            if (afterPlayerRotate)
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, playerZpos);
            manager.callEnd.Push(this);
        }
    }
    public void Moveto()
    {
        manager.eventInfo.Add(this);
        if (StageManager.current != StageState.EVENT)
            manager.SetState(StageState.EVENT);
    }
}
