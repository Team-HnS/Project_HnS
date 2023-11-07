using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemData : ScriptableObject
{
    public string ItemName;//�̸�
    public int Price;//����
    public Sprite Item_Icon;//������

    public List<string> Item_Rank;
    public List<Color> Item_Color;


    [TextArea]
    public string explanation;


}
