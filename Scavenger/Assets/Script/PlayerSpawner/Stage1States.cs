using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1States : StageStatesParent
{


    public override void StateSpawn()
    {
        base.StateSpawn();
        gameObject.AddComponent<PlayerPush>();
        gameObject.GetComponent<PlayerCharacterController>().StateList.Add(States.PUSH, GetComponent<PlayerPush>());

    }
}
