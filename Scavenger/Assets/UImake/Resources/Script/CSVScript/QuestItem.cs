using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem
{
    private string Item_name;

    public QuestItem(string item_name)
    {
        this.Item_name = item_name;
    }

    public void Show()
    {
        Debug.Log(this.Item_name);
    }
   
}
