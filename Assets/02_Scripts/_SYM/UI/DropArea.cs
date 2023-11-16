
// ��� ������ ��Ÿ���� ��ũ��Ʈ
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
    public Image slotImage; // ��� ������ �̹��� ������Ʈ
    public ItemData currentItemData;
    ItemManager itemManager;

    private void Awake()
    {

    }
    public void AssignItem(ItemData newItemData)
    {
        currentItemData = newItemData;
        // �ʿ��� ��� ���⿡�� �߰� UI ������Ʈ ���� ����
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.dragSlot != null)
            ChangeSlot();

        DragSlot droppedItemSlot = eventData.pointerDrag.GetComponent<DragSlot>();
        if (droppedItemSlot.itemData != null)
        {
            // ��ӵ� ������ ó��
            currentItemData = droppedItemSlot.itemData;
            UpdateSlotUI(currentItemData);
        }
    }

    private void ChangeSlot()
    {
        ItemData tempItemData = currentItemData;
        currentItemData = DragSlot.instance.dragSlot.itemData;
        DragSlot.instance.dragSlot.itemData = tempItemData;

        // UI ������Ʈ
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
            if (slot.itemData != null) // itemData�� �����Ǿ� �ִ��� Ȯ��
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