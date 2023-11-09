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


    public string ItemName;//�̸�
    public int Price;//����
    public Sprite Item_Icon;//������

    //public int quantity;//������ ����

    public Item_Rank item_rank;
    public Color[] item_Color = new Color[]
      {
            Color.red,       // ������
            Color.white,     // ���         
            Color.blue,      // �Ķ���
            new Color(0.5f, 0f, 0.5f), // �����
            Color.green,     // �ʷϻ�
            new Color(1f, 0.5f, 0f),  // ��Ȳ��
            Color.yellow     // �����
      };

  [TextArea]
    public string explanation;

}
