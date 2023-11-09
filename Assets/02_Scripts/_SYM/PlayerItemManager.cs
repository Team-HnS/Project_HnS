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
            Debug.Log("Collision" + collision.gameObject.name);
            Item itemComponent = collision.gameObject.GetComponent<Item>();
            Debug.Log("itemComponent" + collision.gameObject.GetComponent<Item>());
            if (itemComponent != null)
            {
                items = ItemManager.Instance.AddItem(items, itemComponent.itemData);
                Debug.Log(items);
                
            }
        }
    }
}
