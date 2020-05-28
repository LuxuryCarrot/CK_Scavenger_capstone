using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static float weight;
    public static float weightLimit;
    public static int width;
    public static int height;
    public static InventoryManager inventory;

    private void Awake()
    {
        weightLimit = PlayerDefaultInfo.maxWei;
        weight = 0;
        inventory = this;
    }

    private void Update()
    {
        
    }

    public float WeightCheck()
    {
        float wei=0;
        Debug.Log("Check");

        for(int i=0; i<transform.childCount; i++)
        {
            if(transform.GetChild(i).childCount!=0)
            wei+=
              transform.GetChild(i).GetChild(0).GetComponent<ItemInInven>().weight;
        }

        weight = wei;
        return weight;
    }
    

}
