using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClime : PlayerParent
{
    private GameObject iteratWith;
    private float temp;

    public override void BeginState()
    {
        base.BeginState();
        iteratWith = manager.IteractItem.GetComponent<ItemLadder>().IteratWith;
        manager.anim.SetInteger("Run", 4);

        manager.iteratStartPos = manager.IteractItem.transform.position;
        manager.iteratEndPos = manager.IteractItem.GetComponent<ItemLadder>().IteratWith.transform.position;

        if (iteratWith.transform.position.y > manager.IteractItem.transform.position.y)
        {
            manager.anim.SetBool("Clime", true);
        }
        else
        {
            manager.anim.SetBool("Clime", false);
        }
        temp = 0;
    }
    private void Update()
    {
        temp += Time.deltaTime;

        Vector3 deltaMove = Vector3.MoveTowards(
            transform.position,
            manager.iteratEndPos,
            3 * Time.deltaTime
            ) - transform.position;

        
        manager.m_Controller.Move(deltaMove);

        manager.transform.GetChild(0).position = manager.iteratStartPos;
        if (temp>=6.0f)
        {
            temp = 0;
            //manager.transform.position = iteratWith.transform.position;
            manager.transform.GetChild(0).localPosition = new Vector3(0, -1, 0);
            manager.SetState(States.IDLE);
        }
    }
    public override void EndState()
    {
        manager.isIterating = false;
        manager.anim.SetInteger("Run", 0);
        manager.anim.SetBool("Clime", false);
        manager.iteratEndPos = Vector3.zero;
        manager.iteratStartPos = Vector3.zero;
        base.EndState();
        
    }
}
