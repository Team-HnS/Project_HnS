using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    public ItemManager itemManager;
    public List<Slot> inventoryItems;
    public List<Slot> equipmentSlots;
    public List<Slot> consumableSlots;

    void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        UpdateAllUIs();
    }

    // 모든 UI 업데이트
    public void UpdateAllUIs()
    {
        UpdateUI(inventoryItems, itemManager.items);
        //UpdateUI(equipmentSlots, itemManager.equipmentItems);
        //UpdateUI(consumableSlots, itemManager.consumableItems);
    }

    // 개별 UI 업데이트
    private void UpdateUI(List<Slot> slots, List<ItemData> items)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < items.Count)
            {
                slots[i].itemData = items[i];
                slots[i].UpdateSlotUI();
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    

    


}