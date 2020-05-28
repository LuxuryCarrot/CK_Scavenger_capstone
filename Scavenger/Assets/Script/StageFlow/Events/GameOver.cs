using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : EventVisualParent
{
    float temp;

    private void Awake()
    {
        GetComponent<Animator>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        temp = 0;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Update()
    {
        if ((player.GetComponent<PlayerCharacterController>().hp <= 0 || HpStaTimeManager.time <=0) && !transform.GetChild(0).gameObject.activeInHierarchy)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            manager.eventInfo.Add(this);
            manager.SetState(StageState.EVENT);
        }
    }

    public override void Execute()
    {
        base.Execute();
        temp += Time.deltaTime;
        if(temp<=4.0f)
        {
            Camera.main.fieldOfView -= 2.5f * Time.deltaTime;
        }
        
        GetComponent<Animator>().enabled = true;
        
    }
    public void RestartButtonOn()
    {
        SceneManager.LoadScene(4);
    }
}
