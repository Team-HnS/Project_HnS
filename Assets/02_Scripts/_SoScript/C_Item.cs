using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/������/�Ҹ�ǰ", order = 0)]

public class C_Item : ItemData
{
    [Header("�Ҹ�ǰ")]
    public int UseCode; //�Ҹ�ǰ �Լ� �ڵ�

    public bool isGone; // 1ȸ������



    public void UseEffect()
    {
        switch (UseCode) 
        {
        case 0://�̰��� 0�� ������ ȿ�� �Է�

                Debug.Log("0�� ������ ���");
                break;

        case 1:
                PlayerManager.instance.player_s.Cur_Hp += 50;
                Debug.Log("1�� ������ ���");
                break;
        }

    }

}
