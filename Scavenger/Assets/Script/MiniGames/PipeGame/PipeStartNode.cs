using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeStartNode : PipeGameNode
{
    public override void ElectircStream(PipeGameNode inputNode)
    {
        base.ElectircStream(inputNode);
        Debug.Log("Elec");

        Transform field = transform.parent.GetComponent<PipeGameManager>().gameField;
        
        for(int i=0; i<field.childCount; i++)
        {
            field.GetChild(i).GetComponent<Image>().color = Color.white;
        }

        rightNode.ElectircStream(this);
    }
}
