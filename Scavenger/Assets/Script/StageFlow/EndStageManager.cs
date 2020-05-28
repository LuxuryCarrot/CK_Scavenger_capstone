using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndStageManager : MonoBehaviour
{
    public string[] endItem;
    public string[] enditemSecond;

    public GameObject inven;
    public Transform player;
    public EventVisualParent endEvent;
    public StageManager manager;

    public GameObject EndButton;

    private void Awake()
    {
        EndButton.SetActive(false);
        inven = GameObject.FindGameObjectWithTag("Car").transform.GetChild(0).gameObject;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
    }

    private void Update()
    {
        if (Vector3.SqrMagnitude(player.transform.position - transform.position) <= 16.0f)
        {
            if (IsEnd())
            {
                //manager.eventInfo = endEvent;
                //manager.SetState(StageState.EVENT);
                EndButton.SetActive(true);
            }
        }
    }

    public bool IsEnd()
    {
        int temp = 0;

        for(int i=0; i<endItem.Length; i++)
        {
            for(int j =0; j< inven.transform.childCount; j++)
            {
                
                if(endItem[i] == inven.transform.GetChild(j).GetComponent<ItemInInven>().name)
                {
                    temp++;
                }
            }
        }
        for (int i = 0; i < enditemSecond.Length; i++)
        {
            for (int j = 0; j < inven.transform.childCount; j++)
            {
                
                    if (enditemSecond[i] == inven.transform.GetChild(j).GetComponent<ItemInInven>().name)
                    {
                        temp++;
                    }
            }
        }

        return temp == endItem.Length ? true : false;
    }

    public void EndButtonOn()
    {
        manager.eventInfo.Add(endEvent);
        manager.SetState(StageState.EVENT);
    }
}
