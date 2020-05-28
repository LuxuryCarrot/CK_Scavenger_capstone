using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapGoTo : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = GetComponentInParent<Camera>();
        
    }
    private void Update()
    {
        Debug.Log(cam.pixelWidth);
    }

}
