using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoCanvas : MonoBehaviour
{
    public static Image canvas;
    public static Text text;
    public static Text nameText;

    private void Awake()
    {
        canvas = this.GetComponent<Image>();
        text = this.transform.GetChild(0).GetComponent<Text>();
        nameText = this.transform.GetChild(1).GetComponent<Text>();
        canvas.gameObject.SetActive(false);
    }
}
