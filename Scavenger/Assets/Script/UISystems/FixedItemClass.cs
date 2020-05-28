using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FixedItemClass : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static FixedItemClass dragging;
   
    public GameObject Dragcanvas;
    public Transform oldParent;
    public ItemInInven itemInfo;

    // Start is called before the first frame update
    void Awake()
    {
        dragging = null;
        oldParent = null;
        Dragcanvas = GameObject.FindGameObjectWithTag("DragCanvas");
        
        itemInfo = GetComponent<ItemInInven>();

        
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragging.transform.position = eventData.position - new Vector2(-25*(itemInfo.width-1),25*(itemInfo.height-1));
        dragging.transform.rotation = Quaternion.identity;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragging.transform.parent == Dragcanvas.transform)
            dragging.oldParent.GetComponent<FixedInvenSlotClass>().ItemGetIn(dragging);

        //dragging.transform.localPosition = new Vector3(25*(itemInfo.width-1), -25*(itemInfo.height-1), 0);
        InventoryManager.inventory.WeightCheck();
        dragging = null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        FixedItemClass.dragging = this;
        //FixedItemClass.dragging.oldParent = FixedItemClass.dragging.transform.parent;
        FixedItemClass.dragging.transform.parent = FixedItemClass.dragging.Dragcanvas.transform;
        FixedItemClass.dragging.transform.position = eventData.position;
        Debug.Log("Begin");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ItemInfoCanvas.canvas.gameObject.SetActive(true);
        ItemInfoCanvas.canvas.sprite =  Resources.Load<Sprite>("Sprite/ItemIconRef/"+itemInfo.name) as Sprite;
        ItemInfoCanvas.canvas.SetNativeSize();
        if (itemInfo.name == "InsectRaid")
        {
            ItemInfoCanvas.canvas.transform.position += new Vector3(0, 40, 0);
            for(int i=0; i< ItemInfoCanvas.canvas.transform.childCount; i++)
            {
                ItemInfoCanvas.canvas.transform.GetChild(i).position-= new Vector3(0, 40, 0);
            }
        }
        ItemInfoCanvas.text.text = InfoInst.itemScript[itemInfo.name];
        ItemInfoCanvas.nameText.text = InfoInst.itemName[itemInfo.name];
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemInfo.name == "InsectRaid")
        {
            ItemInfoCanvas.canvas.transform.position -= new Vector3(0, 40, 0);
            for (int i = 0; i < ItemInfoCanvas.canvas.transform.childCount; i++)
            {
                ItemInfoCanvas.canvas.transform.GetChild(i).position += new Vector3(0, 40, 0);
            }
        }
        ItemInfoCanvas.canvas.sprite = null;
        ItemInfoCanvas.text.text = "";
        ItemInfoCanvas.canvas.gameObject.SetActive(false);
    }
}
