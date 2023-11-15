using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{

    public C_Item item;
    public void Test()
    {
        item = Resources.Load<C_Item>("_아이템/_소모품/소모품테스트");

        Debug.Log(item.itemName);
        Debug.Log(item.price);
        Debug.Log(item.explanation);
        item.UseEffect();

    }
}
