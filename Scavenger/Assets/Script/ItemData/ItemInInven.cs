using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemInInven : MonoBehaviour
{
    public string name;
    public float weight;

    public int width;
    public int height;

   

    public void SetSize()
    {
        width = InfoInst.itemWidth[name];
        height = InfoInst.itemHeight[name];
        weight = InfoInst.itemWeight[name];
        GetComponent<RectTransform>().sizeDelta = new Vector2(79 * width, 79 * height);
    }
}
