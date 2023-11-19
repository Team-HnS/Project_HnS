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
    public static EquipmentUI Instance { get; private set; }

    public ItemData currentItemData;
    public Transform equipmentPanel;
    public GameObject slotPrefab;
    public List<Slot> equipmentSlots;

    private void Awake()
    {
        equipmentSlots = new List<Slot>(GetComponentsInChildren<Slot>());
    }

    public void OnDrop(PointerEventData eventData)
    {
        DragSlot droppedItemSlot = eventData.pointerDrag.GetComponent<DragSlot>();
        if (droppedItemSlot != null && droppedItemSlot.itemData is E_Item droppedEquipment)
        {
            if (IsItemAlreadyInEquipmentSlots(droppedEquipment))
            {
                Debug.Log(droppedEquipment.name + " is already equipped.");
            }
            else
            {
                ItemManager.Instance.RemoveItemQuantity(droppedEquipment, 1);
                droppedItemSlot.AssignItem(droppedEquipment);
                ItemManager.Instance.UpdateAllSlots();
            }
        }
    }

    private bool IsItemAlreadyInEquipmentSlots(E_Item item)
    {
        foreach (Slot slot in equipmentSlots)
        {
            if (slot.itemData == item)
            {
                return true;
            }
        }
        return false;
    }

    public void OnItemDropped(ItemData itemData)
    {
        if (itemData is E_Item equipmentItem)
        {
            switch (equipmentItem.Type)
            {
                case E_Item.Equipment_Type.cap:
                    
                    AssignItemToSlot(equipmentSlots[0], equipmentItem);
                    break;
                case E_Item.Equipment_Type.top:
                    
                    AssignItemToSlot(equipmentSlots[4], equipmentItem);
                    break;
                case E_Item.Equipment_Type.pants:
                    
                    AssignItemToSlot(equipmentSlots[3], equipmentItem);
                    break;
                case E_Item.Equipment_Type.shoes:
                    
                    AssignItemToSlot(equipmentSlots[2], equipmentItem);
                    break;
                case E_Item.Equipment_Type.weapon:
                    
                    AssignItemToSlot(equipmentSlots[1], equipmentItem);
                    break;
            }
        }
    }
    public bool IsItemAlreadyEquipped(E_Item item)
    {
        foreach (Slot slot in equipmentSlots)
        {
            if (slot.itemData is E_Item equippedItem && equippedItem.Type == item.Type)
            {
                return true;
            }
        }
        return false;
    }
    public Slot FindSlotByType(E_Item.Equipment_Type type)
    {
        foreach (Slot slot in equipmentSlots)
        {
            if (slot.itemData is E_Item equippedItem && equippedItem.Type == type)
            {
                return slot;
            }
        }
        return null;
    }

    private void AssignItemToSlot(Slot slot, E_Item item)
    {
        if (slot.itemData != null)
        {
            return;
        }

        slot.itemData = item;
        slot.UpdateSlotUI();

        UpdatePlayerStats(item);
    }
    public void ReturnItemToInventory(Slot slot)
    {
        if (slot.itemData != null)
        {
            // 인벤토리에 아이템 추가
            ItemManager.Instance.AddItem(slot.itemData, 1);
            // 슬롯에서 아이템 제거
            slot.ClearSlot();
        }
    }
    private void UpdatePlayerStats(E_Item item)
    {
        PlayerManager.instance.player_s.Max_Hp += item.HpUp;
        PlayerManager.instance.player_s.Max_Mp += item.MpUp;
        PlayerManager.instance.player_s.Atk += item.AtkUp;
        PlayerManager.instance.player_s.Igt += item.ItgUP;
        PlayerManager.instance.player_s.Def += item.DefUp;
        PlayerManager.instance.player_s.Move_Speed += item.Speed;
    }
}
