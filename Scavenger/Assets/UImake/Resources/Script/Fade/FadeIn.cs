using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    private bool isTriggered = false;

    private bool isPressed = false;

    private void Awake()
    {
        if (!isTriggered)
        {
            SceneFadeIn(2f);
            Invoke("Destroyobject", 2f);
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
            //Destroyobject();
        //}
    }

    public void SceneFadeIn(float fadeTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeIn(fadeTime, nextEvent));
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

    public void Destroyobject()
    {
        Destroy(gameObject);
    }
}
