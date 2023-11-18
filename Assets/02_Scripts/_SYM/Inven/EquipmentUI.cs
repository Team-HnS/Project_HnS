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
            Debug.Log(currentItemData.name);
            currentItemData = droppedItemSlot.itemData;
            UpdatePlayerStats(currentItemData as E_Item);
            Debug.Log(currentItemData.name);
            ItemManager.Instance.RemoveItemQuantity(currentItemData, 1);
            ItemManager.Instance.UpdateAllSlots();
            Debug.Log(currentItemData.name);

            OnItemDropped(currentItemData);
            Debug.Log(currentItemData.name);

        }
    }
    public void CreateEquipmentSlot(ItemData itemData)
    {
        if (IsItemAlreadyInEquipmentSlots(itemData))
        {
            Debug.Log("아이템이 이미 장비창에 존재합니다: " + itemData.name);
            return;
        }
        Debug.Log("CreateEquipmentSlot작동");
        GameObject newSlot = Instantiate(slotPrefab, equipmentPanel);
        Slot slotComponent = newSlot.GetComponent<Slot>();
        slotComponent.AssignItem(itemData);
        slotComponent.UpdateSlotUI();

        equipmentSlots.Add(slotComponent);
    }

    private bool IsItemAlreadyInEquipmentSlots(ItemData itemData)
    {
        return equipmentSlots.Any(slot => slot.itemData == itemData);
    }
    // EquipmentUI 스크립트의 일부로 가정
    public void OnItemDropped(ItemData itemData)
    {
        // 드랍된 아이템이 E_Item 형인지 확인
        if (itemData is E_Item equipmentItem)
        {
            Debug.Log(equipmentItem.name);
            // E_Item의 equipmentType을 확인
            switch (equipmentItem.Type)
            {
                case E_Item.Equipment_Type.cap:
                    
                    AssignItemToSlot(equipmentSlots[0], equipmentItem);
                    break;
                case E_Item.Equipment_Type.top:
                    
                    AssignItemToSlot(equipmentSlots[1], equipmentItem);
                    break;
                case E_Item.Equipment_Type.pants:
                    
                    AssignItemToSlot(equipmentSlots[1], equipmentItem);
                    break;
                case E_Item.Equipment_Type.shoes:
                    
                    AssignItemToSlot(equipmentSlots[1], equipmentItem);
                    break;
                case E_Item.Equipment_Type.weapon:
                    
                    AssignItemToSlot(equipmentSlots[1], equipmentItem);
                    break;

            }
        }
    }

    private void AssignItemToSlot(Slot slot, E_Item item)
    {
        // 슬롯에 이미 아이템이 있는지 확인
        if (slot.itemData != null)
        {
            // 이미 장착된 아이템 처리 (예: 인벤토리로 되돌리기)
            return;
        }

        // 슬롯에 새 아이템 할당
        slot.itemData = item;
        slot.UpdateSlotUI();

        // 플레이어 통계 업데이트
        UpdatePlayerStats(item);
    }

    private void UpdatePlayerStats(E_Item item)
    {
        PlayerManager.instance.player_s.Cur_Hp += item.HpUp;
        PlayerManager.instance.player_s.Cur_Mp += item.MpUp;
        PlayerManager.instance.player_s.Atk += item.AtkUp;
        PlayerManager.instance.player_s.Igt += item.ItgUP;
        PlayerManager.instance.player_s.Def += item.DefUp;
        PlayerManager.instance.player_s.Move_Speed += item.Speed;
    }

    // Slot 클래스 내의 UpdateSlotUI 메서드
    public void UpdateSlotUI()
    {
        
    }

}
