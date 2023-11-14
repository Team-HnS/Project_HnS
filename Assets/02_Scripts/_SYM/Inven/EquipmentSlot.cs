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
            // ������ ������ �߰�
            itemManager.AddItem(droppedItemSlot.itemData, 1);

            // ���â UI ������Ʈ
            UpdateEquipmentUI(droppedItemSlot.itemData);
        }
    }

    private void UpdateEquipmentUI(ItemData itemData)
    {
        if (equipmentSlot != null && itemData != null)
        {
            equipmentSlot.itemData = itemData;
            equipmentSlot.UpdateSlotUI(); // Ư�� ������ UI ������Ʈ
        }
    }
}
