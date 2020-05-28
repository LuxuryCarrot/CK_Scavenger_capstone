using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : EventVisualParent
{
    float temp;
    

    private void Awake()
    {
        GetComponent<Animator>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        temp = 0;
    }

    

    public override void Execute()
    {
        base.Execute();
        temp += Time.deltaTime;
        
        GetComponent<Animator>().enabled = true;
        if (temp >= 5.0f)
        {
            SceneManager.LoadScene(5);
        }
    }
}