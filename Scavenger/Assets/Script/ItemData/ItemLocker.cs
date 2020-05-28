using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLocker : ItemParent
{

    public Animator lockerAnim;
    public bool isOpened;
    public GameObject blickText;
    public GameObject chestSlot;
    public string[] items;
    public GameObject prefab;
    public bool isiterat;
    public static GameObject slotPrefab;
    public GameObject deleteKey;

    public int width;
    public int height;

    public string key;

    private void Awake()
    {
        deleteKey = null;
        if (slotPrefab == null)
            slotPrefab = Resources.Load("Prefabs/UI/ItemSlot") as GameObject;
        //prefab = Resources.Load(Application.dataPath + "/Script/ItemData/ItemInvenPrefab.prefab") as GameObject;
        prefab = Resources.Load("Prefabs/UI/FixedItemInvenPrefab") as GameObject;
        types = "열기";
        isiterat = false;
        lockerAnim = GetComponent<Animator>();
        if(lockerAnim!=null)
           lockerAnim.enabled = false;
        iteratTime = 3.0f;
        isOpened = false;
        blickText = GameObject.FindGameObjectWithTag("BlickTextUI").gameObject;
        chestSlot = GameObject.FindGameObjectWithTag("ChestSlot").transform.GetChild(0).GetChild(0).gameObject;
        if (range == 0)
            range = 2;

    }
    private void Start()
    {
        if (items.Length != 0)
        {
            foreach (string name in items)
            {
                GameObject inst = Instantiate(prefab, transform.GetChild(0));
                inst.GetComponent<ItemInInven>().name = name;
                inst.GetComponent<ItemInInven>().SetSize();
                Sprite spr = Resources.Load<Sprite>("Sprite/ItemIcon/" + name) as Sprite;
                inst.GetComponent<Image>().sprite = spr;
                inst.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void Update()
    {
        if (Vector3.SqrMagnitude(player.transform.position - transform.position) <= range*range)
        {
            if (player.GetComponent<PlayerCharacterController>().IteractItem == null)
            {
                player.GetComponent<PlayerCharacterController>().IteractItem = this.gameObject;
                player.GetComponent<PlayerCharacterController>().IteratScript = this;
                ChangeShader(true);
                player.GetComponent<PlayerCharacterController>().TexTOut();
            }
        }
    }
    public override void iteract()
    {
        base.iteract();

        if (!isOpened&& key!="" && !FindKey())
            return;

        //if (!isOpened)
        //{
            player.GetComponent<PlayerCharacterController>().SetState(States.COLLECT);
            if (lockerAnim != null)
                lockerAnim.enabled = true;
            //lockerAnim.SetTrigger("Open");


            //isOpened = true;
        //}
        //else
        //{
        //    player.GetComponent<PlayerCharacterController>().isIterating = false;
        //    blickText.GetComponent<Animator>().SetTrigger("Blink");
        //}
    }

    public void InvenChange()
    {
        
        int current = 0;
        if (deleteKey != null)
        {
            deleteKey.transform.parent.GetComponent<FixedInvenSlotClass>().ItemGetOut();
            Destroy(deleteKey);
        }
        for (int i = 0; i < height; i++)
        {

            for (int j = 0; j < width; j++)
            {
                GameObject inst = Instantiate(slotPrefab, chestSlot.transform);
                FixedInvenSlotClass slot = inst.GetComponent<FixedInvenSlotClass>();

                if (current % width != 0)
                {
                    slot.backNode = chestSlot.transform.GetChild(chestSlot.transform.childCount - 2).GetComponent<FixedInvenSlotClass>();
                    slot.backNode.nextNode = slot;
                }
                if (current - width >= 0)
                {
                    slot.upNode = chestSlot.transform.GetChild(chestSlot.transform.childCount - 1 - width).GetComponent<FixedInvenSlotClass>();
                    slot.upNode.downNode = slot;
                }

                current++;
            }
        }

        isiterat = true;
        
        for (int i = 0; transform.GetChild(0).childCount != 0; i++)
        {
            GameObject inst = transform.GetChild(0).GetChild(0).gameObject;

            if (chestSlot.transform.GetChild(i).GetComponent<FixedInvenSlotClass>().FindSlotEnable(inst.GetComponent<ItemInInven>()))
            {
                inst.transform.SetParent(chestSlot.transform.GetChild(i));
                chestSlot.transform.GetChild(i).GetComponent<FixedInvenSlotClass>().ItemGetIn(inst.GetComponent<FixedItemClass>());
                //inst.transform.localPosition = new Vector3((inst.GetComponent<ItemInInven>().width-1)*25, -(inst.GetComponent<ItemInInven>().height - 1) * 25, 0);
                //inst.transform.localRotation = Quaternion.identity;
                //inst.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public override void InvenRelease()
    {
        for(int i=0; i< chestSlot.transform.childCount; i++)
        {
            if(chestSlot.transform.GetChild(i).childCount!=0)
            {
                GameObject inst = chestSlot.transform.GetChild(i).GetChild(0).gameObject;
                inst.transform.SetParent(transform.GetChild(0));
            }
        }

        int temp = chestSlot.transform.childCount;
        Debug.Log(temp);
        //for (; chestSlot.transform.childCount != 0;)
        //{
        //    if (temp == 0)
        //        break;
        //    Destroy(chestSlot.transform.GetChild(0).gameObject);
        //    temp--;

        //}
        chestSlot.transform.DetachChildren();
        isOpened = true;
    }

    public bool FindKey()
    {
        GameObject inv = player.GetComponent<PlayerCharacterController>().Inventory;

        for(int i=0; i< inv.transform.GetChild(0).GetChild(0).childCount; i++)
        {
            if (inv.transform.GetChild(0).GetChild(0).GetChild(i).childCount != 0)
                if (inv.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).GetComponent<ItemInInven>().name == key)
                {
                    deleteKey = inv.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).gameObject;
                    return true;
                }
        }

        blickText.GetComponent<Text>().text = "열쇠가 없다...";
        blickText.GetComponent<Animator>().SetTrigger("Blink");

        return false;
    }
}
