using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{

    public Animator anim;
    public Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = transform.position + new Vector3(5, 1.1f, 0.5f);

        if(Input.GetKey(KeyCode.RightArrow))
        {
            if (anim.GetInteger("Run") == 0)
                anim.SetInteger("Run", 1);
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            if (anim.GetInteger("Run") == 0)
                anim.SetInteger("Run", 1);
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            anim.SetInteger("Run", 0);
        }
            
    }
}
