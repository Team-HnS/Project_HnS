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
    public int Max_Amount;//최대 개수,장비는 무조건 하나
    public int Price;//가격    
    public Sprite Item_Icon;//아이콘
    public bool isCoin;
    public GameObject itemObj;

    public Item_Rank item_rank;
    [HideInInspector]
    public Color[] item_Color;


    [TextArea]
    public string explanation;

}
