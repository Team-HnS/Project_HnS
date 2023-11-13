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
    public Transform slotPanel; // 슬롯들을 담을 부모 패널
    public GameObject slotPrefab; // 슬롯 프리팹
    private ItemManager inventory; // 인벤토리 참조
    public int inventorySize;


    void Start()
    {
        inventory = FindObjectOfType<ItemManager>(); // 인벤토리 컴포넌트 찾기
        
        UpdateInventoryUI();
    }
    //슬롯 미리 만드는거
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
        // 기존의 모든 슬롯을 제거
        foreach (Transform child in slotPanel)
        {
            Destroy(child.gameObject);
            Debug.Log(child.gameObject.name);
        }

        // 새로운 슬롯 생성
        foreach (var item in inventory.items)
        {
            GameObject slot = Instantiate(slotPrefab, slotPanel);
            slot.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
            slot.transform.Find("ItemQuantity").GetComponent<Text>().text = inventory.countItem.ToString();
            slot.transform.Find("explanation").GetComponent<Text>().text = item.ItemName + "\n" + "\n" + item.explanation;

            //quantityText.text = item.quantity.ToString(); // 아이템 수량 설정
        }
    }
}
