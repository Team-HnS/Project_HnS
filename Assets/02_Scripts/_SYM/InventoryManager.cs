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
    //public Text itemNameText; // ������ �̸� �ؽ�Ʈ
    public Text itemDescriptionText; // ������ ���� �ؽ�Ʈ

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
            // ���� �����տ� ������ ���� ����
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
            instance.transform.Find("ItemName").GetComponent<Text>().text = item.ItemName;
            instance.transform.Find("explanation").GetComponent<Text>().text = item.explanation;

            if (item is E_Item)
            {
                //������ϰ�� ���� ���ġ�� text�� �����

            }

            }
        }

    }
        

