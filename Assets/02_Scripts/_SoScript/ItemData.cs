using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemData : ScriptableObject
{
    public enum Item_Rank
    {
        None = 0,
        Rare = 1,
        Epic = 2,
        Unique = 3,
        Legendary = 4
    }

    public string ItemName;//이름
    public int quantity;//개수
    public int Price;//가격    
    public Sprite Item_Icon;//아이콘
    

    public Item_Rank item_rank;
    [HideInInspector]
    public Color[] item_Color;


    [TextArea]
    public string explanation;

}
