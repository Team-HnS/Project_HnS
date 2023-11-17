using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class EquipmentSlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public Transform slotPanel;
    public GameObject slotPrefab;
    public ItemManager itemManager;
    private Slot equipmentSlot;


    public List<Slot> Slots;
    //슬롯에 담긴 모든 아이템 리스트
    public List<ItemData> items;

    void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        equipmentSlot = GetComponent<Slot>();
        Debug.Log("장비슬롯");
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragSlot droppedItemSlot = eventData.pointerDrag.GetComponent<DragSlot>();
        if (droppedItemSlot != null && droppedItemSlot.itemData != null)
        {
            RemoveItemFromInventory(droppedItemSlot.itemData);
            AssignItemToEquipmentSlot(droppedItemSlot.itemData);

            // 아이템 데이터 추가
            items.Add(droppedItemSlot.itemData);
            foreach (Transform child in slotPanel)
            {
                Debug.Log("Destroying GameObject: " + child.gameObject.name);
                Destroy(child.gameObject);
            }

            foreach (ItemData item in items)
            {
                if (itemManager.Item_data[item] <= 0)
                {
                    continue;
                }
                GameObject instance = Instantiate(slotPrefab, slotPanel);

                Slot slotInstance = instance.GetComponent<Slot>();
                slotInstance.itemData = item;
                slotInstance.UpdateSlotUI();
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
                instance.transform.Find("ItemQuantity").GetComponent<Text>().text = itemManager.Item_data[item].ToString();
                instance.transform.Find("explanation").GetComponent<Text>().text = item.itemName + "\n" + "\n" + item.explanation;
                

            }

            // 장비창 UI 업데이트
            UpdateEquipmentUI(droppedItemSlot.itemData);
            itemManager.UpdateAllSlots();
        }
        else
        {
            Debug.LogError("Dropped item data is null.");
        }
    }

    private void AssignItemToEquipmentSlot(ItemData itemData)
    {
        if (equipmentSlot != null)
        {
            equipmentSlot.itemData = itemData;
            equipmentSlot.UpdateSlotUI();
        }
    }

    private void RemoveItemFromInventory(ItemData itemData)
    {
        if (itemManager.items.Contains(itemData))
        {
            itemManager.items.Remove(itemData);
            Debug.Log(itemData.ToString());
            itemManager.UpdateAllSlots();
        }
        if (items.Contains(itemData))
        {
            items.Remove(itemData);
        }
    }

    private void UpdateEquipmentUI(ItemData itemData)
    {
        foreach (var slot in Slots)
        {
            if (slot.itemData != null) // itemData가 설정되어 있는지 확인
            {
                slot.UpdateSlotUI();
            }
        }
        if (equipmentSlot != null && itemData != null)
        {
            equipmentSlot.itemData = itemData;
            equipmentSlot.UpdateSlotUI(); // 특정 슬롯의 UI 업데이트

        }
    }
    public void InitializeInventory(List<ItemData> items)
    {
        foreach (Transform child in slotPanel)
        {
            Destroy(child.gameObject);
        }
        foreach (ItemData item in items)
        {
            if (itemManager.Item_data[item] <= 0)
            {
                continue;
            }

            GameObject instance = Instantiate(slotPrefab, slotPanel);

            Slot slotInstance = instance.GetComponent<Slot>();
            slotInstance.itemData = item;
            if (item is E_Item)
            {
                Debug.Log("E Item입니다");
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
                instance.transform.Find("WeaponExplanation").GetComponent<Text>().text = item.itemName + "\n" + "\n" + item.explanation;
            }
            else if (item is C_Item && item is M_Item)
            {
                Debug.Log("E Item말고");
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
                instance.transform.Find("ItemQuantity").GetComponent<Text>().text = itemManager.Item_data[item].ToString();
                instance.transform.Find("explanation").GetComponent<Text>().text = item.itemName + "\n" + "\n" + item.explanation;

            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (items != null)
        {

        }
    }

}
