using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemindEvent : EventVisualParent
{
    public GameObject blinkText;
    public ItemLocker[] chests;
    public ItemLocker missed;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        isHappened = false;

        blinkText = GameObject.FindGameObjectWithTag("BlickTextUI").transform.GetChild(0).gameObject;

        
    }

    private void Update()
    {
        if (Vector3.SqrMagnitude(player.position - transform.position) <= 4.0f && !isHappened)
        {
            
            bool finds = true;

            for (int i = 0; i < chests.Length; i++)
            {
                if (!chests[i].isiterat)
                    finds = false;
            }
            if (finds && !missed.isiterat)
            {
                manager.eventInfo.Add(this);
                if (StageManager.current!=StageState.EVENT)
                manager.SetState(StageState.EVENT);
            }
        }
    }

    public override void Execute()
    {
        base.Execute();


        isHappened = true;
        blinkText.GetComponent<Text>().text = "신발장을 안 열어봤는데...";
        blinkText.GetComponent<Animator>().SetTrigger("Blink");
        manager.callEnd.Push(this);
        

    }
}
