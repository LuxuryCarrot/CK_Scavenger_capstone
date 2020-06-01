using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCurve : PipeGameNode
{
    private void Awake()
    {
        PathLink pathLink = new PathLink(upNode, rightNode);
        pathFinds.Add(pathLink);
    }
}
