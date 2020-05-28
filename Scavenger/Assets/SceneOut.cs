using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOut : MonoBehaviour
{
    public void SceneOutOn()
    {
        SceneManager.LoadScene(3);
    }
}
