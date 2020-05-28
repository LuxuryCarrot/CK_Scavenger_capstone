using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : EventVisualParent
{
    float limTime;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        isHappened = false;
        limTime = 3.0f;
    }
    public override void Execute()
    {
        base.Execute();
        isHappened = true;
        player.GetComponent<PlayerCharacterController>().anim.SetBool("Door", true);
        manager.cam.GetComponent<CameraMove>().enabled = false;
        limTime -= Time.deltaTime;
        manager.cam.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

        if(limTime<=0)
        {
            limTime = 1.5f;
            manager.callEnd.Push(this);
            player.GetComponent<PlayerCharacterController>().anim.SetBool("Door", false);
            manager.cam.GetComponent<CameraMove>().enabled = true;
            isHappened = true;
        }
    }
    public void Open()
    {
        manager.eventInfo.Add(this);
        player.GetComponent<PlayerCharacterController>().anim.SetInteger("Run", 0);
        
        if (StageManager.current != StageState.EVENT)
            manager.SetState(StageState.EVENT);
    }
}
