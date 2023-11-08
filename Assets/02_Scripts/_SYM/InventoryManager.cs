using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Transform slotPanel; 
    public GameObject slotPrefab;
    public ItemCollection ItemCollection;
    //public Text itemNameText; // 아이템 이름 텍스트
    public Text itemDescriptionText; // 아이템 설명 텍스트

    //private List<C_Item> inventoryManager = new List<C_Item>();
    //private List<M_Item> inventoryManager1 = new List<M_Item>();
    void Start()
    {
        InitializeInventory();  
    }

    void InitializeInventory()
    {
        foreach(ItemData item in ItemCollection.items)
        {
            GameObject instance = Instantiate(slotPrefab, slotPanel);
            // 슬롯 프리팹에 아이템 정보 설정
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
            instance.transform.Find("ItemName").GetComponent<Text>().text = item.ItemName;
            instance.transform.Find("explanation").GetComponent<Text>().text = item.explanation;

            if (item is E_Item)
            {
                //장비템일경우 스텟 상승치를 text에 띄워둠

            }

            }
        }

    }
        

