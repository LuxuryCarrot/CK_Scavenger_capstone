using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestScenePhone : MonoBehaviour
{
    public GameObject PlumPhone;

    public GameObject PlumTalk_Panel;
    public GameObject RMHS_Panel;
    public GameObject E_Panel;
    public GameObject Quest_Panel;

    public GameObject PlumTalk_Button;
    public GameObject RMHS_Button;
    public GameObject E_Button;
    public GameObject Next_Button;

    public GameObject Quest1;

    public GameObject Naruto;

    // Start is called before the first frame update
    void Start()
    {
        PlumTalk_Panel.SetActive(false);
        RMHS_Panel.SetActive(false);
        E_Panel.SetActive(false);
        Next_Button.SetActive(false);

        Quest1.SetActive(false);

        PlumTalk_Button.SetActive(true);
        RMHS_Button.SetActive(true);
        E_Button.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenPlumTalk_Panel()
    {
        RMHS_Button.SetActive(false);
        E_Button.SetActive(false);
        PlumTalk_Panel.SetActive(true);
    }

    public void ClosePlumTalk_Panel()
    {
        RMHS_Button.SetActive(true);
        E_Button.SetActive(true);
        PlumTalk_Panel.SetActive(false);
    }

    public void OpenRMHS_Panel()
    {
        PlumTalk_Button.SetActive(false);
        E_Button.SetActive(false);
        RMHS_Panel.SetActive(true);
    }

    public void CloseRMHS_Panel()
    {
        PlumTalk_Button.SetActive(true);
        E_Button.SetActive(true);
        RMHS_Panel.SetActive(false);
    }

    public void OpenE_Panel()
    {
        PlumTalk_Button.SetActive(false);
        RMHS_Button.SetActive(false);
        E_Panel.SetActive(true);

    }

    public void CloseE_Panel()
    {
        PlumTalk_Button.SetActive(true);
        RMHS_Button.SetActive(true);
        E_Panel.SetActive(false);
    }

    public void OpenQuest_1()
    {
        Quest_Panel.SetActive(true);
        Quest1.SetActive(true);
    }


    public void CloseQuest_Panel()
    {
        Quest_Panel.SetActive(false);
    }

    public void OpenNaruto()
    {
        Naruto.SetActive(true);
    }
    
    public void CloseNaruto()
    {
        Naruto.SetActive(false);
        Next_Button.SetActive(true);
        Quest_Panel.SetActive(false);
        PlumPhone.SetActive(false);
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("MasterScene");
    }
}
