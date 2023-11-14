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

    public string ItemName;//�̸�
    public int Max_Amount;//�ִ� ����,���� ������ �ϳ�
    public int Price;//����    
    public Sprite Item_Icon;//������
    public bool isCoin;
    public GameObject itemObj;

    public Item_Rank item_rank;
    [HideInInspector]
    public Color[] item_Color;


    [TextArea]
    public string explanation;

}
