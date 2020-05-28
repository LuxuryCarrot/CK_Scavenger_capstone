using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletricShock : EventVisualParent
{
    float limtime;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        isHappened = false;

        limtime = 1.0f;
    }
    public override void Execute()
    {
        
        if (isHappened)
            return;
        base.Execute();
        limtime -= Time.deltaTime;
        player.GetComponent<PlayerCharacterController>().hp -= 20 * Time.deltaTime;
        
        if(player.GetComponent<PlayerCharacterController>().current!=States.IDLE)
           player.GetComponent<PlayerCharacterController>().SetState(States.IDLE);

        player.GetComponent<PlayerIdle>().stopMove = true;
        if(player.GetComponent<PlayerCharacterController>().anim.GetInteger("Run")!=0)
            player.GetComponent<PlayerCharacterController>().anim.SetInteger("Run", 0);
        player.GetComponent<PlayerCharacterController>().anim.SetBool("Elec", true);

        if (limtime<=0)
        {
            isHappened = true;
            player.GetComponent<PlayerIdle>().stopMove = false;
            player.GetComponent<PlayerCharacterController>().anim.SetBool("Elec", false);
        }
    }

    private void Update()
    {
        if (isHappened)
        {
            limtime += Time.deltaTime;
            if (limtime >= 1.0f)
            {
                limtime = 1.0f;
                isHappened = false;
            }
        }
    }
}
