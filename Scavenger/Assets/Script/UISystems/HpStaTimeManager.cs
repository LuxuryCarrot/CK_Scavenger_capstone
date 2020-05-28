using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpStaTimeManager : MonoBehaviour
{
    public Image HpBar;
    
    public Text TimeText;
    PlayerCharacterController player;

    public static float time;

    private void Awake()
    {
       

        time = StageInfo.timeLimit;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacterController>();
    }

    private void Update()
    {
        HpBar.fillAmount = player.hp / PlayerDefaultInfo.hpMax;
        
        TimeText.text = ((int)time).ToString();



        if(StageManager.current!=StageState.INTRO && time >=0)
          time -= Time.deltaTime;
    }
}
