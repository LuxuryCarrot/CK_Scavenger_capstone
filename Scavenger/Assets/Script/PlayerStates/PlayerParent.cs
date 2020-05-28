using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    public PlayerCharacterController manager;

    private void Awake()
    {
        manager = GetComponent<PlayerCharacterController>();
    }

    public virtual void BeginState()
    {

    }

    public virtual void EndState()
    {

    }
}
