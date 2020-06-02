using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDoor : ItemParent
{
    private bool isOpened;
    private float temp;

    private void Awake()
    {
        isOpened = false;
        if (range == 0)
            range = 2;

        temp = 0;
        types = "열기";
    }

    public override void iteract()
    {
        base.iteract();
        if(!isOpened)
        {
            isOpened = true;
            GetComponent<Animator>().SetTrigger("Open");
            player.GetComponent<PlayerCharacterController>().SetState(States.DOOR);
            //GetComponent<DoorOpen>().Open();
        }
    }

    private void Update()
    {
        if(isOpened&&temp<=1.5f)
        {
            temp += Time.deltaTime;
            if(temp>=1.5f)
            {
                GetComponentInParent<BoxCollider>().enabled = false;
            }
        }

        if (Vector3.SqrMagnitude(player.transform.position - transform.position) <= 4.0f)
        {
            if (player.GetComponent<PlayerCharacterController>().IteractItem == null)
            {
                player.GetComponent<PlayerCharacterController>().IteractItem = this.gameObject;
                player.GetComponent<PlayerCharacterController>().IteratScript = this;
                if(!isOpened)
                    player.GetComponent<PlayerCharacterController>().TexTOut();
            }
        }
    }

}
