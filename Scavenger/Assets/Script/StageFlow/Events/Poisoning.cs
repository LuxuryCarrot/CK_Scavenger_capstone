using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poisoning : EventVisualParent
{
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();

        isHappened = false;

        
    }
    private void Update()
    {
        player.gameObject.AddComponent<Poison>();
        Debug.Log("Poisoned");
        Destroy(player.gameObject.GetComponent<Poison>());
        Debug.Log("Dest");
    }
}
