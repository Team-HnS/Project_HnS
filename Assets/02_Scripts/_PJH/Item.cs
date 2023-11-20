using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;
    private TMP_Text nameTag;

    public int coinAmount; // 코인인 경우

    //[HideInInspector]public List<ItemData> items;

    private void Awake()
    {
        nameTag = GetComponentInChildren<TMP_Text>();
        nameTag.text = itemData.itemName;
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
        itemData.item_Color[2] = new Color(0.5f, 0f, 0.5f); // 보라
        itemData.item_Color[3] = Color.yellow;
        itemData.item_Color[4] = Color.green;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Item itemComponent = GetComponent<Item>();
            if (itemComponent != null)
            {
                if(itemData.isCoin)
                {
                    ItemManager.Instance.AddCoin(coinAmount);
                }
                else
                {
                    ItemManager.Instance.AddItem(itemComponent.itemData, 1);
                }
            }
            Destroy(gameObject);
        }
    }
}

