using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainSceneUIController : MonoBehaviour
{

    public GameObject FadeOutObj;

    public void NewLoad_Button()
    {
        SceneFadeOut(1f, FadeOutObj, () => SceneManager.LoadScene("2_QuestScene"));
    }

    public void QLog_Button()
    {
        SceneFadeOut(1f, FadeOutObj, () => SceneManager.LoadScene("5_QLogScene"));
    }

    public void Setting_Button()
    {
        SceneFadeOut(1f, FadeOutObj, () => SceneManager.LoadScene("6_SettingScene"));
    }

    public void Exit_Button()
    {
        SceneFadeOut(1f, FadeOutObj, () => Application.Quit());
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
