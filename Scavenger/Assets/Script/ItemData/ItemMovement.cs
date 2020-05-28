using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : ItemParent
{
    public float distance;
    public bool isIterat;
    public float zrange;

    private void Awake()
    {
        //distance = 3;
        isIterat = true;
        if (range == 0)
            range = 2;

        types = "밀기";
    }


    public override void iteract()
    {
        base.iteract();
        if(isIterat)
        {
            player.GetComponent<PlayerCharacterController>().SetState(States.PUSH);
        }
    }
    private void Update()
    {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) <= range 
            && Mathf.Abs(player.transform.position.z-transform.position.z) <=zrange)
        {
            if (player.GetComponent<PlayerCharacterController>().IteractItem == null && isIterat)
            {
                //transform.position = new Vector3(transform.position.x, starty, transform.position.z);

                player.GetComponent<PlayerCharacterController>().IteractItem = this.gameObject;
                player.GetComponent<PlayerCharacterController>().IteratScript = this;
                player.GetComponent<PlayerCharacterController>().TexTOut();
            }
        }

        if (transform.rotation.z <= 0 && isIterat)
            isIterat = false;
    }
    
}
