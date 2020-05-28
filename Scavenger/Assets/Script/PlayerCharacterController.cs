using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum States
{
    IDLE=0,
    PUSH,
    CLIME,
    COLLECT,
    INTRO,
    DIE,
    DOOR
}
[RequireComponent(typeof(CharacterController))]
public class PlayerCharacterController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jummpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Text iterattext;
    public bool horizon;
    
    //[System.NonSerialized]
    public float hp;
    [System.NonSerialized]
    public float lo;
    [System.NonSerialized]
    public float str;
    //[System.NonSerialized]
    public float sta;
    [System.NonSerialized]
    public float stv;
    

    public GameObject IteractItem;
    public ItemParent IteratScript;

    public GameObject gage;

    public Vector3 moveDirection = Vector3.zero;

    Dictionary<States, PlayerParent> StateList = new Dictionary<States, PlayerParent>();

    public CharacterController m_Controller;
    public Animator anim;

    public States current;
    public bool isIterating=false;

    public Vector3 iteratStartPos=Vector3.zero;
    public Vector3 iteratEndPos=Vector3.zero;

    public GameObject Inventory;
    public GameObject ChestSlot;

    public Image gageUI;

    public GameObject blinkText;

    private void Awake()
    {
        horizon = true;
        StateList.Add(States.IDLE, GetComponent<PlayerIdle>());
        StateList.Add(States.PUSH, GetComponent<PlayerPush>());
        StateList.Add(States.CLIME, GetComponent<PlayerClime>());
        StateList.Add(States.COLLECT, GetComponent<PlayerCollect>());
        StateList.Add(States.INTRO, GetComponent<PlayerIntro>());
        StateList.Add(States.DIE, GetComponent<PlayerDie>());
        StateList.Add(States.DOOR, GetComponent<PlayerDoor>());

        anim = GetComponentInChildren<Animator>();

        ItemParent.player = this.gameObject;

        current = States.IDLE;
        IteractItem = null;
        SetState(current);

        Inventory = GameObject.FindGameObjectWithTag("Inventory");
        ChestSlot = GameObject.FindGameObjectWithTag("ChestSlot");
        iterattext = GameObject.FindGameObjectWithTag("IteratText").GetComponent<Text>();
        Inventory.SetActive(false);
        ChestSlot.SetActive(false);
        iterattext.transform.parent.gameObject.SetActive(false);
        gageUI.enabled = false;

        hp = PlayerDefaultInfo.hpMax;
        lo = PlayerDefaultInfo.lo;
        str = PlayerDefaultInfo.str;
        sta = PlayerDefaultInfo.sta;
        stv = PlayerDefaultInfo.stv;

        blinkText = GameObject.FindGameObjectWithTag("BlickTextUI").transform.GetChild(0).gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Controller = GetComponent<CharacterController>();

    }

    public void SetState(States states)
    {
        foreach(PlayerParent state in StateList.Values)
        {
            if (state.enabled)
                state.EndState();
            state.enabled = false;
            
        }

        current = states;
        StateList[current].enabled = true;
        StateList[current].BeginState();
    }

    // Update is called once per frame
    void Update()
    {
        if (horizon)
        {
            gage.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
            gage.transform.rotation = Quaternion.Euler(0, -90, 0);
        if(hp<=0)
        {
            if (current != States.DIE)
                SetState(States.DIE);
            return;
        }

        if(IteractItem!=null && Vector3.SqrMagnitude(IteractItem.transform.position-transform.position)>IteratScript.range* IteratScript.range)
        {
            IteratScript.ChangeShader(false);
            IteractItem = null;
            IteratScript = null;
            iterattext.transform.parent.gameObject.SetActive(false);
            isIterating = false;
        }

        if (!isIterating && IteractItem != null && Input.GetKeyDown(KeyCode.F) && !Inventory.activeInHierarchy)
        {
            Debug.Log("GET!!");
            isIterating = true;
            IteractItem.GetComponent<ItemParent>().iteract();
            
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (!Inventory.activeInHierarchy)
                Inventory.SetActive(true);
            else
            {
                Inventory.SetActive(false);
                if (ChestSlot.activeInHierarchy)
                    ChestSlot.GetComponent<ChestSlotManager>().CloseButtonOn();

                if (ItemInfoCanvas.canvas.gameObject.activeInHierarchy)
                    ItemInfoCanvas.canvas.gameObject.SetActive(false);
            }
        }

        if (anim.GetInteger("Run") < 2 && sta < 100)
            sta += Time.deltaTime*3;
    }

    public void TexTOut()
    {
        iterattext.transform.parent.gameObject.SetActive(true);
        iterattext.text = "F를 길게 눌러 " + IteratScript.types;
    }
}
