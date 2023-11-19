
// 드랍 영역을 나타내는 스크립트
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;


public class DropArea : MonoBehaviour, IDropHandler
{
    [SerializeField]
    public List<ItemData> items;
    public List<Slot> Slots;
    public Image slotImage; // 드랍 영역의 이미지 컴포넌트
    public ItemData currentItemData;
    public EquipmentUI equipmentUI;

    private void Awake()
    {
        equipmentUI = FindObjectOfType<EquipmentUI>();
    }
    public void AssignItem(ItemData newItemData)
    {
        currentItemData = newItemData;
        // 필요한 경우 여기에서 추가 UI 업데이트 로직 구현
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

                // 같은 Equipment_Type의 아이템이 장비창에 이미 존재하는지 확인
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
                Debug.LogError("무기랑 소모품만");
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
                // 아이템 교환
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
            // 새 아이템의 스탯을 적용합니다.
            PlayerManager.instance.player_s.Max_Hp += newItem.HpUp;
            PlayerManager.instance.player_s.Max_Mp += newItem.MpUp;
            PlayerManager.instance.player_s.Atk += newItem.AtkUp;
            PlayerManager.instance.player_s.Igt += newItem.ItgUP;
            PlayerManager.instance.player_s.Def += newItem.DefUp;
            PlayerManager.instance.player_s.Move_Speed += newItem.Speed;
        }

        if (oldItem != null)
        {
            // 이전 아이템의 스탯을 제거합니다.
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
            if (slot.itemData != null) // itemData가 설정되어 있는지 확인
            {
                slot.UpdateSlotUI();
            }
        }
    }
}