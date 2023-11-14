using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IDropHandler
{
    ItemManager itemManager;
    private Slot equipmentSlot;

    void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        equipmentSlot = GetComponent<Slot>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragSlot droppedItemSlot = eventData.pointerDrag.GetComponent<DragSlot>();
        if (droppedItemSlot != null)
        {
            // 아이템 데이터 추가
            itemManager.AddItem(droppedItemSlot.itemData, 1);

            // 장비창 UI 업데이트
            UpdateEquipmentUI(droppedItemSlot.itemData);
        }
    }

    private void UpdateEquipmentUI(ItemData itemData)
    {
        if (equipmentSlot != null && itemData != null)
        {
            equipmentSlot.itemData = itemData;
            equipmentSlot.UpdateSlotUI(); // 특정 슬롯의 UI 업데이트
        }
    }
}
