using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLadder : ItemParent
{
    
    public GameObject IteratWith;

    public override void iteract()
    {
        base.iteract();
        
        player.GetComponent<PlayerCharacterController>().SetState(States.CLIME);
    }
    private void Update()
    {
        if (Vector3.SqrMagnitude(player.transform.position - transform.position) <= 4.0f)
        {
            if (player.GetComponent<PlayerCharacterController>().IteractItem == null)
            {
                player.GetComponent<PlayerCharacterController>().IteractItem = this.gameObject;
                player.GetComponent<PlayerCharacterController>().IteratScript = this;
            }
        }
    }
}
