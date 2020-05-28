using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : PlayerParent
{
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.SetInteger("Run", 0);
        
        Debug.Log("!");
    }
    private void Update()
    {
        manager.anim.SetInteger("Run", 6);
    }
}
