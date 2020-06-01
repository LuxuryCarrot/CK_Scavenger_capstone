using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PipeCurveCross : PipeGameNode, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        RotateNode();
        transform.Rotate(0, 0, 90);
        transform.parent.parent.GetComponent<PipeGameManager>().startnode.ElectircStream(this);
    }
    private void Start()
    {
        PathLink pathLink1 = new PathLink(upNode, rightNode);
        PathLink pathlink2 = new PathLink(leftNode, downNode);
        pathFinds.Add(pathLink1);
        pathFinds.Add(pathlink2);
    }
}
