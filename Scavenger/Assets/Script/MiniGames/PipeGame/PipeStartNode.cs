using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeStartNode : PipeGameNode
{
    public override void ElectircStream(PipeGameNode inputNode)
    {
        base.ElectircStream(inputNode);
        rightNode.ElectircStream(this);
    }
}
