using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoor : PlayerParent
{
    float temp = 3.0f;
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.SetInteger("Run", 0);
        manager.anim.SetBool("Door", true);
        //Camera.main.GetComponent<CameraMove>().enabled = false;
        temp = 3.0f;
    }

    private void Update()
    {
        
        temp -= Time.deltaTime;
        //Camera.main.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
        if(temp <=0)
        {
            manager.SetState(States.IDLE);
            manager.anim.SetBool("Door", false);
        }
    }

    public override void EndState()
    {
        base.EndState();
        if(temp<=0)
        {
            temp = 3.0f;
            //manager.transform.position += new Vector3(3, 0, 0);
            
            //Camera.main.GetComponent<CameraMove>().enabled = true;
        }
    }
}
