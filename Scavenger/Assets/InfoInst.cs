using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoInst : MonoBehaviour
{
    public static Dictionary<string, int> itemWidth = new Dictionary<string, int>();
    public static Dictionary<string, int> itemHeight = new Dictionary<string, int>();
    public static Dictionary<string, float> itemWeight = new Dictionary<string, float>();
    public static Dictionary<string, string> itemScript = new Dictionary<string, string>();
    public static Dictionary<string, string> itemName = new Dictionary<string, string>();
    public static int tutorial;

    private void Awake()
    {
        itemWeight.Clear();
        itemWidth.Clear();
        itemHeight.Clear();
        itemScript.Clear();
        itemName.Clear();


            itemWidth.Add("FirstRoomKey", 1);
            itemWidth.Add("InsectRaid", 1);
            itemWidth.Add("Tape", 1);
            itemWidth.Add("CutterKnife", 1);
            itemWidth.Add("MysteryBox", 2);
            itemWidth.Add("CreditCard", 1);
            itemWidth.Add("BankBook", 1);
        itemWidth.Add("Locker1", 3);
        itemWidth.Add("Steak", 2);
        itemWidth.Add("Money", 1);


        itemHeight.Add("FirstRoomKey", 1);
            itemHeight.Add("InsectRaid", 3);
            itemHeight.Add("Tape", 1);
            itemHeight.Add("CutterKnife", 2);
            itemHeight.Add("MysteryBox", 2);
            itemHeight.Add("CreditCard", 1);
            itemHeight.Add("BankBook", 1);
        itemHeight.Add("Locker1", 3);
        itemHeight.Add("Steak", 1);
        itemHeight.Add("Money", 1);

        itemWeight.Add("FirstRoomKey", 1);
        itemWeight.Add("InsectRaid", 1);
        itemWeight.Add("Tape", 1);
        itemWeight.Add("CutterKnife", 1);
        itemWeight.Add("MysteryBox", 1);
        itemWeight.Add("CreditCard", 1);
        itemWeight.Add("BankBook", 1);
        itemWeight.Add("Locker1", 35);
        itemWeight.Add("Steak", 1);
        itemWeight.Add("Money", 1);

        itemScript.Add("FirstRoomKey", "작고 앙증맞은 열쇠다.");
        itemScript.Add("InsectRaid", "벌레 퇴치엔 파인킬라 라고 적혀있는 살충제다.");
        itemScript.Add("Tape", "반쯤 사용한 청테이프다");
        itemScript.Add("CutterKnife", "테이프와 함께 사용한 듯 보이는 커터칼");
        itemScript.Add("MysteryBox", "금고에 있던 상자. 안에 든 것이 가벼운 듯 하다");
        itemScript.Add("CreditCard", "쓰레기통에서 습득한 의뢰인 명의 신용카드다.");
        itemScript.Add("BankBook", "은지은행의 통장과 인감이다.");
        itemScript.Add("Locker1", "가정용 금고이다");
        itemScript.Add("Steak", "아주 바싹 구워진 스테이크. 식어서 딱딱하다.");
        itemScript.Add("Money", "어디서 발견한 돈뭉치. 귀중한 가치를 지녔을 것으로 보인다.");

        itemName.Add("FirstRoomKey", "금고 열쇠");
        itemName.Add("InsectRaid", "파인킬라");
        itemName.Add("Tape", "테이프");
        itemName.Add("CutterKnife", "커터칼");
        itemName.Add("MysteryBox", "의문의 상자");
        itemName.Add("CreditCard", "신용 카드");
        itemName.Add("BankBook", "통장과 인감");
        itemName.Add("Locker1", "가정용 금고이다");
        itemName.Add("Steak", "탄 고기");
        itemName.Add("Money", "현금");

        tutorial = 0;
    }
}
