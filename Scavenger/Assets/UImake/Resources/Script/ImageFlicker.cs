using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFlicker : MonoBehaviour
{
    private bool isFlicking = true;

    private bool isActivate;

    private void Update()
    {
        if (isFlicking)
        {
            SceneFadeOut(1f, ()=>isFlicking = false);
        }
        else if (!isFlicking)
        {
            SceneFadeIn(1f, () => isFlicking = true);
        }
    }

    public void SceneFadeOut(float fadeTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeOut(fadeTime, nextEvent));
    }
    public void SceneFadeIn(float fadeTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeIn(fadeTime, nextEvent));
    }

    IEnumerator CoFadeOut(float fadeTime, System.Action nextEvent = null)
    {
        Image image = gameObject.GetComponent<Image>();
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

    

    IEnumerator CoFadeIn(float fadeTime, System.Action nextEvent = null)
    {
        Image image = gameObject.GetComponent<Image>();
        Color tempColor = image.color;

        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeTime;
            image.color = tempColor;
            if (tempColor.a <= 0f)
            {
                tempColor.a = 0f;
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
