using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{

    public C_Item item;
    public void Test()
    {
        item = Resources.Load<C_Item>("�׽�Ʈ�̸�/500/�׽�Ʈ �����̴�");

        Debug.Log(item.ItemName);
        Debug.Log(item.Price);
        Debug.Log(item.explanation);
        item.UseEffect();
    }
}
