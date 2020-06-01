using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Button : MonoBehaviour
{
    public GameObject Menu_Panel;
    public GameObject Caution_Main_Panel;
    public GameObject Caution_QLog_Panel;
    public GameObject Caution_Setting_Panel;
    public GameObject FadeOutImage;

    private string curSceneName;

    private bool isPressed;

    private void Awake()
    {
        curSceneName = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        isPressed = false;
        Menu_Panel.SetActive(false);
        Caution_Main_Panel.SetActive(false);
        Caution_QLog_Panel.SetActive(false);
        Caution_Setting_Panel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Menu_Pressed();
    }

    public void Menu_Pressed()
    {
        if (!isPressed)
        {
            Menu_Panel.SetActive(true);
            isPressed = true;
        }
        else if(isPressed)
        {
            Menu_Panel.SetActive(false);
            isPressed = false;
        }
    }


    public void Goto_Main_Pressed()
    {
        if (curSceneName == "MasterScene")
        {
            if (isPressed)
            {
                Caution_Main_Panel.SetActive(true);
                isPressed = false;
            }
            else if (!isPressed)
            {
                Caution_Main_Panel.SetActive(false);
                isPressed = true;
            }
        }
        else
        {
            SceneFadeOut(1f, FadeOutImage, () => SceneManager.LoadScene("1_MainScene"));
        }
    }

    public void Goto_QLog_Pressed()
    {
        if (isPressed)
        {
            Caution_QLog_Panel.SetActive(true);
            isPressed = false;
        }
        else if (!isPressed)
        {
            Caution_QLog_Panel.SetActive(false);
            isPressed = true;
        }
    }

    public void Goto_Setting_Pressed()
    {
        if (isPressed)
        {
            Caution_Setting_Panel.SetActive(true);
            isPressed = false;
        }
        else if (!isPressed)
        {
            Caution_Setting_Panel.SetActive(false);
            isPressed = true;
        }
    }

    public void Goto_Main()
    {
        SceneFadeOut(1f, FadeOutImage, () => SceneManager.LoadScene("1_MainScene"));
    }

    public void Goto_QLog()
    {
        SceneFadeOut(1f, FadeOutImage, () => SceneManager.LoadScene("5_QLogScene"));
    }

    public void Goto_Setting()
    {
        SceneFadeOut(1f, FadeOutImage, () => SceneManager.LoadScene("6_SettingScene"));
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
