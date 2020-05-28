using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    public Sprite emptyBag;
    public Sprite normalBag;
    public Sprite fullBag;
    private Image bagImg;


    private void Awake()
    {
        bagImg = GetComponent<Image>();
    }
    private void Update()
    {
        if(InventoryManager.weight==0)
        {
            if(bagImg.sprite != emptyBag)
            {
                bagImg.sprite = emptyBag;
            }

            bagImg.sprite = emptyBag;
        }
        else if(InventoryManager.weight>=InventoryManager.weightLimit)
        {
            if (bagImg.sprite != fullBag)
            {
                bagImg.sprite = fullBag;
            }
            bagImg.sprite = fullBag;
        }
        else
        {
            if (bagImg.sprite != normalBag)
            {
                bagImg.sprite = normalBag;
                bagImg.type = Image.Type.Filled;
                bagImg.fillMethod = Image.FillMethod.Vertical;

            }
            bagImg.fillAmount = InventoryManager.weight / InventoryManager.weightLimit;
        }
    }
}
