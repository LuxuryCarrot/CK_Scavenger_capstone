using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlotManager : MonoBehaviour
{

    public PlayerCharacterController player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacterController>();
    }

    public void CloseButtonOn()
    {
        
        player.IteratScript.InvenRelease();
        
        player.isIterating = false;
        
        
        player.anim.SetInteger("Run", 0);
        
        if (player.Inventory.activeInHierarchy)

            player.Inventory.SetActive(false);
        
        this.gameObject.SetActive(false);
        
    }
}
