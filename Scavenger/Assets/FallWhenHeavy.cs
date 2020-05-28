using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallWhenHeavy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            float randoms = Random.Range(0, InventoryManager.weight);
            if (randoms >= 20)
            {
                GetComponent<Animator>().SetTrigger("PlayerOn");
            }
        }
    }
}
