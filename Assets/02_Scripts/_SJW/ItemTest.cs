using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{

    public C_Item item;
    public void Test()
    {
        item = Resources.Load<C_Item>("_������/_�Ҹ�ǰ/�Ҹ�ǰ�׽�Ʈ");

        Debug.Log(item.ItemName);
        Debug.Log(item.Price);
        Debug.Log(item.explanation);
        item.UseEffect();

    }
}
