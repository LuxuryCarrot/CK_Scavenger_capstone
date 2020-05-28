using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSVLoader : MonoBehaviour
{
    public static CSVLoader instance;

    public Text test;

    public string m_strCSVFileName = string.Empty;

    public Dictionary<int, Quest> m_Quest = new Dictionary<int, Quest>();

    public Dictionary<int, QuestItem> m_QuestItem = new Dictionary<int, QuestItem>();

    public Dictionary<int, QuestDialogue> m_QuestDialogue = new Dictionary<int, QuestDialogue>();

    //Dictionary<int, TestCSVscript> m_TestCSVscript = new Dictionary<int, TestCSVscript>();

    List<Dictionary<string, object>> m_dictionaryData;

    private void Awake()
    {
        instance = this;
        QuestLoad();
        //QuestDialogueLoad();
        //QuestItemLoad();
        //TestCSVLoad();
    }

    private void QuestLoad()
    {
        Debug.Log("Quest Loading...");
        int quest_index;
        string quest_code;
        string quest_name;
        string disaster_type;
        string quest_contents;

        int quest_item1;
        int quest_item2;
        int quest_item3;
        int quest_item4;
        int quest_item5;

        //int quest_dialogue_min;
        //int quest_dialogue_max;

        m_strCSVFileName = "QuestList";
        m_dictionaryData = CSVReader.Read(m_strCSVFileName);

        for (int i = 1; i < m_dictionaryData.Count; i++)
        {
            quest_index = int.Parse(m_dictionaryData[i]["quest_index"].ToString());
            quest_code = m_dictionaryData[i]["quest_code"].ToString();
            quest_name = m_dictionaryData[i]["quest_name"].ToString();
            disaster_type = m_dictionaryData[i]["disaster_type"].ToString();
            quest_contents = m_dictionaryData[i]["quest_contents"].ToString();

            quest_item1 = int.Parse(m_dictionaryData[i]["quest_item1"].ToString());
            quest_item2 = int.Parse(m_dictionaryData[i]["quest_item2"].ToString());
            quest_item3 = int.Parse(m_dictionaryData[i]["quest_item3"].ToString());
            quest_item4 = int.Parse(m_dictionaryData[i]["quest_item4"].ToString());
            quest_item5 = int.Parse(m_dictionaryData[i]["quest_item5"].ToString());

            //quest_dialogue_min = int.Parse(m_dictionaryData[i]["quest_dialogue_min"].ToString());
            //quest_dialogue_max = int.Parse(m_dictionaryData[i]["quest_dialogue_max"].ToString());

            m_Quest.Add(quest_index, new Quest(quest_code, quest_name, disaster_type, quest_contents,
            quest_item1, quest_item2, quest_item3, quest_item4, quest_item5/*, quest_dialogue_min, quest_dialogue_max*/));

        }
        Debug.Log((m_Quest.Count) + ("Quest Loaded"));

        //for (int i = 1; i < m_Quest.Count; i++)
        //{
        //    m_Quest[i].Show();
        //}
    }

    private void QuestItemLoad()
    {
        Debug.Log("QuestItem Loading...");
        int item_index;
        string item_name;

        m_strCSVFileName = "QuestItemList";
        m_dictionaryData = CSVReader.Read(m_strCSVFileName);

        for (int i = 0; i < m_dictionaryData.Count; i++)
        {
            item_index = int.Parse((m_dictionaryData[i]["item_index"].ToString()));
            item_name = m_dictionaryData[i]["item_name"].ToString();

            m_QuestItem.Add(item_index, new QuestItem(item_name));
        }
        Debug.Log((m_dictionaryData.Count - 1) + "item Loaded");

        ////for (int i = 0; i < m_QuestItem.Count; i++)
        ////{
            ////m_QuestItem[i].Show();
        ////}

    }

    private void QuestDialogueLoad()
    {
        Debug.Log("Quest Dialogue Loading...");

        int quest_dialogue_index;

        string quest_dialogue_name;
        string quest_dialogue_dialogue;

        m_strCSVFileName = "Quest_Dialogue";
        m_dictionaryData = CSVReader.Read(m_strCSVFileName);

        for (int i = 1; i < m_dictionaryData.Count; i++)
        {
            quest_dialogue_index = int.Parse(m_dictionaryData[i]["index"].ToString());

            quest_dialogue_name = m_dictionaryData[i]["name"].ToString();
            quest_dialogue_dialogue = m_dictionaryData[i]["dialogue"].ToString();

            m_QuestDialogue.Add(quest_dialogue_index, new QuestDialogue(quest_dialogue_name, quest_dialogue_dialogue));
        }
        Debug.Log((m_dictionaryData.Count - 1) + "Quest Dialogue Loaded");

        //for (int i = 1; i < m_QuestDialogue.Count; i++)
        //{
        //    m_QuestDialogue[i].Show();
        //}
    }

    //private void TestCSVLoad()
    //{
    //    int index;
    //    string testname;
    //    string teststring;

    //    m_strCSVFileName = "Quest_Dialogue";
    //    m_dictionaryData = CSVReader.Read(m_strCSVFileName);

    //    for (int i = 0; i < m_dictionaryData.Count; i++)
    //    {
    //        index = int.Parse((m_dictionaryData[i]["index"].ToString()));
    //        testname = m_dictionaryData[i]["name"].ToString();
    //        teststring = m_dictionaryData[i]["dialogue"].ToString();

    //        m_TestCSVscript.Add(index, new TestCSVscript(testname, teststring));
    //    }

    //    for (int i = 0; i < m_TestCSVscript.Count; i++)
    //    {
    //        m_TestCSVscript[i].Show();
    //    }
    //}
}      

