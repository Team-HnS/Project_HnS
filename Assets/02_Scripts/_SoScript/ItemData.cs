using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemData : ScriptableObject
{
    public string ItemName;//�̸�
    public int Price;//����
    public Sprite Item_Icon;//������

    [TextArea]
    public string explanation;


}
