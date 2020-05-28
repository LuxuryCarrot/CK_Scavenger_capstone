using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageParent : MonoBehaviour
{
    public StageManager manager;

    private void Awake()
    {
        manager = GetComponent<StageManager>();
    }

    public virtual void BeginState() { }
    public virtual void EndState() { }
}
