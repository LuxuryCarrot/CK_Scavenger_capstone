using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlumPhoneScript : MonoBehaviour
{
    public GameObject PlumPhone;
    public GameObject PlumPhone_Exit_Button;

    public GameObject PlumTalk_Button;
    public GameObject PlumTalk_Panel;

    public Text PlumTalk_Text;

    public GameObject RMHS_Button;
    public GameObject RMHS_Panel;

    public GameObject Ekipedia_Button;
    public GameObject Ekipedia_Panel;

    public GameObject Quest_Panel;

    public GameObject QuestDialogue_Panel;

    public Text Quest_Main_Title_Text;
    public Text Quest_Num_Title_Text;
    public Text Quest_Contents_Text;
    public Text Quest_Disaster_Type_Text;

    public Image Quest_Disaster_Type_Image;

    public GameObject Quest_Accept_Button;

    public GameObject Quest_Button;

    public RectTransform QuestConten;

    private string curSceneName;

    private bool isPressed;

    //private Text Dialogue_Name;
    //private Text Dialogue_Contents;

    //private Button Dialogue_Button;

    public GameObject FadeOutImage;

    private void Awake()
    {
        curSceneName = SceneManager.GetActiveScene().name;

        Quest_Set();

        isPressed = false;

        PlumTalk_Button.SetActive(true);
        PlumTalk_Panel.SetActive(false);

        if (curSceneName == "MasterScene")
        {
            RMHS_Button.SetActive(false);
            Quest_Accept_Button.SetActive(false);
            PlumPhone_Exit_Button.SetActive(true);
        }
        else
        {
            RMHS_Button.SetActive(true);
            Quest_Accept_Button.SetActive(true);
            PlumPhone_Exit_Button.SetActive(false);
        }
        RMHS_Panel.SetActive(false);

        Ekipedia_Button.SetActive(true);
        Ekipedia_Panel.SetActive(false);

        Quest_Panel.SetActive(false);

        Debug.Log(CSVLoader.instance.m_Quest.Count);

        PlumTalk_Text.text = "안녕하세요, 양재성님!\n" + (CSVLoader.instance.m_Quest.Count) + "건의 의뢰 알림이 있습니다.";

        //Dialogue_Name = QuestDialogue_Panel.transform.GetChild(1).GetComponent<Text>();
        //Dialogue_Contents = QuestDialogue_Panel.transform.GetChild(2).GetChild(0).GetComponent<Text>();
        //Dialogue_Button = QuestDialogue_Panel.transform.GetChild(2).GetComponent<Button>();
    }

    public void Quest_Pressed(int i)
    {
        if (isPressed)
        {
            Quest_Main_Title_Text.text = CSVLoader.instance.m_Quest[i].Quest_name;
            Quest_Num_Title_Text.text = "사건번호 " + CSVLoader.instance.m_Quest[i].Quest_code;
            Quest_Disaster_Type_Text.text = "재난유형: " + CSVLoader.instance.m_Quest[i].Disaster_type;
            Quest_Contents_Text.text = CSVLoader.instance.m_Quest[i].Quest_Contents;
            Quest_Panel.SetActive(true);
            //if (curSceneName == "1_QuestScene")
            //{
            //Dialogue_Num = 0;

            //}
            isPressed = false;
        }
        else if (!isPressed)
        {
            Quest_Panel.SetActive(false);
            isPressed = true;
        }

    }

    public void Quest_Set()
    {
        
        int a = 0;
        for (int i = 1; i <= CSVLoader.instance.m_Quest.Count; i++)
        {
            GameObject button = (GameObject)Instantiate(Quest_Button, QuestConten);
            button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y + a, button.transform.position.z);
            a -= 85;
            button.transform.SetParent(QuestConten);
            button.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = button.GetComponent<Button>();

            Text _text1 = button.transform.GetChild(0).GetComponent<Text>();
            _text1.text = CSVLoader.instance.m_Quest[i].Quest_code;
            Text _text2 = button.transform.GetChild(1).GetComponent<Text>();
            _text2.text = CSVLoader.instance.m_Quest[i].Quest_name;
            int temp = i;
            tempButton.onClick.AddListener(() => { Quest_Pressed(temp); });

        }
        Debug.Log("Quest_Setting End");
    }
    //public void QuestDialogue_PanelShow(int a)
    //{
        //a++;
    //}

    public void Accept_Pressed()
    {
        SceneFadeOut(2f, FadeOutImage, () => SceneManager.LoadScene("3_QuestDialogueScene"));
    }

    public void PlumTalk_Pressed()
    {
        if (!isPressed)
        {
            PlumTalk_Panel.SetActive(true);
            isPressed = true;
        }
        else if (isPressed)
        {
            PlumTalk_Panel.SetActive(false);
            isPressed = false;
        }
    }

    public void RMHS_Pressed()
    {
        if (!isPressed)
        {
            RMHS_Panel.SetActive(true);
            isPressed = true;
        }
        else if (isPressed)
        {
            RMHS_Panel.SetActive(false);
            isPressed = false;
        }
    }

    public void Ekipedia_Pressed()
    {
        if (!isPressed)
        {
            Ekipedia_Panel.SetActive(true);
            isPressed = true;
        }
        else if (isPressed)
        {
            Ekipedia_Panel.SetActive(false);
            isPressed = false;
        }
    }

    public void PlumPhone_Pressed()
    {
        PlumPhone.SetActive(false);
    }

    public void SceneFadeOut(float fadeTime, GameObject Fdoutimage, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeOut(fadeTime, Fdoutimage, nextEvent));
    }

    IEnumerator CoFadeOut(float fadeTime, GameObject Fdoutimage, System.Action nextEvent = null)
    {
        Fdoutimage.SetActive(true);
        Image image = Fdoutimage.GetComponent<Image>();
        Color tempColor = image.color;

        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeTime;
            image.color = tempColor;
            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
            }
            yield return null;
        }
        image.color = tempColor;
        if (nextEvent != null)
        {
            nextEvent();
        }
    }
}
