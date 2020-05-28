using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMain : MonoBehaviour
{
    public void gotoMain_Pressed()
    {
        SceneManager.LoadScene("1_MainScene");
    }
}
