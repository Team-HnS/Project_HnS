using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;
using UnityEngine.EventSystems;
using System;

public class EquipmentUI : MonoBehaviour
{
    public ItemData currentItemData;

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
