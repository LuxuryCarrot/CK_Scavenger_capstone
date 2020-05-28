using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParent : MonoBehaviour
{
    public static GameObject player;
    public string types;
    public float iteratTime;
    public float range;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    public virtual void iteract()
    {

    }

    public virtual void InvenRelease() { }

    public void ChangeShader(bool isApproach)
    {
        Debug.Log(Resources.Load("Shader/OutLine"));
        MeshRenderer mesh = GetComponentInChildren<MeshRenderer>();
        if(mesh!=null)
        {
            mesh.material = isApproach ?
                Resources.Load("Shader/OutLine") as Material: Resources.Load("Shader/BaseMat") as Material;
        }
    }
    
}
