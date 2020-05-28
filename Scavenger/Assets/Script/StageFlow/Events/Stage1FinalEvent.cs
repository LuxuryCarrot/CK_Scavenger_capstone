using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1FinalEvent : EventVisualParent
{
    public GameObject[] endObjs;
   
    public string triggerItem;
    public string trigger2;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        isHappened = false;
        for (int i = 0; i < endObjs.Length; i++)
        {
            endObjs[i].SetActive(false);
        }
    }

    public override void Execute()
    {
        base.Execute();

        if (!isHappened)
        {
            isHappened = true;
            manager.cam.GetComponent<CameraMove>().enabled = false;
            for(int i=0; i<endObjs.Length; i++)
            {
                endObjs[i].SetActive(true);
            }
        }

       
        
        manager.cam.transform.position = new Vector3(player.position.x,
            player.position.y + 1.2f,
            -21.7f) + new Vector3(Random.Range(-0.1f, 0.1f), 0, 0);
        manager.cam.orthographicSize = 5.0f - player.transform.position.z / 5f;
        manager.cam.transform.rotation = Quaternion.Euler(0, 0, 0);

        //if (limTime <= 0)
        //{
        //    limTime = 1.0f;
        //    manager.callEnd.Push(this);
        //    Debug.Log(manager.eventInfo.Count);
        //    isHappened = true;
        //    player.GetComponent<PlayerCharacterController>().hp -= 20;
        //    //manager.SetState(StageState.IDLE);
        //}
    }

    private void Update()
    {
        if (Vector3.SqrMagnitude(player.position - transform.position) <= 9.0f && !isHappened)
        {
            
            bool findkey = false;

            GameObject inv = player.GetComponent<PlayerCharacterController>().Inventory;

            for (int i = 0; i < inv.transform.GetChild(0).GetChild(0).childCount; i++)
            {
                if (inv.transform.GetChild(0).GetChild(0).GetChild(i).childCount != 0)
                    if (inv.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).GetComponent<ItemInInven>().name == triggerItem)
                        findkey= true;
            }
            for (int i = 0; i < inv.transform.GetChild(0).GetChild(0).childCount; i++)
            {
                if (inv.transform.GetChild(0).GetChild(0).GetChild(i).childCount != 0)
                    if (inv.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).GetComponent<ItemInInven>().name == trigger2)
                        findkey = true;
            }

            if (StageManager.current != StageState.EVENT && findkey)
            {
                manager.eventInfo.Add(this);
                manager.SetState(StageState.EVENT);
            }
        }
    }
}
