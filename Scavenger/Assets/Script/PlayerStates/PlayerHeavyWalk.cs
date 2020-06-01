using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeavyWalk : PlayerParent
{
    private float ySpeed;

    public override void BeginState()
    {
        base.BeginState();
        manager.anim.SetInteger("Run", 5); 
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            manager.SetState(States.IDLE);

        //if (manager.horizon)
        //    manager.moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0) / 8;
        //else
        //    manager.moveDirection = new Vector3(0, 0.0f, Input.GetAxis("Horizontal")) / 8;

        if (Input.GetAxis("Horizontal") >= 0)
            manager.moveDirection = manager.rightPos / 8;
        else if (Input.GetAxis("Horizontal") < 0)
            manager.moveDirection = manager.leftPos / 8;

        if (manager.moveDirection != Vector3.zero)
        {
            float angle;

            if (manager.horizon)
                angle = manager.moveDirection.x >= 0 ? 90 : -90;
            else
                angle = manager.moveDirection.z >= 0 ? 0 : 180;

            transform.GetChild(0).rotation = Quaternion.Euler(0, angle, 0);
        }
        manager.moveDirection = transform.TransformDirection(manager.moveDirection);
        manager.moveDirection = manager.moveDirection * manager.speed;

        if (manager.m_Controller.isGrounded)
        {
            ySpeed = 0;
        }

        ySpeed += manager.gravity * Time.deltaTime;
        manager.moveDirection.y -= ySpeed;
        manager.m_Controller.Move(manager.moveDirection * Time.deltaTime);



        manager.moveDirection = Vector3.zero;

    }
    public override void EndState()
    {
        base.EndState();
    }
}
