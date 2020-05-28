using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public string Quest_code;
    public string Quest_name;
    public string Disaster_type;
    public string Quest_Contents;

    public int Quest_item1;
    public int Quest_item2;
    public int Quest_item3;
    public int Quest_item4;
    public int Quest_item5;

    //public int Quest_Dialogue_Min;
    //public int Quest_Dialogue_Max;

    public Quest(string quest_code, string quest_name,
                 string disaster_type, string quest_contents, int quest_item1, 
                 int quest_item2, int quest_item3, int quest_item4, int quest_item5/*, int _quest_dialogue_min, int _quest_dialogue_max*/)
    {
        this.Quest_code = quest_code;
        this.Quest_name = quest_name;
        this.Disaster_type = disaster_type;
        this.Quest_Contents = quest_contents;
        
        this.Quest_item1 = quest_item1;
        this.Quest_item2 = quest_item2;
        this.Quest_item3 = quest_item3;
        this.Quest_item4 = quest_item4;
        this.Quest_item5 = quest_item5;
        
        //this.Quest_Dialogue_Min = _quest_dialogue_min;
        //this.Quest_Dialogue_Max = _quest_dialogue_max;
    }

    public void Show()
    {
        Debug.Log(this.Quest_code);
        Debug.Log(this.Quest_name);
        Debug.Log(this.Disaster_type);
        Debug.Log(this.Quest_Contents);
                  
        Debug.Log(this.Quest_item1);
        Debug.Log(this.Quest_item2);
        Debug.Log(this.Quest_item3);
        Debug.Log(this.Quest_item4);
        Debug.Log(this.Quest_item5);

        //Debug.Log(this.Quest_Dialogue_Min);
        //Debug.Log(this.Quest_Dialogue_Max);
    }
}
