using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : PlayerParent
{
    public float getTime;
    

    public override void BeginState()
    {
        base.BeginState();
        getTime = 0;
        manager.anim.SetInteger("Run", 2);
        
        getTime += Time.deltaTime;
        //transform.GetChild(0).rotation = Quaternion.FromToRotation(new Vector3(transform.position.x, 0, transform.position.z), 
        //    new Vector3(manager.IteractItem.transform.position.x, 0 , manager.IteractItem.transform.position.z));
        manager.gageUI.enabled = true;
    }

    private void Update()
    {
        if (getTime != 0)
            getTime += Time.deltaTime;
        

        if (manager.ChestSlot.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.F))
                manager.ChestSlot.GetComponent<ChestSlotManager>().CloseButtonOn();
            return;
        }
            

        manager.gageUI.fillAmount = getTime / manager.IteractItem.GetComponent<ItemLocker>().iteratTime;

        if (!Input.GetKey(KeyCode.F) && getTime<=0.5f)
        {
            manager.anim.SetInteger("Run", 0);

            manager.gageUI.enabled = false;

            getTime = 0;
            manager.SetState(States.IDLE);
        }
        else if(!Input.GetKey(KeyCode.F))
        {
            manager.anim.SetInteger("Run", 0);

            manager.gageUI.enabled = false;

            getTime = 0;
            manager.SetState(States.DELAY);
        }

        if(getTime>=manager.IteractItem.GetComponent<ItemLocker>().iteratTime)
        {
            if (manager.IteractItem.GetComponent<ItemPortableLocker>() != null)
            {
                if(manager.IteractItem.GetComponent<ItemPortableLocker>().FindKey())
                {
                    manager.gageUI.enabled = false;
                    if (manager.IteractItem.GetComponent<Animator>() != null)
                        manager.IteractItem.GetComponent<Animator>().SetTrigger("Open");
                    manager.ChestSlot.SetActive(true);
                    manager.IteractItem.GetComponent<ItemLocker>().InvenChange();

                    manager.Inventory.SetActive(true);
                }
                else
                {
                    manager.IteractItem.GetComponent<ItemPortableLocker>().GetAsItem();
                    manager.gageUI.enabled = false;
                    manager.anim.SetInteger("Run", 0);
                    manager.SetState(States.DELAY);
                }
            }
            else
            {
                //getTime = 0;
                //manager.SetState(States.IDLE);
                //manager.IteractItem.GetComponent<ItemLocker>().isOpened = true;
                manager.gageUI.enabled = false;
                if (manager.IteractItem.GetComponent<Animator>() != null)
                    manager.IteractItem.GetComponent<Animator>().SetTrigger("Open");
                manager.ChestSlot.SetActive(true);
                manager.IteractItem.GetComponent<ItemLocker>().InvenChange();

                manager.Inventory.SetActive(true);
                manager.SetState(States.DELAY);
            }
        }
        
        
        
        
        
    }

    public override void EndState()
    {
        base.EndState();
        getTime = 0;
        if(manager.IteractItem!=null)
            if(manager.IteractItem.GetComponent<Animator>()!=null)
            manager.IteractItem.GetComponent<Animator>().SetTrigger("Close");
        manager.isIterating = false;
    }
}
