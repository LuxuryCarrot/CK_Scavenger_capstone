using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneTool : MonoBehaviour
{
    private bool ispressed = true;

    public GameObject scenetool;

    private void Awake()
    {
        scenetool.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (ispressed)
            {
                scenetool.SetActive(true);
                ispressed = false;
            }
            else if (!ispressed)
            {
                scenetool.SetActive(false);
                ispressed = true;
            }
        }
    }

    public void GotoSplash()
    {
        SceneManager.LoadScene("0_StartSplashScene");
    }
    public void GotoMain()
    {
        SceneManager.LoadScene("1_MainScene");
    }
    public void GotoQuestScene()
    {
        SceneManager.LoadScene("2_QuestScene");
    }
    public void GotoQuestDialogue()
    {
        SceneManager.LoadScene("3_QuestDialogueScene");
    }
    public void GotoInGame()
    {
        SceneManager.LoadScene("MasterScene");
    }
    public void GotoQuestResult()
    {
        SceneManager.LoadScene("QuestResult");
    }
}
