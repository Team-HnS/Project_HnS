using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;

public class ExpendDropAreaUI : MonoBehaviour, IDropHandler
{
    public Transform expendPanel;
    public GameObject slotPrefab;
    public ItemData currentItemData;
    public List<Slot> expendSlots;

    private void Awake()
    {
        // 소모품 슬롯 리스트 초기화
        expendSlots = new List<Slot>(GetComponentsInChildren<Slot>());
    }
    public void AssignItem(ItemData newItemData)
    {
        currentItemData = newItemData;
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragSlot droppedItemSlot = eventData.pointerDrag.GetComponent<DragSlot>();
        if (droppedItemSlot != null && droppedItemSlot.itemData is C_Item consumableItem)
        {
            ProcessDroppedItem(consumableItem);
        }
    }

    private void ProcessDroppedItem(C_Item consumableItem)
    {// 소모품 아이템이 이미 슬롯에 있는지 확인합니다.
        if (!IsItemAlreadyInExpendSlots(consumableItem))
        {
            // 소모품 슬롯에 아이템이 없으면 새로운 슬롯을 생성합니다.
            CreateExpendSlot(consumableItem);
        }
        else
        {
            // 소모품 슬롯에 아이템이 이미 있으면 수량을 업데이트합니다.
            UpdateExpendSlotQuantity(consumableItem);
        }

        int totalQuantity = ItemManager.Instance.GetItemQuantity(consumableItem);
        //ItemManager.Instance.RemoveItemQuantity(consumableItem, totalQuantity);
        DeleteItemSlotFromInventory(consumableItem);
    }

    private void CreateExpendSlot(C_Item consumableItem)
    {
        foreach (Transform child in expendPanel)
        {
            Destroy(child.gameObject);
        }
        Debug.Log(consumableItem);
        // 새로운 소모품 슬롯을 생성하고 데이터를 할당합니다.
        GameObject newSlot = Instantiate(slotPrefab, expendPanel);
        Slot slotComponent = newSlot.GetComponent<Slot>();
        slotComponent.itemData = consumableItem;
        slotComponent.UpdateSlotUI();  // UI 업데이트 호출
        newSlot.transform.Find("ItemImage").GetComponent<Image>().sprite = consumableItem.item_Icon;
        newSlot.transform.Find("ItemQuantity").GetComponent<Text>().text = ItemManager.Instance.Item_data[consumableItem].ToString();
        Debug.Log(ItemManager.Instance.Item_data[consumableItem]);
        newSlot.transform.Find("explanation").GetComponent<Text>().text = consumableItem.itemName + "\n" + "\n" + consumableItem.explanation;
    }

    private bool IsItemAlreadyInExpendSlots(C_Item consumableItem)
    {
        Debug.Log(consumableItem.name);

        foreach (Slot slot in expendSlots)
        {
            if (slot.itemData == consumableItem)
                return true;
        }
        return false;
    }
    private void CreateExpendSlot()
    {
        Debug.Log("CreateExpendSlot ");
        // 기존의 슬롯들을 제거
        foreach (Transform child in expendPanel)
        {
            Destroy(child.gameObject);
        }

        var consumableItems = ItemManager.Instance.items.Where(item => item is C_Item).ToList();
        Debug.Log(consumableItems is null);
        string strArrayToString = string.Join("", consumableItems);
        Debug.Log(consumableItems);
        // 각 소모품 아이템에 대해 슬롯 생성 및 데이터 할당
        foreach (C_Item consumableItem in consumableItems)
        {
            GameObject newSlot = Instantiate(slotPrefab, expendPanel);
            Debug.Log(newSlot is null);
            Slot slotComponent = newSlot.GetComponent<Slot>();
            slotComponent.AssignItem(consumableItem);
            slotComponent.UpdateSlotUI();

            Debug.Log(slotComponent+"앙");

            expendSlots.Add(slotComponent);
            Debug.Log(expendSlots.Count);
        }
    }
    private void UpdateExpendSlotQuantity(C_Item consumableItem)
    {
        foreach (Slot slot in expendSlots)
        {
            Debug.Log(consumableItem.name);

            if (slot.itemData == consumableItem)
            {
                slot.UpdateSlotUI();
                break;
            }
        }
    }
    private void DeleteItemSlotFromInventory(C_Item consumableItem)
    {
        //Slot[] inventorySlots = FindObjectsOfType<Slot>();
        foreach (Slot slot in expendSlots)
        {
            if (slot.itemData == consumableItem)
            {
                Destroy(slot.gameObject);
                break;
            }
        }
    }
}
