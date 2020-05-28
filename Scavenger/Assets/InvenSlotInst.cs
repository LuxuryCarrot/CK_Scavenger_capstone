using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvenSlotInst : MonoBehaviour, IDropHandler
{
    public GameObject blinkText;

    private void Awake()
    {
        blinkText = GameObject.FindGameObjectWithTag("BlickTextUI").transform.GetChild(0).gameObject;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (InventoryManager.weight + ItemMoveInst.draggingObj.GetComponent<ItemMoveInst>().weight.weight > InventoryManager.weightLimit)
        {
            blinkText.GetComponent<Text>().text = "무게가 꽉찼어...";
            blinkText.GetComponent<Animator>().SetTrigger("Blink");
            return;
        }
        //ItemMoveInst.draggingObj.transform.parent = null;
        ItemMoveInst.draggingObj.transform.parent = this.gameObject.transform;
        ItemMoveInst.draggingObj.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);
        ItemMoveInst.draggingObj.transform.localScale = new Vector3(1, 1, 1);
        ItemMoveInst.draggingObj.transform.localPosition = Vector3.zero;
        
        //ItemMoveInst.draggingObj.GetComponent<Image>().canvas.sortingOrder = 2;
    }

    
}
