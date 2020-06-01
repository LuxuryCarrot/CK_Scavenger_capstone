using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCurveCross : PipeGameNode
{
    private void Awake()
    {
        PathLink pathLink1 = new PathLink(upNode, rightNode);
        PathLink pathlink2 = new PathLink(leftNode, downNode);
        pathFinds.Add(pathLink1);
        pathFinds.Add(pathlink2);
    }
}
