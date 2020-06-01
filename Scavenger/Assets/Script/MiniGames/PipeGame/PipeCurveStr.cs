using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PipeCurveStr : PipeGameNode, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        RotateNode();
        transform.Rotate(0, 0, 90);
        transform.parent.parent.GetComponent<PipeGameManager>().startnode.ElectircStream(transform.parent.parent.GetComponent<PipeGameManager>().startnode);
    }
    private void Start()
    {
        PathLink pathLink1 = new PathLink(upNode, leftNode);
        PathLink pathlink2 = new PathLink(upNode, downNode);
        pathFinds.Add(pathLink1);
        pathFinds.Add(pathlink2);
    }
}
