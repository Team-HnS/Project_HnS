
// ��� ������ ��Ÿ���� ��ũ��Ʈ
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;


public class DropArea : MonoBehaviour, IDropHandler
{
    [SerializeField]
    public List<ItemData> items;
    public List<Slot> Slots;
    public Image slotImage; // ��� ������ �̹��� ������Ʈ
    public ItemData currentItemData;
    public EquipmentUI equipmentUI;

    private void Awake()
    {
        equipmentUI = FindObjectOfType<EquipmentUI>();
    }
    public void AssignItem(ItemData newItemData)
    {
        currentItemData = newItemData;
        // �ʿ��� ��� ���⿡�� �߰� UI ������Ʈ ���� ����
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragSlot droppedItemSlot = eventData.pointerDrag.GetComponent<DragSlot>();
        if (droppedItemSlot != null && droppedItemSlot.itemData != null)
        {
            ItemData droppedItemData = droppedItemSlot.itemData;

            if (droppedItemData is E_Item droppedEquipment)
            {
                EquipmentUI equipmentUI = FindObjectOfType<EquipmentUI>();
                if (equipmentUI == null)
                {
                    Debug.LogError("EquipmentUI is null");
                    return;
                }

                // ���� Equipment_Type�� �������� ���â�� �̹� �����ϴ��� Ȯ��
                if (equipmentUI.IsItemAlreadyEquipped(droppedEquipment))
                {
                    ChangeSlot(eventData, droppedEquipment);
                }
                else
                {
                    equipmentUI.currentItemData = droppedItemData;
                    Debug.Log(equipmentUI.currentItemData.name);
                    equipmentUI.OnItemDropped(droppedItemData);
                    ItemManager.Instance.RemoveItemQuantity(droppedItemData, 1);
                }
            }
            else if (droppedItemSlot.itemData is C_Item consumableItem)
            {
                Debug.Log("Consumable item: " + consumableItem.name);
                currentItemData = droppedItemSlot.itemData;
                UpdateSlotUI(currentItemData);
            }
            else
            {
                Debug.LogError("����� �Ҹ�ǰ��");
            }

        }

    }

    private void ChangeSlot(PointerEventData eventData, E_Item newEquipment)
    {
        EquipmentUI equipmentUI = FindObjectOfType<EquipmentUI>();
        if (equipmentUI == null)
        {
            Debug.LogError("EquipmentUI is null");
            return;
        }
        Slot currentEquippedSlot = equipmentUI.FindSlotByType(newEquipment.Type);
        if (currentEquippedSlot != null)
        {
            E_Item currentEquippedItem = currentEquippedSlot.itemData as E_Item;
            if (currentEquippedItem != null)
            {
                // ������ ��ȯ
                currentEquippedSlot.AssignItem(newEquipment);
                ItemManager.Instance.AddItem(currentEquippedItem, 1);
                ItemManager.Instance.RemoveItemQuantity(newEquipment, 1);

                currentEquippedSlot.UpdateSlotUI();
                UpdatePlayerStats(newEquipment, currentEquippedItem);
            }
        }
    }

    private void UpdatePlayerStats(E_Item newItem, E_Item oldItem)
    {
        if (newItem != null)
        {
            // �� �������� ������ �����մϴ�.
            PlayerManager.instance.player_s.Max_Hp += newItem.HpUp;
            PlayerManager.instance.player_s.Max_Mp += newItem.MpUp;
            PlayerManager.instance.player_s.Atk += newItem.AtkUp;
            PlayerManager.instance.player_s.Igt += newItem.ItgUP;
            PlayerManager.instance.player_s.Def += newItem.DefUp;
            PlayerManager.instance.player_s.Move_Speed += newItem.Speed;
        }

        if (oldItem != null)
        {
            // ���� �������� ������ �����մϴ�.
            PlayerManager.instance.player_s.Max_Hp -= oldItem.HpUp;
            PlayerManager.instance.player_s.Max_Mp -= oldItem.MpUp;
            PlayerManager.instance.player_s.Atk -= oldItem.AtkUp;
            PlayerManager.instance.player_s.Igt -= oldItem.ItgUP;
            PlayerManager.instance.player_s.Def -= oldItem.DefUp;
            PlayerManager.instance.player_s.Move_Speed -= oldItem.Speed;
        }
    }

    private void UpdateSlotUI(ItemData currentItemData)
    {
        foreach (var slot in Slots)
        {
            if (slot.itemData != null) // itemData�� �����Ǿ� �ִ��� Ȯ��
            {
                slot.UpdateSlotUI();
            }
        }
    }
}