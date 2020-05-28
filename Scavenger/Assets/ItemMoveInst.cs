using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class ItemMoveInst : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject draggingObj;
    public GameObject Dragcanvas;
    private Transform oldParent;
    public ItemInInven weight;

    private void Awake()
    {
        draggingObj = null;
        oldParent = null;
        Dragcanvas = GameObject.FindGameObjectWithTag("DragCanvas");
        
        weight = GetComponent<ItemInInven>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingObj = this.gameObject;
        oldParent = draggingObj.transform.parent;
        draggingObj.transform.parent = Dragcanvas.transform;
        
        
        //draggingObj.transform.localScale = new Vector3(400, 400, 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        draggingObj.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (this.transform.parent == Dragcanvas.transform)
            draggingObj.transform.parent = oldParent;

        draggingObj.transform.localPosition = Vector3.zero;
        //draggingObj.transform.localScale = new Vector3(1, 1, 0);

        draggingObj = null;
    }
}
