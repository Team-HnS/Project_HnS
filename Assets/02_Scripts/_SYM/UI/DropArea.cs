
// 드랍 영역을 나타내는 스크립트
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using DarkLandsUI.Scripts.Equipment;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using System.Collections.Generic;
using static UnityEditor.Progress;

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
        //SetImageAlpha(0); // 초기 알파값 설정 (완전 투명)
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
        if (droppedItemSlot != null)
        {
            // 드롭된 아이템 처리
            currentItemData = droppedItemSlot.itemData;
            UpdateSlotUI(currentItemData);
        }
    }

    private void ChangeSlot()
    {
        
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

    private void SetImageAlpha(float alpha)
    {
        Color color = slotImage.color;
        color.a = alpha / 255.0f;
        slotImage.color = color;
    }
}