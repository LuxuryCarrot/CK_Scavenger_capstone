using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : PlayerParent
{

    private float delay;
    //private Vector3 pivot;

    public override void BeginState()
    {
        base.BeginState();
        manager.anim.SetInteger("Run", 0);
        manager.anim.SetInteger("Push", 1);
        
        //transform.GetChild(0).transform.rotation = Quaternion.Euler(0, manager.IteractItem.transform.rotation.z*180, 0);
        //pivot = manager.IteractItem.transform.position + 
        //    new Vector3(5* Mathf.Sin(manager.IteractItem.transform.rotation.z*3 * Mathf.Deg2Rad)
        //    ,0
        //    ,3* Mathf.Cos(manager.IteractItem.transform.rotation.z*3 * Mathf.Deg2Rad));
        
        //manager.transform.position = manager.IteractItem.transform.position
        //        -1.8f* new Vector3(Mathf.Cos(manager.IteractItem.transform.rotation.z * 3*Mathf.Deg2Rad), 0, Mathf.Sin(manager.IteractItem.transform.rotation.z * Mathf.Deg2Rad*3));
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && manager.sta > 0)
        {

            manager.sta -= 5 * Time.deltaTime;
            
                transform.position -= new Vector3(0.8f, 0, 0) * Time.deltaTime;
            

            

            //manager.IteractItem.transform.Rotate(0, 0, -18 * Time.deltaTime);
            //transform.GetChild(0).transform.Rotate(0, -18 * Time.deltaTime, 0);


            //manager.IteractItem.transform.position =
            //    AngleMove(pivot, manager.IteractItem.transform.position, 18 * Time.deltaTime);



            //manager.transform.position = manager.IteractItem.transform.position
            //    - 1.6f * new Vector3(Mathf.Sin(manager.IteractItem.transform.rotation.z * 180 * Mathf.Deg2Rad), 0, Mathf.Cos(manager.IteractItem.transform.rotation.z * Mathf.Deg2Rad * 180));

            //if (manager.IteractItem.transform.rotation.z * 180 <= 0)
            //    manager.SetState(States.IDLE);

            manager.IteractItem.transform.position += new Vector3(Time.deltaTime, 0,0);
            manager.transform.position += new Vector3(Time.deltaTime, 0,0);
            manager.IteractItem.GetComponent<ItemMovement>().distance -= Time.deltaTime;
            if(manager.IteractItem.GetComponent<ItemMovement>().distance<=0)
            {
                manager.IteractItem.GetComponent<ItemMovement>().isIterat = false;
                manager.anim.SetInteger("Push", 0);
                manager.SetState(States.DELAY);
            }
        }
        else
        {
            manager.anim.SetInteger("Push", 0);
            manager.SetState(States.DELAY);
        }
    }
    public override void EndState()
    {
        base.EndState();
    }

    public Vector3 AngleMove(Vector3 p, Vector3 vec, float angle)
    {
        Vector3 scaleVec = manager.IteractItem.transform.position - p;
        return (new Vector3(scaleVec.x * Mathf.Cos(angle*Mathf.Deg2Rad) - Mathf.Sin(angle * Mathf.Deg2Rad) * scaleVec.z, 0,
                           scaleVec.x * Mathf.Sin(angle * Mathf.Deg2Rad) + Mathf.Cos(angle * Mathf.Deg2Rad) * scaleVec.z) + p);
    }
}
