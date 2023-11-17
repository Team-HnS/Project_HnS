using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/아이템/장비", order = 0)]

public class E_Item : ItemData
{
    public enum Equipment_Type
    {
        cap,
        top,
        pants,
        shoes,
        weapon
    }

    [Header("장비")]
    public int HpUp; // 최대 체력
    public int MpUp; // 최대 마나
    public int AtkUp; // 물리 공격력
    public int ItgUP; // 마법 공격력
    public int DefUp; // 방어력
    public int Speed; // 이동속도

    public Equipment_Type Type;
}
