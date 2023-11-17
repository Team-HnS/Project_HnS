using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/������/���", order = 0)]

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

    [Header("���")]
    public int HpUp; // �ִ� ü��
    public int MpUp; // �ִ� ����
    public int AtkUp; // ���� ���ݷ�
    public int ItgUP; // ���� ���ݷ�
    public int DefUp; // ����
    public int Speed; // �̵��ӵ�

    public Equipment_Type Type;
}
