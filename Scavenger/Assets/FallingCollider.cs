using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCollider : MonoBehaviour
{
    public Transform player;
    bool isHappened;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isHappened = false;
    }

    private void Update()
    {
        
        if (!isHappened && Vector3.SqrMagnitude(player.transform.position-transform.position)<=4.0f
            && player.transform.position.y <= transform.position.y-0.5f)
        {
            Debug.Log("!!");
            player.GetComponent<PlayerCharacterController>().hp -= 50;
            isHappened = true;
        }
    }

}
