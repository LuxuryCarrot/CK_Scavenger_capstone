using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterScriptAdd : MonoBehaviour
{
    public GameObject PlumPhone;

    public bool Phone;
    // Start is called before the first frame update
    void Start()
    {
        PlumPhone = GameObject.FindGameObjectWithTag("PlumPhone");

        PlumPhone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!PlumPhone.activeInHierarchy)
                PlumPhone.SetActive(true);
            else
                PlumPhone.SetActive(false);
        }
    }
}
