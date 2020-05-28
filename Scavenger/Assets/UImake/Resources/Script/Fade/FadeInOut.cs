using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public bool isFadeIn = false;
    public bool isFadeOut = false;

    private void Awake()
    {
        if (isFadeIn)
        {
            FadeIn(1.0f);
            isFadeIn = false;
        }
        else if (isFadeOut)
        {
            FadeOut(1.0f);
            isFadeOut = false;
        }
        //FadeOut(2f, ()=>SceneManager.LoadScene("")); // 2초간 FadeOut을 진행한 후 Scene을 호출하는 문장. 
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{

        //}
    }

    public void FadeIn(float fadeTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeIn(fadeTime, nextEvent));
    }

    public void FadeOut(float fadeTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeOut(fadeTime, nextEvent));
    }

    IEnumerator CoFadeIn(float fadeTime, System.Action  nextEvent = null) // FadeIn (투명 -> 불투명)
    {
        Image ParentSprite = gameObject.transform.parent.GetComponent<Image>(); // Sprite Renderer사용할거면 Image있는 부분에 모두 Sprite Renderer로 바꿔놓으면 됨.
        Color tempColor = ParentSprite.color;

        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeTime;
            ParentSprite.color = tempColor;

            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
            }

            yield return null;
        }

        ParentSprite.color = tempColor;
        if (nextEvent != null)
        {
            nextEvent();
        }
    }

    IEnumerator CoFadeOut(float FadeTime, System.Action nextEvent = null) // FadeOut (불투명 -> 투명)
    {
        Image ParentSprtie = gameObject.transform.parent.GetComponent<Image>();
        Color tempColor = ParentSprtie.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / FadeTime;
            ParentSprtie.color = tempColor;

            if (tempColor.a <= 0f)
            {
                tempColor.a = 0f;

            }
            yield return null;

        }

        if (nextEvent != null)
        {
            nextEvent();
        }
    }

}
