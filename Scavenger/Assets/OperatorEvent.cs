using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorEvent : EventVisualParent
{

    public GameObject operatorCanvas;
    float limtime;

    private void Awake()
    {
        limtime = 3.0f;
        Debug.Log("Awake");
        operatorCanvas = GameObject.FindGameObjectWithTag("Operator");
        operatorCanvas.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        gameObject.SetActive(false);
    }

    public override void Execute()
    {
        base.Execute();

        if(limtime==3.0f)
        {
            isHappened = true;
            operatorCanvas.SetActive(true);
            
            PlayerCharacterController.playerSingleton.gameObject.AddComponent<PlayerRun>();
            PlayerCharacterController.playerSingleton.gameObject.GetComponent<PlayerRun>().enabled=false;
            PlayerCharacterController.playerSingleton.StateList.Add(States.RUN,PlayerCharacterController.playerSingleton.gameObject.AddComponent<PlayerRun>());
            PlayerCharacterController.playerSingleton.SetState(States.DELAY);
            PlayerCharacterController.playerSingleton.anim.SetInteger("Run", 0);
        }
        limtime -= Time.deltaTime;

        if(limtime<=0)
        {
            limtime = 3.0f;
            
            
            PlayerCharacterController.playerSingleton.SetState(States.IDLE);
            manager.cam.GetComponent<CameraMove>().enabled = true;
            operatorCanvas.SetActive(false);
            manager.callEnd.Push(this);
        }
    }
    

    private void Update()
    {
        if (Vector3.SqrMagnitude(player.position - transform.position) <= 16.0f && !isHappened)
        {
            manager.eventInfo.Add(this);
            if (StageManager.current != StageState.EVENT)
                manager.SetState(StageState.EVENT);
        }
    }
}
