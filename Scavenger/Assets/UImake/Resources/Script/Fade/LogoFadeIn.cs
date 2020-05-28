using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoFadeIn : MonoBehaviour
{
    private bool isTriggered = false;

    private void Awake()
    {
        Invoke("TriggerScene", 2.0f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isTriggered)
            {
                TriggerScene();
                isTriggered = true;
            }
        }   
    }

    public void TriggerScene()
    {
        SceneFadeIn(3.5f);
    }

    public void SceneFadeIn(float fadeTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeIn(fadeTime, nextEvent));
    }

    IEnumerator CoFadeIn(float fadeTime, System.Action nextEvent = null)
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
}
