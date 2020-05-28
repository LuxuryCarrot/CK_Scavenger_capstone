using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogue
{
    public string name;
    public string dialogue;

    public QuestDialogue(string _name, string _dialogue)
    {
        name = _name;
        dialogue = _dialogue;
    }

    public void Show()
    {
        Debug.Log(name);
        Debug.Log(dialogue);
    }
}
