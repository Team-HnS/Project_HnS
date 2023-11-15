using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/아이템/코인")]

public class Coin : ItemData
{
    public GameObject goldCoins;
    public GameObject silverCoins;
    public GameObject copperCoins;
    public int coin;
}
