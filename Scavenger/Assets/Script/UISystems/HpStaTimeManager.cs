using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpStaTimeManager : MonoBehaviour
{
    Image HpBar;
    Image StaBar;
    Text TimeText;
    PlayerCharacterController player;

    public static float time;

    private void Awake()
    {
        HpBar = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        StaBar = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
        TimeText = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>();

        time = StageInfo.timeLimit;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacterController>();
    }

    private void Update()
    {
        HpBar.fillAmount = player.hp / PlayerDefaultInfo.hpMax;
        StaBar.fillAmount = player.sta / PlayerDefaultInfo.sta;
        TimeText.text = ((int)time).ToString();



        if(StageManager.current!=StageState.INTRO && time >=0)
          time -= Time.deltaTime;
    }
}
