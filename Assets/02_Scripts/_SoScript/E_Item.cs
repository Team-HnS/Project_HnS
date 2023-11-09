using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/아이템/장비", order = 0)]

public class E_Item : ItemData
{

    public int HpUp;//최대 체력 상승치
    public int MpUp;//최대 마나 상승치

    public int AtkUp; // 공격력 상승치
    public int StrUp;//힘
    public int IgtUp;//마법공격력
    public int DexUp;//민첩
    public int DefUp;//방어력

    public int UseCode;//소모품 함수 코드

    public bool isGone;// 1회용인지

    public void UseEffect()
    {
        switch (UseCode)
        {
            case 0:
                AtkUp = 10;
                StrUp = 10;
                DexUp = 10;

                Debug.Log("0번 아이템 사용");
                
                break;

            case 1:
                break;
        }

    }

}
