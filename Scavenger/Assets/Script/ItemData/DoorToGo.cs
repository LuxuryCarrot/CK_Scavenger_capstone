using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToGo : ItemParent
{
   
    public override void iteract()
    {
        base.iteract();
        if (StageManager.current == StageState.IDLE)
        {
            
            GetComponent<RoomMoveEvent>().Moveto();
        }
    }
    private void Update()
    {


        if (Vector3.SqrMagnitude(player.transform.position - transform.position) <= range * range)
        {
            if (player.GetComponent<PlayerCharacterController>().IteractItem == null)
            {
                player.GetComponent<PlayerCharacterController>().IteractItem = this.gameObject;
                player.GetComponent<PlayerCharacterController>().IteratScript = this;
                player.GetComponent<PlayerCharacterController>().TexTOut();
            }
        }
    }
}
