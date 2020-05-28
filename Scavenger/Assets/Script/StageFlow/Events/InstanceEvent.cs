using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanceEvent : EventVisualParent
{
    float limTime;
    public GameObject blinkText;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        isHappened = false;

        blinkText = GameObject.FindGameObjectWithTag("BlickTextUI").transform.GetChild(0).gameObject;

        limTime = 2.0f;
    }

    public override void Execute()
    {
        base.Execute();
        isHappened = true;
        manager.cam.GetComponent<CameraMove>().enabled = false;
        blinkText.GetComponent<Text>().text = "여진이 남아 있나보다";
        blinkText.GetComponent<Animator>().SetTrigger("Blink");
        limTime -= Time.deltaTime;
        manager.cam.transform.position = new Vector3(player.position.x,
            player.position.y + 1.2f,
            -21.7f) + new Vector3(Random.Range(-0.1f, 0.1f), 0, 0);
        manager.cam.orthographicSize = 5.0f - player.transform.position.z / 5f;
        manager.cam.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (limTime <=0)
        {
            limTime = 2.0f;
            manager.callEnd.Push(this);
            manager.cam.GetComponent<CameraMove>().enabled = true;
            isHappened = true;
            
            //manager.SetState(StageState.IDLE);
        }
    }

    private void Update()
    {
        if(Vector3.SqrMagnitude(player.position-transform.position) <=16.0f && !isHappened)
        {
            manager.eventInfo.Add(this);
            if(StageManager.current!=StageState.EVENT)
              manager.SetState(StageState.EVENT);
        }
    }
}
