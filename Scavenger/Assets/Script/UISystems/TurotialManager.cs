using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurotialManager : MonoBehaviour
{
    public GameObject Tutorial;
    public PlayerCharacterController player;
    public GameObject inventory;
    public GameObject chest;
    public GameObject moveTutorial;

    private void Awake()
    {
        Tutorial.SetActive(false);
        moveTutorial.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacterController>();
        chest = GameObject.FindGameObjectWithTag("ChestSlot");
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    private void Update()
    {
        if(InfoInst.tutorial==0 && StageManager.current==StageState.IDLE)
        {
            //Tutorial.SetActive(true);
            moveTutorial.SetActive(true);
            //moveTutorial.GetComponentInChildren<Text>().text = "A  D  로 이동 할 수 있습니다";
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                moveTutorial.SetActive(false);
                InfoInst.tutorial++;
            }
        }
        else if(InfoInst.tutorial==1 )
        {
            if (player.IteractItem != null)
            {
                Tutorial.SetActive(true);
                Tutorial.GetComponentInChildren<Text>().text = "F 로 상호작용 할 수 있습니다";
                if(Input.GetKeyDown(KeyCode.F))
                {
                    Tutorial.SetActive(false);
                    InfoInst.tutorial++;
                }
            }
            else
                Tutorial.SetActive(false);
        }
        else if(InfoInst.tutorial == 2)
        {
            if(chest.activeInHierarchy)
            {
                Tutorial.SetActive(true);
                Tutorial.GetComponentInChildren<Text>().text = "드래그로 아이템을 얻으십시오";
                if(InventoryManager.inventory.WeightCheck()>0)
                {
                    Tutorial.SetActive(false);
                    InfoInst.tutorial++;
                }
            }
        }
        else if(InfoInst.tutorial ==3 && !inventory.activeInHierarchy)
        {
            Tutorial.SetActive(true);
            Tutorial.GetComponentInChildren<Text>().text = "TAB 로 인벤토리를 볼 수 있습니다";
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                Tutorial.SetActive(false);
                InfoInst.tutorial++;
            }
        }
    }
}
