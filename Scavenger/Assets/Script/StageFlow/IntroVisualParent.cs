using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroVisualParent : MonoBehaviour
{
    public Transform player;
    public StageManager manager;
    public bool isHappened;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GameObject.FindGameObjectWithTag("Stage").GetComponent<StageManager>();
        isHappened = false;
    }

    public virtual void Execute() { }
}
