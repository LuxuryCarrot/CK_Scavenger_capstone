using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St1R1Spawn : MonoBehaviour
{
    public GameObject floor;
    public GameObject wall;


    private void Awake()
    {
        for(int i=0; i<12; i++)
        {
            for(int j=0; j<3; j++)
            {
                GameObject newfloor =
                    Instantiate(floor, transform);
                newfloor.transform.localPosition = new Vector3(-1.8f * j, 0, i * 1.8f);
                newfloor.transform.localScale = new Vector3(2, 2, 2);
            }
        }
    }
}
