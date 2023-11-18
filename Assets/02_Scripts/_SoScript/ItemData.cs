using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemData : ScriptableObject
{
    public enum Item_Rank
    {
        Coin = 0,
        Rare = 1,
        Epic = 2,
        Unique = 3,
        Legendary = 4
    }

    [Header("기본 정보")]
    public string itemName;
    public GameObject itemObj;
    public Item_Rank item_rank;
    [HideInInspector] public Color[] item_Color;

    [Header("아이템 정보")]   
    public Sprite item_Icon; // 인벤토리에 들어갈 아이콘
    public int quantity; // 아이템 개수
    public int price;
    
    [Header("코인 정보")]                    
    public bool isCoin;

    [Header("아이템 설명")]
    [TextArea] public string explanation;
}
