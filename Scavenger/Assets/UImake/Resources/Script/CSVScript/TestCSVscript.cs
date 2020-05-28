using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCSVscript
{
    private int index;
    private string testName;
    private string testString;

    public TestCSVscript(string _testName, string _testString)
    {
        this.testName = _testName;
        this.testString = _testString;
    }
    
    public void Show()
    {
        Debug.Log(this.testName);
        Debug.Log(this.testString);
    }
}
