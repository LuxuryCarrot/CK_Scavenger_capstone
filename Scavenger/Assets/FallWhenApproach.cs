using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallWhenApproach : MonoBehaviour
{
    public Transform player;
    public Animator anim;
    public bool isHappened;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isHappened = false;
    }

    private void Update()
    {
        if(isHappened==false &&
            Vector3.SqrMagnitude(player.transform.position-new Vector3(transform.position.x, player.transform.position.y, transform.position.z))<=9.0f)

        {
            anim.SetTrigger("Fall");
            isHappened = true;
        }
    }
}
