using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StageState
{
    IDLE=0,
    INTRO,
    EVENT
}
public class StageManager : MonoBehaviour
{
    public Camera cam;

    public static StageState current;
    public static bool playerCanmove;

    public List<EventVisualParent> eventInfo = new List<EventVisualParent>();
    public IntroVisualParent introInfo;
    public GameObject Fow;
    public Stack<EventVisualParent> callEnd = new Stack<EventVisualParent>();

    Dictionary<StageState, StageParent> StageFSM = new Dictionary<StageState, StageParent>();

    private void Awake()
    {
        cam = Camera.main;
        Fow = GameObject.FindGameObjectWithTag("Fow");
        StageFSM.Add(StageState.IDLE, GetComponent<StageIDLE>());
        StageFSM.Add(StageState.INTRO, GetComponent<StageIntro>());
        StageFSM.Add(StageState.EVENT, GetComponent<StageEvent>());
        playerCanmove = true;

        //eventInfo = null;
        introInfo = null;

        current = StageState.INTRO;
        SetState(current);
    }

    public void SetState(StageState state)
    {
        foreach(StageParent stage in StageFSM.Values)
        {
            stage.EndState();
            stage.enabled = false;
        }

        current = state;
        StageFSM[current].enabled = true;
        StageFSM[current].BeginState();
    }
}
