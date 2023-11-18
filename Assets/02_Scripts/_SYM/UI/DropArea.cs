
// 드랍 영역을 나타내는 스크립트
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using DarkLandsUI.Scripts.Equipment;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using System.Collections.Generic;
using static UnityEditor.Progress;
using System.Linq;

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
        if (DragSlot.instance.dragSlot != null)
            ChangeSlot();

        DragSlot droppedItemSlot = eventData.pointerDrag.GetComponent<DragSlot>();
        if (droppedItemSlot.itemData != null && droppedItemSlot.itemData != null)
        {
            if (droppedItemSlot.itemData is E_Item droppedEquipment)
            {
                equipmentUI.currentItemData = droppedItemSlot.itemData;
                currentItemData = droppedItemSlot.itemData as E_Item;
                Debug.Log(equipmentUI.currentItemData.name);
                Debug.Log(currentItemData.name);
                equipmentUI.OnItemDropped(currentItemData);

                ItemManager.Instance.RemoveItemQuantity(currentItemData, 1);
                Debug.Log(currentItemData.name);
            }
            else if (droppedItemSlot.itemData is C_Item)
            {
                Debug.Log(currentItemData.name + "ㅇㅇ");
                currentItemData = droppedItemSlot.itemData;
                UpdateSlotUI(currentItemData);
            }
            else
            {
                Debug.LogError("무기랑 소모품만");
            }

        }

    }

    private void ChangeSlot()
    {
        ItemData tempItemData = currentItemData;
        currentItemData = DragSlot.instance.dragSlot.itemData;
        DragSlot.instance.dragSlot.itemData = tempItemData;

        // UI 업데이트
        foreach (var slot in Slots.ToList())
        {
            if (slot.itemData == currentItemData)
            {
                slot.UpdateSlotUI();
                break;
            }
        }
        DragSlot.instance.dragSlot.UpdateSlotUI();
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