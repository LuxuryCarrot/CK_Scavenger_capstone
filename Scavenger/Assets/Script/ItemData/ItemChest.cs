using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : ItemParent
{
    public string[] items;
    public GameObject prefab;
    public GameObject chestSlot;
    public bool isiterat;
    public static GameObject slotPrefab;
    public int width;
    public int height;

    public Animator anim;

    private void Awake()
    {
        if (slotPrefab != null)
            slotPrefab = Resources.Load("Prefabs/UI/ItemSlot") as GameObject;
        isiterat = false;
        chestSlot = GameObject.FindGameObjectWithTag("ChestSlot").transform.GetChild(0).GetChild(0).gameObject;
        prefab = Resources.Load("Prefabs/UI/ItemInvenPrefab") as GameObject;
        anim = GetComponent<Animator>();
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
            }
        }
    }

    public void InvenChange()
    {
        if(anim!=null)
        anim.SetTrigger("Open");
        int current = 0;
        for (int i = 0; i < height; i++)
        {

            for (int j = 0; j < width; j++)
            {
                GameObject inst = Instantiate(slotPrefab, chestSlot.transform);
                FixedInvenSlotClass slot = inst.GetComponent<FixedInvenSlotClass>();

                if (current % width != 0)
                {
                    slot.backNode = transform.GetChild(transform.childCount - 2).GetComponent<FixedInvenSlotClass>();
                    slot.backNode.nextNode = slot;
                }
                if (current - width >= 0)
                {
                    slot.upNode = transform.GetChild(transform.childCount - 1 - width).GetComponent<FixedInvenSlotClass>();
                    slot.upNode.downNode = slot;
                }

                current++;
            }
        }

        for (int i = 0; transform.GetChild(0).childCount != 0; i++)
        {
            GameObject inst = transform.GetChild(0).GetChild(0).gameObject;
            inst.transform.SetParent(chestSlot.transform.GetChild(i));
            inst.transform.localPosition = new Vector3(0, 0, 0);
            inst.transform.localRotation = Quaternion.identity;

        }
    }

    public override void InvenRelease()
    {
        base.InvenRelease();

        if (anim != null)
            anim.SetTrigger("Close");

        for (int i = 0; i < chestSlot.transform.childCount; i++)
        {
            if (chestSlot.transform.GetChild(i).childCount != 0)
            {
                GameObject inst = chestSlot.transform.GetChild(i).GetChild(0).gameObject;
                inst.transform.SetParent(transform.GetChild(0));
            }
        }
    }

    public override void iteract()
    {
        base.iteract();
        isiterat = true;
        if(!chestSlot.activeInHierarchy)
        {
            player.GetComponent<PlayerCharacterController>().isIterating =true;
            InvenChange();
            Debug.Log("Open");
            player.GetComponent<PlayerCharacterController>().ChestSlot.SetActive(true);
        }
    }
}
