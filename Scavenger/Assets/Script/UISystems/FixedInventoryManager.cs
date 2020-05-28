using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedInventoryManager : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject slotPrefab;

    private void Awake()
    {
        int current = 0;
        for (int i=0; i<height; i++)
        {
            
            for(int j = 0; j<width; j++)
            {
                GameObject inst = Instantiate(slotPrefab, this.transform);
                FixedInvenSlotClass slot = inst.GetComponent<FixedInvenSlotClass>();

                if (current % width != 0)
                {
                    slot.backNode = transform.GetChild(transform.childCount - 2).GetComponent<FixedInvenSlotClass>();
                    slot.backNode.nextNode = slot;
                }
                if(current -width >= 0)
                {
                    slot.upNode = transform.GetChild(transform.childCount - 1 - width).GetComponent<FixedInvenSlotClass>();
                    slot.upNode.downNode = slot;
                }

                current++;
            }
        }
        
    }
}
