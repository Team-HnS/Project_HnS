using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemData : ScriptableObject
{
    public enum Item_Rank
    {
        None=0,
        Common=1,
        Uncommon=2,
        Rare=3,
        Epic=4,
        Regendary=5,
        Mythic=6
    }


    public string ItemName;//이름
    public int Price;//가격
    public Sprite Item_Icon;//아이콘

    //public int quantity;//아이템 수량

    public Item_Rank item_rank;
    public Color[] item_Color = new Color[]
      {
            Color.red,       // 빨간색
            Color.white,     // 흰색         
            Color.blue,      // 파란색
            new Color(0.5f, 0f, 0.5f), // 보라색
            Color.green,     // 초록색
            new Color(1f, 0.5f, 0f),  // 주황색
            Color.yellow     // 노란색
      };

  [TextArea]
    public string explanation;

}
