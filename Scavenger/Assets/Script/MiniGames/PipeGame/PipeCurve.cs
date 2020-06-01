using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PipeCurve : PipeGameNode, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        RotateNode();
        transform.Rotate(0, 0, 90);
        Debug.Log("!!!");
        transform.parent.parent.GetComponent<PipeGameManager>().startnode.ElectircStream(this);
    }

    private void Start()
    {
        PathLink pathLink = new PathLink(upNode, rightNode);
        pathFinds.Add(pathLink);
    }
}
