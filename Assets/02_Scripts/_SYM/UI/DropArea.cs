
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
    ItemManager itemManager;

    private void Awake()
    {

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
        if (droppedItemSlot.itemData != null)
        {
            // 드롭된 아이템 처리
            currentItemData = droppedItemSlot.itemData;
            Debug.Log(currentItemData.name);
            UpdateSlotUI(currentItemData);
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