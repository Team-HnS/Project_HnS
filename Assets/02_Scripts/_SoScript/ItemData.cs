using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemData : ScriptableObject
{
    public string ItemName;//이름
    public int Price;//가격
    public Sprite Item_Icon;//아이콘

    [TextArea]
    public string explanation;


}
