using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class QuestEndUI : MonoBehaviour
{
    public GameObject FadeOutImage;


    public void QuestEndButton()
    {
        SceneFadeOut(1, FadeOutImage, () => SceneManager.LoadScene("2_QuestScene"));
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
