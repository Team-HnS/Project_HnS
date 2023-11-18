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
        // Equipment Slots ����Ʈ �ʱ�ȭ
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
            Debug.Log("�������� �̹� ���â�� �����մϴ�: " + itemData.name);
            return;
        }
        Debug.Log("CreateEquipmentSlot�۵�");
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
    // EquipmentUI ��ũ��Ʈ�� �Ϻη� ����
    public void OnItemDropped(ItemData itemData)
    {
        // ����� �������� E_Item ������ Ȯ��
        if (itemData is E_Item equipmentItem)
        {
            Debug.Log(equipmentItem.name);
            // E_Item�� equipmentType�� Ȯ��
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
        // ���Կ� �̹� �������� �ִ��� Ȯ��
        if (slot.itemData != null)
        {
            // �̹� ������ ������ ó�� (��: �κ��丮�� �ǵ�����)
            return;
        }

        // ���Կ� �� ������ �Ҵ�
        slot.itemData = item;
        slot.UpdateSlotUI();

        // �÷��̾� ��� ������Ʈ
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

    // Slot Ŭ���� ���� UpdateSlotUI �޼���
    public void UpdateSlotUI()
    {
        
    }

}
