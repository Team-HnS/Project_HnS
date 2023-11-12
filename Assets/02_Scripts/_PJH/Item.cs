using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using static ItemData;

public class Item : MonoBehaviour
{
    public ItemData itemData;
    private TMP_Text nameTag;
    public List<ItemData> items;
    public string code;

    private void Awake()
    {
        nameTag = GetComponentInChildren<TMP_Text>();
        nameTag.text = itemData.ItemName;
        InitItemNameColor();
    }

    private void Start()
    {
        nameTag.color = itemData.item_Color[(int)itemData.item_rank];
    }

    private void InitItemNameColor()
    {
        itemData.item_Color = new Color[5];
        itemData.item_Color[0] = Color.white;
        itemData.item_Color[1] = Color.blue;
        itemData.item_Color[2] = new Color(0.5f, 0f, 0.5f); // º¸¶ó
        itemData.item_Color[3] = Color.yellow;
        itemData.item_Color[4] = Color.green;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Item itemComponent = GetComponent<Item>();
            //if (itemComponent != null)
            //{
            //    items = ItemManager.Instance.AddItem(items, itemComponent.itemData);
            //    Destroy(gameObject);
            //}
            Destroy(gameObject);
        }
    }
}

