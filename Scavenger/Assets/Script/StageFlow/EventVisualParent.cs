using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventVisualParent : MonoBehaviour
{
    public Transform player;
    public StageManager manager;
    public bool isHappened;

    


    public virtual void Execute() { }
}
