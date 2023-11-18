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

    [Header("�⺻ ����")]
    public string itemName;
    public GameObject itemObj;
    public Item_Rank item_rank;
    [HideInInspector] public Color[] item_Color;

    [Header("������ ����")]   
    public Sprite item_Icon; // �κ��丮�� �� ������
    public int quantity; // ������ ����
    public int price;
    
    [Header("���� ����")]                    
    public bool isCoin;

    [Header("������ ����")]
    [TextArea] public string explanation;
}
