using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemManager : MonoBehaviour
{
    [SerializeField]
    ItemManager itemManager;
    public List<ItemData> items;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            items = itemManager.AddItem(items, collision.gameObject.GetComponent<Item>().itemData);
        }
    }
}
