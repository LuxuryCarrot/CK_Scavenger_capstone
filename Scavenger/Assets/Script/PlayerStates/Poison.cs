using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public PlayerCharacterController player;

    private void Start()
    {
        player = GetComponent<PlayerCharacterController>();
    }
}
