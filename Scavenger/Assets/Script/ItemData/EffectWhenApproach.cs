using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectWhenApproach : MonoBehaviour
{
    public Transform player;
    public float range;
    bool isHappenend;

    public float duration;
    public GameObject[] durationEvent;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isHappenend = false;
        for(int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < durationEvent.Length; i++)
        {
            durationEvent[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(!isHappenend)
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        if (Vector3.SqrMagnitude(transform.position-player.position)<=range*range)
        {
            isHappenend = true;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        if(isHappenend && duration>=0)
          duration -= Time.deltaTime;

        if (duration<=0 && duration >=-1)
        {
            duration -= 2;
            for(int i=0; i<durationEvent.Length; i++)
            {
                durationEvent[i].SetActive(true);
            }
        }
    }
}
