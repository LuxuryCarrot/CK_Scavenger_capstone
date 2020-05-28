using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject PlumPhone;

    private void Start()
    {
        PlumPhone.SetActive(false);
    }

    public void PlumPhone_Pressed()
    {
        PlumPhone.SetActive(true);
    }


}
