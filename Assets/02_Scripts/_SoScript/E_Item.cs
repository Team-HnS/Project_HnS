using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/������/���", order = 0)]

public class E_Item : ItemData
{

    public int HpUp;//�ִ� ü�� ���ġ
    public int MpUp;//�ִ� ���� ���ġ

    public int AtkUp; // ���ݷ� ���ġ
    public int StrUp;//��
    public int IgtUp;//�������ݷ�
    public int DexUp;//��ø
    public int DefUp;//����

    public int UseCode;//�Ҹ�ǰ �Լ� �ڵ�

    public bool isGone;// 1ȸ������

    public void UseEffect()
    {
        switch (UseCode)
        {
            case 0:
                AtkUp = 10;
                StrUp = 10;
                DexUp = 10;

                Debug.Log("0�� ������ ���");
                
                break;

            case 1:
                break;
        }

    }

}
