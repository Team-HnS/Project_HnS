using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryUI : MonoBehaviour
{
    public Transform slotPanel; // ���Ե��� ���� �θ� �г�
    public GameObject slotPrefab; // ���� ������
    private ItemManager inventory; // �κ��丮 ����
    public int inventorySize;


    void Start()
    {
        inventory = FindObjectOfType<ItemManager>(); // �κ��丮 ������Ʈ ã��
        
        UpdateInventoryUI();
    }
    //���� �̸� ����°�
    //void InitializeSlots()
    //{
    //    for (int i = 0; i < inventorySize; i++)
    //    {
    //        Debug.Log("Creating slot: " + i);
    //        Instantiate(slotPrefab, slotPanel);
    //    }
    //}

    public void UpdateInventoryUI()
    {
        // ������ ��� ������ ����
        foreach (Transform child in slotPanel)
        {
            Destroy(child.gameObject);
            Debug.Log(child.gameObject.name);
        }

        // ���ο� ���� ����
        foreach (var item in inventory.items)
        {
            GameObject slot = Instantiate(slotPrefab, slotPanel);
            slot.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
            slot.transform.Find("ItemQuantity").GetComponent<Text>().text = inventory.countItem.ToString();
            slot.transform.Find("explanation").GetComponent<Text>().text = item.ItemName + "\n" + "\n" + item.explanation;

            //quantityText.text = item.quantity.ToString(); // ������ ���� ����
        }
    }
}
