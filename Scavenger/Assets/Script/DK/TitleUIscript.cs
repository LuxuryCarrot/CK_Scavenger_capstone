using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIscript : MonoBehaviour
{
    public Image title;

    public GameObject title_;

    public float FadeTime = 2f;

    float start;

    float end;

    //float time = 0f;

    //bool isPlaying = false;

    // Start is called before the first frame update
    private void Awake()
    {
        StartFadeAnim();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewStory()
    {
        SceneManager.LoadScene("QuestScene");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    private void StartFadeAnim()
    {
        StartCoroutine("fadeIntanim");
    }

    IEnumerator fadeoutplay()
    {
        Color fadecolor = title.color;

        //time = 0f;


        while (true)
        {

        }

   
    }
}
