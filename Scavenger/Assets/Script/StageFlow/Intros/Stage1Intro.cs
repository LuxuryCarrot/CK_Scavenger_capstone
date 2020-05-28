using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Intro : IntroVisualParent
{

    float temp;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        
        isHappened = false;

        temp = 8;

        
    }

    private void Start()
    {
        player.GetComponent<PlayerCharacterController>().SetState(States.INTRO);
        manager.introInfo = this;
        manager.cam.GetComponent<Animator>().SetTrigger("Intro");
        
    }

    public override void Execute()
    {
        base.Execute();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            temp = 7;
            player.GetComponent<PlayerCharacterController>().SetState(States.IDLE);
            isHappened = true;
            manager.cam.GetComponent<Animator>().enabled = false;
            if (manager.cam.transform.childCount != 0)
                Destroy(manager.cam.transform.GetChild(0).gameObject);

            player.transform.position = new Vector3(-22, 1.08f, 0.9583f);

            manager.SetState(StageState.IDLE);
        }

        temp -= Time.deltaTime;

        if (temp >= 7.0f)
            return;

        player.GetComponent<PlayerCharacterController>().anim.SetInteger("Run", 1);

        if (temp <= 2.0f)
        {
            player.GetComponent<PlayerCharacterController>().anim.SetInteger("Run", 0);
            

            if(temp<=0)
            {
                temp = 7;
                player.GetComponent<PlayerCharacterController>().SetState(States.IDLE);
                isHappened = true;
                manager.cam.GetComponent<Animator>().enabled = false;
                if (manager.cam.transform.childCount != 0)
                    Destroy(manager.cam.transform.GetChild(0).gameObject);
                
                manager.SetState(StageState.IDLE);
            }

            return;
        }

        player.transform.position += new Vector3(2, 0, 0) * Time.deltaTime;

    }

    
}
