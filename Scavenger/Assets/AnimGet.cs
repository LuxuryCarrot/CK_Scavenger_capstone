using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimGet : MonoBehaviour
{
    public void DelayEnd()
    {
        if(GetComponent<Animator>().GetInteger("Run")!=2)
        GetComponentInParent<PlayerCharacterController>().SetState(States.IDLE);
    }
    public void DoorEnd()
    {
        Debug.Log("End");
        transform.parent.position += new Vector3(3.0f, 0, 0);
    }
}
