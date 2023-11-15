using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/아이템/소모품", order = 0)]

public class C_Item : ItemData
{
    [Header("소모품")]
    public int UseCode; //소모품 함수 코드

    public bool isGone; // 1회용인지

    Player player;


    public void UseEffect()
    {
        switch (UseCode) 
        {
        case 0://이곳에 0번 아이템 효과 입력

                Debug.Log("0번 아이템 사용");
                break;

        case 1:
                player.Cur_Hp += 50;
                Debug.Log("1번 아이템 사용");
                break;
        }

    }

}
