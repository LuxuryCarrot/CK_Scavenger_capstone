using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitch : ItemParent
{
    public GameObject[] sparks;
    public GameObject redBut;

    public override void iteract()
    {
        base.iteract();
        for(int i=0; i<sparks.Length; i++)
        {
            if (sparks[i].activeInHierarchy)
            {
                sparks[i].SetActive(false);
                redBut.SetActive(true);
            }
            else
            {
                sparks[i].SetActive(true);
                redBut.SetActive(false);
            }
        }
        player.GetComponent<PlayerCharacterController>().isIterating = false;
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
