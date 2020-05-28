using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScene : MonoBehaviour
{
    public Image CK_Logo;
    public Image Team_Logo;
    public Image Game_Logo;

    private void Awake()
    {

        FadeInAndOut(0.7f, CK_Logo,
            ()=>FadeInAndOut(0.7f, Team_Logo,
            ()=>SceneManager.LoadScene("1_MainScene")));

    }

    public void FadeInAndOut(float fadeTime, Image _Image, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeIO(fadeTime, _Image, nextEvent));
    }

    IEnumerator CoFadeIO(float fadeTime, Image _Image, System.Action nextEvent = null)
    {
        Color tempColor = _Image.color;

        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeTime;
            _Image.color = tempColor;

            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
            }

            yield return null;
        }
        _Image.color = tempColor;

        yield return new WaitForSecondsRealtime(fadeTime / fadeTime);

        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeTime;
            _Image.color = tempColor;

            if (tempColor.a <= 0f)
            {
                tempColor.a = 0f;

            }
            yield return null;

        }
        _Image.color = tempColor;

        nextEvent?.Invoke();
    }

    public void FadeIn(float fadeTime, Image _Image, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeIn(fadeTime, _Image, nextEvent));
    }

    public void FadeOut(float fadeTime, Image _Image, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeOut(fadeTime, _Image, nextEvent));
    }

    IEnumerator CoFadeIn(float fadeTime,Image _Image, System.Action nextEvent = null) // FadeIn (투명 -> 불투명)
    {
        Color tempColor = _Image.color;

        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeTime;
            _Image.color = tempColor;

            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
            }

            yield return null;
        }
        _Image.color = tempColor;
        if (nextEvent != null)
        {
            nextEvent();
        }
    }

    IEnumerator CoFadeOut(float FadeTime, Image _Image, System.Action nextEvent = null) // FadeOut (불투명 -> 투명)
    {
        Color tempColor = _Image.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / FadeTime;
            _Image.color = tempColor;

            if (tempColor.a <= 0f)
            {
                tempColor.a = 0f;
            }
            yield return null;

        }
        _Image.color = tempColor;

        if (nextEvent != null)
        {
            nextEvent();
        }
    }
}
