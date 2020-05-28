using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : ItemParent
{
    private float speed=1.0f;
    private float ySpeed;
    private float yPos;

    private void Start()
    {
        ySpeed = 0;
        yPos = transform.position.y;
    }
    public override void iteract()
    {
        base.iteract();
        player.GetComponent<PlayerCharacterController>().isIterating = false;
    }
    private void Update()
    {
        if (Vector3.SqrMagnitude(player.transform.position - transform.position) <= 4.0f)
        {
            if (player.GetComponent<PlayerCharacterController>().IteractItem == null)
                player.GetComponent<PlayerCharacterController>().IteractItem = this.gameObject;
        }
        if (Vector3.SqrMagnitude(player.transform.position - transform.position) <= 2.0f)
        {
            
            Vector3 forceWay = transform.position - player.transform.position;
            forceWay = new Vector3(forceWay.x, 0.5f, forceWay.z);
            GetComponent<Rigidbody>().AddForce(10*(forceWay));
            
        }
        if(GetComponent<Rigidbody>().velocity!=Vector3.zero)
        {
            GetComponent<Rigidbody>().velocity 
                = Vector3.Normalize(GetComponent<Rigidbody>().velocity) 
                * (Vector3.Magnitude(GetComponent<Rigidbody>().velocity) - speed * Time.deltaTime);
            if (Vector3.SqrMagnitude(GetComponent<Rigidbody>().velocity) <= 0.01f)
                GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (transform.position.y > yPos)
        {
            ySpeed += 2 * Time.deltaTime;
            transform.position -= new Vector3(0, ySpeed * Time.deltaTime, 0);
            if (transform.position.y - yPos <= 0.1f)
            {
                transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
                transform.rotation=Quaternion.identity;
            }
        }
    }
    
}
