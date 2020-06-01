using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct PathLink
{
    public PipeGameNode path1;
    public PipeGameNode path2;
    public PathLink(PipeGameNode p1, PipeGameNode p2)
    {
        path1 = p1;
        path2 = p2;
    }
    public void SetPath(PipeGameNode p1, PipeGameNode p2)
    {
        path1 = p1;
        path2 = p2;
        Debug.Log(path1);
    }
}

public class PipeGameNode : MonoBehaviour
{
    public PipeGameNode upNode;
    public PipeGameNode downNode;
    public PipeGameNode leftNode;
    public PipeGameNode rightNode;

    public List<PathLink> pathFinds = new List<PathLink>();

    private void Start()
    {
        if(transform.rotation.eulerAngles.z !=0)
        {
            int i = (int)transform.rotation.eulerAngles.z / 90;
            for (int j = 0; j < i; j++)
                RotateNode();
        }
    }

    public virtual void ElectircStream(PipeGameNode inputNode)
    {


        //전 노드의 출력 위치를 받아, 전기를 흐르게 하는 로직
        foreach (PathLink paths in pathFinds)
        {
            if (inputNode == paths.path1)
            {
                //이 곳에 점등 효과 삽입
                Debug.Log("Sinc");
                GetComponent<Image>().color = Color.yellow;

                if (paths.path2 != null)
                    paths.path2.ElectircStream(this);
            }
            else if (inputNode == paths.path2)
            {
                //이 곳에 점등 효과 삽입
                Debug.Log("Sinc");
                GetComponent<Image>().color = Color.yellow;

                if (paths.path1 != null)
                    paths.path1.ElectircStream(this);
            }
        }
    }

    public void RotateNode()
    {
        for(int i=0; i<pathFinds.Count; i++)
        {
            
            PathLink paths = pathFinds[i];
            PipeGameNode newpath1;
            PipeGameNode newpath2;

            if (paths.path1 == upNode)
                newpath1 = leftNode;
            else if (paths.path1 == downNode)
                newpath1 = rightNode;
            else if (paths.path1 == leftNode)
                newpath1 = downNode;
            else
                newpath1 = upNode;

            if (paths.path2 == upNode)
                newpath2 = leftNode;
            else if (paths.path2 == downNode)
                newpath2 = rightNode;
            else if (paths.path2 == leftNode)
                newpath2 = downNode;
            else
                newpath2 = upNode;

            PathLink newpath = new PathLink(newpath1, newpath2);
            pathFinds[i] = newpath;
            Debug.Log(pathFinds[i].path1);
           
        }
    }
}
