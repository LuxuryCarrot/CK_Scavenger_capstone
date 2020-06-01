using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeGameManager : MonoBehaviour
{
    public PipeGameNode startnode;
    public PipeGameNode endnode;
    public int width;
    public int height;
    public Transform gameField;
    

    private void Awake()
    {
        int current = 0;
        for (int i = 0; i < height; i++)
        {

            for (int j = 0; j < width; j++)
            {
                PipeGameNode currentNode = gameField.GetChild(current).GetComponent<PipeGameNode>();
                if (current % width != 0)
                {
                    currentNode.leftNode = gameField.GetChild(current-1).GetComponent<PipeGameNode>();
                    currentNode.leftNode.rightNode = currentNode;
                }
                if (current - width >= 0)
                {
                    currentNode.upNode = gameField.GetChild(current - width).GetComponent<PipeGameNode>();
                    currentNode.upNode.downNode = currentNode;
                }

                current++;
            }
        }
        gameField.GetChild(0).GetComponent<PipeGameNode>().leftNode = startnode;
        startnode.rightNode = gameField.GetChild(0).GetComponent<PipeGameNode>();

        gameField.GetChild(gameField.childCount-1).GetComponent<PipeGameNode>().rightNode = endnode;
        endnode.leftNode = gameField.GetChild(gameField.childCount - 1).GetComponent<PipeGameNode>();
    }
}
