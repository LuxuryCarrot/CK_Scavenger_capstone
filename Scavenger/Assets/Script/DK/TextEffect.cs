using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TextEffect : MonoBehaviour
{

    public Text ChatText;
    public Text CharacterName;

    public string writerText = "";

    bool isButtonClicked = false;

    public GameObject Next_Button;
    public GameObject PlumPhone;
    public GameObject Naruto;

    public GameObject FadeOutImage;

    public GameObject DialoguePoint;

    public GameObject Dialogue_Group;

    public Transform DialogueGroup_Pos;

    public GameObject Ringing;
    public GameObject Ringing_Accept;

    private bool isRingStart = false;

    private bool isPressed = false;

    private bool isButtonCheck = false;

    private void Awake()
    {
        Ringing.SetActive(true);
        Ringing_Accept.SetActive(false);
        SceneFadeOut(1f, Ringing_Accept, () => RingStart());
    }

    private void Update()
    {
        if (!isPressed)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ScriptStart();
                isPressed = true;
            }
        }
        if (isRingStart)
        {
            float step = 1000.0f * Time.deltaTime;
            Dialogue_Group.transform.position = Vector2.MoveTowards(Dialogue_Group.transform.position, new Vector2(DialogueGroup_Pos.position.x, DialogueGroup_Pos.position.y), step);
        }
    }

    public void RingStart()
    {
        isRingStart = true;
        ScriptStart();
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
        yield return StartCoroutine(NormalChat("양재성", "성북구 담당 스캐빈저 양재성입니다."));
        yield return StartCoroutine(NormalChat("의뢰자J", "아, 그 CK 화재 사람 맞죠? 그 물건 가져온다는 사람."));
        yield return StartCoroutine(NormalChat("양재성", "맞습니다."));
        yield return StartCoroutine(NormalChat("의뢰자J", "진짜 뭐든지 가져오나요? 불난 데도 들어가고?"));
        yield return StartCoroutine(NormalChat("양재성", "네.댁이 성북구 ㅁㅁ동의 2층 주택 맞는가요 ? "));
        yield return StartCoroutine(NormalChat("의뢰자J", "아, 네 맞고요. 정확히 어디냐면..."));
        yield return StartCoroutine(NormalChat("양재성", "정확한 위치는 CK 화재 측에서 제공받으니 괜찮습니다. 적혀있는 보험품은 통장과 인감으로 되어있는데 맞으신지요."));
        yield return StartCoroutine(NormalChat("의뢰자J", "아, 그게...등록은 그것만 한 게 맞는데요."));
        yield return StartCoroutine(NormalChat("양재성", "네.."));
        yield return StartCoroutine(NormalChat("의뢰자J", "저기…. 중요한게 들어있어서요."));
        yield return StartCoroutine(NormalChat("양재성", "보험에 해당하지 않는 물품에 대해서는 보증해 드릴 수 없습니다."));
        yield return StartCoroutine(NormalChat("의뢰자J", "네, 네. 들었습니다. 어쩔 수 없다면 괜찮지만, 그래도 어떻게 부탁드릴 수 없나요?"));
        yield return StartCoroutine(NormalChat("양재성", "...제가 받은 정보로는 119는 30분 전에 출발했군요."));
        yield return StartCoroutine(NormalChat("의뢰자J", "네.가족은 전부 안전하고"));
        yield return StartCoroutine(NormalChat("양재성", "네, 다행이네요. 자택 내 화재는 전소 상태인 게 맞나요?"));
        yield return StartCoroutine(NormalChat("의뢰자J", ".............네, 잔불만 끄고 있습니다."));
        yield return StartCoroutine(NormalChat("양재성", "알겠습니다.말씀하신 물건과 위치만 알려주시면 그 물건도 찾아오겠습니다."));
        yield return StartCoroutine(NormalChat("의뢰자J", "정말인가요!감사합니다.아, 그런데..."));
        yield return StartCoroutine(NormalChat("양재성", "더 있나요?"));
        yield return StartCoroutine(NormalChat("의뢰자J", "아뇨, 그게 2층 침실에 금고에다가 넣어뒀는데 열쇠를 어디 뒀는지 생각이 안 나네요."));
        yield return StartCoroutine(NormalChat("양재성", "금고째로 들고나와도 되나요 ? "));
        yield return StartCoroutine(NormalChat("의뢰자J", "가능한가요? 열쇠만 있으면 되는 거라 가져와만 주시면 복사해서 열면 되니까..."));
        yield return StartCoroutine(NormalChat("양재성", "금고 안의 물건만 가져오면 되는 거죠 ? "));
        yield return StartCoroutine(NormalChat("의뢰자J", "네, 부탁드립니다..."));
        yield return StartCoroutine(NormalChat("양재성", "알겠습니다. 지금 출발하겠습니다. 더 필요한 건 없으신가요?"));
        yield return StartCoroutine(NormalChat("의뢰자J", "네 ? 네, 네.위험하신데 감사"));
        yield return StartCoroutine(NormalChat("양재성", "추가하신 보험품은 가입하신 상품의 할인 혜택을 못 받으니 알아두세요."));
        yield return StartCoroutine(NormalChat("의뢰자J", "...네."));
        yield return StartCoroutine(NormalChat("양재성", "그럼 끊겠습니다.다음 연락까지 기다려주세요."));

        SceneFadeOut(1, FadeOutImage, () => SceneManager.LoadScene("MasterScene"));
    }

    public void SkipPressed()
    {
        SceneFadeOut(1, FadeOutImage, () => SceneManager.LoadScene("MasterScene"));
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
