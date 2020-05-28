using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    public GameObject[] stones;

    private void Awake()
    {
        

        for(int i=0; i<20; i++)
        {
            GameObject stone = Instantiate(stones[(int)Random.Range(0, stones.Length-1)], 
                 this.transform);

            stone.transform.position = new Vector3(transform.position.x + Random.Range(-8, 8),
                            transform.position.y,
                            transform.position.z + Random.Range(-3, 3));
            
        }
    }
}
