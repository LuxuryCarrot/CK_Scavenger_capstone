using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIdle : PlayerParent
{
    private float ySpeed;
    public bool stopMove;

    public override void BeginState()
    {
        base.BeginState();
        //manager.anim.SetInteger("Run", 0);
        
    }

    private void Update()
    {
        
        //if(Input.GetKey(KeyCode.RightArrow))
        //   transform.GetChild(0).rotation = Quaternion.LookRotation(new Vector3(1, 0, 0), new Vector3(0, 1, 0));

        //if(Input.GetKey(KeyCode.LeftArrow))
        //   transform.GetChild(0).rotation = Quaternion.LookRotation(new Vector3(-1, 0, 0), new Vector3(0, 1, 0));

        if (!manager.Inventory.activeInHierarchy && !manager.ChestSlot.activeInHierarchy)
        {
            if(manager.horizon)
              manager.moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f,0)/4;
            else
                manager.moveDirection = new Vector3(0, 0.0f, Input.GetAxis("Horizontal")) / 4;

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


            if (manager.moveDirection != Vector3.zero)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (manager.sta > 0 && InventoryManager.weight <= InventoryManager.weightLimit * 0.8f)
                    {
                        if (manager.sta > 5)
                        {
                            manager.anim.SetInteger("Run", 3);
                            manager.sta -= Time.deltaTime * 15;

                            manager.moveDirection = manager.moveDirection * 3;
                        }
                        else
                            manager.anim.SetInteger("Run", 1);

                        
                    }
                    else if (manager.sta <= 0)
                    {
                        manager.blinkText.GetComponent<Text>().text = "숨이 차서 못 뛰겠어";
                        manager.blinkText.GetComponent<Animator>().SetTrigger("Blink");
                    }
                }
                else if (InventoryManager.weight > InventoryManager.weightLimit * 0.8f)
                {
                    manager.anim.SetInteger("Run", 5);
                    manager.moveDirection = manager.moveDirection * 0.5f;
                }
                else
                    manager.anim.SetInteger("Run", 1);
            }
            else
                manager.anim.SetInteger("Run", 0);


            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
                manager.moveDirection = Vector3.zero;

            
        }
        else
            manager.anim.SetInteger("Run", 0);



        if (manager.m_Controller.isGrounded)
        {
            ySpeed = 0;
        }

        ySpeed += manager.gravity*Time.deltaTime;
        manager.moveDirection.y -= ySpeed;
        manager.m_Controller.Move(manager.moveDirection*Time.deltaTime);

        

        manager.moveDirection = Vector3.zero;
        
    }

    public override void EndState()
    {
        base.EndState();
    }
}
