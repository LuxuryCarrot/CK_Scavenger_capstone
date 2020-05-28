using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimGet : MonoBehaviour
{
    public void GetUp()
    {
        GetComponentInParent<PlayerIdle>().stopMove = true;
    }

    public void EndSearch()
    {
        GetComponentInParent<PlayerIdle>().stopMove = false;
        
    }
    public void DoorEnd()
    {
        Debug.Log("End");
        transform.parent.position += new Vector3(3.0f, 0, 0);
    }
}
