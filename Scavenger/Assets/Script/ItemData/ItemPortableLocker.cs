using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemPortableLocker : ItemLocker
{
    public string itemName;
    

    private void Awake()
    {
        if (slotPrefab == null)
            slotPrefab = Resources.Load("Prefabs/UI/ItemSlot") as GameObject;
        //prefab = Resources.Load(Application.dataPath + "/Script/ItemData/ItemInvenPrefab.prefab") as GameObject;
        prefab = Resources.Load("Prefabs/UI/FixedItemInvenPrefab") as GameObject;
        types = "열기";
        isiterat = false;
        lockerAnim = GetComponent<Animator>();
        if (lockerAnim != null)
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

    public override void iteract()
    {
        base.iteract();
     
        player.GetComponent<PlayerCharacterController>().SetState(States.COLLECT);
        if (lockerAnim != null)
            lockerAnim.enabled = true;
    }

    private void Update()
    {
        if (Vector3.SqrMagnitude(player.transform.position - transform.position) <= range * range)
        {
            if (player.GetComponent<PlayerCharacterController>().IteractItem == null)
            {
                player.GetComponent<PlayerCharacterController>().IteractItem = this.gameObject;
                player.GetComponent<PlayerCharacterController>().IteratScript = this;

                if(!FindKey() && !isOpened)
                {
                    types = " 가져가기";
                }
                else
                {
                    types = " 열기";
                }

                player.GetComponent<PlayerCharacterController>().TexTOut();
            }
        }
    }

    public void GetAsItem()
    {
        GameObject inst = Instantiate(prefab, transform.GetChild(0));
        inst.GetComponent<ItemInInven>().name = itemName;
        inst.GetComponent<ItemInInven>().SetSize();
        Sprite spr = Resources.Load<Sprite>("Sprite/ItemIcon/" + itemName) as Sprite;
        inst.GetComponent<Image>().sprite = spr;
        inst.transform.SetParent(null);

        for(int i=0; 
            i<player.GetComponent<PlayerCharacterController>().Inventory.transform.GetChild(0).GetChild(0).childCount; i++)
        {
            if( player.GetComponent<PlayerCharacterController>().Inventory.transform.GetChild(0).GetChild(0).GetChild(i)
                .GetComponent<FixedInvenSlotClass>().FindSlotEnable(inst.GetComponent<ItemInInven>()))
            {
                inst.transform.SetParent(player.GetComponent<PlayerCharacterController>().Inventory.transform.GetChild(0).GetChild(0).GetChild(i));
                player.GetComponent<PlayerCharacterController>().Inventory.transform.GetChild(0).GetChild(0).GetChild(i).GetComponent<FixedInvenSlotClass>().ItemGetIn(inst.GetComponent<FixedItemClass>());
                InventoryManager.inventory.WeightCheck();
                break;
            }
        }
        if (inst.transform.parent != null)
            Destroy(this.gameObject);
    }
}
