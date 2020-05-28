using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FixedInvenSlotClass : MonoBehaviour, IDropHandler
{
    public FixedInvenSlotClass backNode;
    public FixedInvenSlotClass nextNode;
    public FixedInvenSlotClass upNode;
    public FixedInvenSlotClass downNode;
    public FixedItemClass slotIn;

    public bool isEnable;

    public GameObject blinkText;

    private void Awake()
    {
        isEnable = true;
        blinkText = GameObject.FindGameObjectWithTag("BlickTextUI").transform.GetChild(0).gameObject;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.parent.GetComponent<InventoryManager>() != null)
            transform.GetComponentInParent<InventoryManager>().WeightCheck();
        //Debug.Log("!!!");
        if (FixedItemClass.dragging == null)
        {
            //Debug.Log("!!!");
            return;
        }
        if (InventoryManager.weight + FixedItemClass.dragging.itemInfo.weight > InventoryManager.weightLimit
            && transform.parent.GetComponent<InventoryManager>()!=null)
        {
            blinkText.GetComponent<Text>().text = "무게가 꽉찼어...";
            blinkText.GetComponent<Animator>().SetTrigger("Blink");
            return;
        }

        FixedInvenSlotClass startpos = this;
        FixedInvenSlotClass current = startpos;
        bool check = true;

        FixedItemClass.dragging.oldParent.GetComponent<FixedInvenSlotClass>().ItemGetOut();

        check = FindSlotEnable(FixedItemClass.dragging.itemInfo);

        if (!check)
        {
            //startpos = FixedItemClass.dragging.oldParent.GetComponent<FixedInvenSlotClass>();
            //current = startpos;

            //for (int i = 0; i < FixedItemClass.dragging.itemInfo.width; i++)
            //{

            //    for (int j = 0; j < FixedItemClass.dragging.itemInfo.height; j++)
            //    {
            //        current.slotIn = FixedItemClass.dragging;
            //        current.isEnable = false;
            //        if (j < FixedItemClass.dragging.itemInfo.height - 1)
            //            current = current.downNode;
            //    }

            //    if (i < FixedItemClass.dragging.itemInfo.width - 1)
            //    {
            //        startpos = startpos.nextNode;
            //        current = startpos;
            //    }

            //}
            
            return;
        }
        //ItemMoveInst.draggingObj.transform.parent = null;

        ItemGetIn(FixedItemClass.dragging);

        

        //ItemMoveInst.draggingObj.GetComponent<Image>().canvas.sortingOrder = 2;
    }

    public void ItemGetOut()
    {
        ItemInInven info = slotIn.itemInfo;

        FixedInvenSlotClass startpos = this;
        FixedInvenSlotClass current = startpos;

        for (int i=0; i<info.width; i++)
        {
            for(int j=0; j<info.height; j++)
            {
                current.isEnable = true;
                current.slotIn = null;
                if (j < info.height - 1)
                    current = current.downNode;
            }
            if (i < info.width - 1)
            {
                startpos = startpos.nextNode;
                current = startpos;
            }
        }

    }

    public void ItemGetIn(FixedItemClass item)
    {
        //item.transform.parent = this.gameObject.transform;
        

        FixedInvenSlotClass startpos = this;
        FixedInvenSlotClass current = startpos;

        for (int i = 0; i < item.itemInfo.width; i++)
        {

            for (int j = 0; j < item.itemInfo.height; j++)
            {
                current.slotIn = item;
                current.isEnable = false;
                if (j < item.itemInfo.height - 1)
                    current = current.downNode;
            }

            if (i < item.itemInfo.width - 1)
            {
                startpos = startpos.nextNode;
                current = startpos;
            }

        }
        item.oldParent = this.transform;
        item.transform.parent = current.transform;
        item.GetComponent<RectTransform>().sizeDelta
            = new Vector2
            (60 * item.GetComponent<ItemInInven>().width
            , 60 * item.GetComponent<ItemInInven>().height);

        item.transform.localScale = new Vector3(1, 1, 1);
        item.transform.localPosition = new Vector3(-25 * (item.itemInfo.width - 1), 25 * (item.itemInfo.height - 1), 0);
        item.transform.rotation = Quaternion.identity;
        
    }

    public bool FindSlotEnable(ItemInInven info)
    {
        bool check = true;

        FixedInvenSlotClass startpos = this;
        FixedInvenSlotClass current = startpos;

        for (int i = 0; i < info.width; i++)
        {

            for (int j = 0; j < info.height; j++)
            {
                if (!current.isEnable)
                {
                    check = false;
                    break;
                }

                if (j < info.height - 1 && current.downNode == null)
                {
                    check = false;
                    break;
                }

                if (current.downNode != null)
                    current = current.downNode;
            }
            if (!check)
                break;


            if (i < info.width - 1 && current.nextNode == null)
            {
                check = false;
                break;
            }
            else if (i < info.width - 1)
            {
                startpos = startpos.nextNode;
                current = startpos;
            }
        }

        return check;
    }
    private void OnTransformParentChanged()
    {
        Destroy(this.gameObject);
    }

    //private void OnTransformChildrenChanged()
    //{
    //    Debug.Log("!!!");
    //    if(GetComponentInParent<InventoryManager>()!=null)
    //       GetComponentInParent<InventoryManager>().WeightCheck();
    //}

}
