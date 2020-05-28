using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButton : MonoBehaviour
{
    public GameObject AcceptButton;
    public GameObject ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Accept_Button()
    {
        ExitButton.SetActive(true);
    }

    public void Exit_Button()
    {
        ExitButton.SetActive(false);
    }
}
