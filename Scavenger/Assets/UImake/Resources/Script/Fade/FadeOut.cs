using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    private bool isTriggered = false;

    private void Awake()
    {
        if (!isTriggered)
        {
            SceneFadeOut(2f);
            Invoke("Destroyobject", 2f);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroyobject();
        }
    }


    // 중간 시연 이후 fade InOut관련 코드 정리해야함.
    public void SceneFadeOut(float fadeTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeOut(fadeTime, nextEvent));
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

    public void Destroyobject()
    {
        Destroy(gameObject);
    }



}
