using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ddddd : MonoBehaviour
{
    public Text ChatText;
    public Text CharacterName;

    public GameObject FadeOutImage;
    public GameObject DialoguePoint;

    public GameObject Dialogue_Group;

    public GameObject ExitButton;

    public Transform DialogueGroup_Pos;

    public List<KeyCode> skipButton;

    public string writerText = "";

    bool isButtonClicked = false;

    // start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextSay());
    }

    private void Update()
    {
        float step = 1000.0f * Time.deltaTime;
        Dialogue_Group.transform.position = Vector2.MoveTowards(Dialogue_Group.transform.position, new Vector2(DialogueGroup_Pos.position.x, DialogueGroup_Pos.position.y), step);
    }

    public void ExitButton_Pressed()
    {
        SceneFadeOut(1f, FadeOutImage, () => SceneManager.LoadScene("2_QuestScene"));
    }

    public void ButtonClick()
    {
        DialoguePoint.SetActive(false);
        isButtonClicked = true;
    }

    public void ScriptStart()
    {
        StartCoroutine(TextSay());
    }

    IEnumerator NormalChat(string narrator, string narration)
    {
        int a = 0;

        CharacterName.text = narrator;

        writerText = "";

        for (a = 0; a < narration.Length; a++)
        {
            DialoguePoint.SetActive(false);
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }
        DialoguePoint.SetActive(true);

        while (true)
        {
            if (isButtonClicked)
            {
                isButtonClicked = false;

                break;
            }
            yield return null;
        }
    }

    IEnumerator TextSay()
    {
        yield return StartCoroutine(NormalChat("양재성", "부탁받은 금고 안의 물건, 그리고 기존 의뢰품인 통장과 인감을 회수했습니다."));
        yield return StartCoroutine(NormalChat("의뢰자J", "아…. 정말 감사합니다. 중간에 쾅 하고 뭐가 터지던데 괜찮으신 건가요?"));
        yield return StartCoroutine(NormalChat("양재성", "흔히 있는 일입니다."));
        yield return StartCoroutine(NormalChat("양재성", "의뢰자에게 물건을 돌려주었다."));
        ExitButton.SetActive(true);

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
