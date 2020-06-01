using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PipeStraight : PipeGameNode, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        RotateNode();
        transform.Rotate(0, 0, 90);
        Debug.Log(pathFinds[0].path1);
        transform.parent.parent.GetComponent<PipeGameManager>().startnode.ElectircStream(this);
    }
    private void Start()
    {
        PathLink inst = new PathLink(upNode, downNode);
        pathFinds.Add(inst);
    }
}
