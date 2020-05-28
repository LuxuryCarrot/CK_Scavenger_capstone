using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDam : MonoBehaviour
{
    public PlayerCharacterController player;
    public float range;
    public float damage;
    public EletricShock elec;

    private void Awake()
    {
        elec = GetComponent<EletricShock>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacterController>();
    }

    private void Update()
    {
        if(Vector3.SqrMagnitude(player.transform.position-transform.position)<=range*range)
        {
            if (elec != null)
                elec.Execute();
            else
                player.hp -= damage * Time.deltaTime;
        }
    }
}
