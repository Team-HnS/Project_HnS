using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;
using UnityEngine.EventSystems;
using System;
using System.Linq;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    public ItemData currentItemData;
    public Transform equipmentPanel;
    public GameObject slotPrefab;
    public List<Slot> equipmentSlots;

    private void Awake()
    {
        // Equipment Slots 리스트 초기화
        equipmentSlots = new List<Slot>(GetComponentsInChildren<Slot>());
    }

    public void OnDrop(PointerEventData eventData)
    {
        DragSlot droppedItemSlot = eventData.pointerDrag.GetComponent<DragSlot>();
        if (droppedItemSlot != null && droppedItemSlot.itemData != null)
        {
            currentItemData = droppedItemSlot.itemData;
            UpdatePlayerStats(currentItemData);
            Debug.Log(currentItemData.name);
        }
    }
    public void CreateEquipmentSlot(ItemData itemData)
    {
        Debug.Log("CreateEquipmentSlot작동");
        GameObject newSlot = Instantiate(slotPrefab, equipmentPanel);
        Slot slotComponent = newSlot.GetComponent<Slot>();
        slotComponent.AssignItem(itemData);
        slotComponent.UpdateSlotUI();
    }
    internal void ProcessDroppedItem(ItemData currentItemData)
    {
        if (currentItemData != null && currentItemData is E_Item)
        {
            Debug.Log("");
        }

    }

    private void UpdatePlayerStats(ItemData itemData)
    {
        if (itemData is E_Item equipmentItem)
        {

        }
    }
}
