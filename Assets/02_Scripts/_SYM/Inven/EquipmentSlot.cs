using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class EquipmentSlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public Transform slotPanel;
    public GameObject slotPrefab;
    public ItemManager itemManager;
    private Slot equipmentSlot;


    public List<Slot> Slots;
    //���Կ� ��� ��� ������ ����Ʈ
    public List<ItemData> items;

    void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        equipmentSlot = GetComponent<Slot>();
        Debug.Log("��񽽷�");
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragSlot droppedItemSlot = eventData.pointerDrag.GetComponent<DragSlot>();
        if (droppedItemSlot != null && droppedItemSlot.itemData != null)
        {
            RemoveItemFromInventory(droppedItemSlot.itemData);
            AssignItemToEquipmentSlot(droppedItemSlot.itemData);

            // ������ ������ �߰�
            items.Add(droppedItemSlot.itemData);
            foreach (Transform child in slotPanel)
            {
                Debug.Log("Destroying GameObject: " + child.gameObject.name);
                Destroy(child.gameObject);
            }

            foreach (ItemData item in items)
            {
                if (itemManager.Item_data[item] <= 0)
                {
                    continue;
                }
                GameObject instance = Instantiate(slotPrefab, slotPanel);

                Slot slotInstance = instance.GetComponent<Slot>();
                slotInstance.itemData = item;
                slotInstance.UpdateSlotUI();
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
                instance.transform.Find("ItemQuantity").GetComponent<Text>().text = itemManager.Item_data[item].ToString();
                instance.transform.Find("explanation").GetComponent<Text>().text = item.itemName + "\n" + "\n" + item.explanation;
                

            }

            // ���â UI ������Ʈ
            UpdateEquipmentUI(droppedItemSlot.itemData);
            itemManager.UpdateAllSlots();
        }
        else
        {
            Debug.LogError("Dropped item data is null.");
        }
    }

    private void AssignItemToEquipmentSlot(ItemData itemData)
    {
        if (equipmentSlot != null)
        {
            equipmentSlot.itemData = itemData;
            equipmentSlot.UpdateSlotUI();
        }
    }

    private void RemoveItemFromInventory(ItemData itemData)
    {
        if (itemManager.items.Contains(itemData))
        {
            itemManager.items.Remove(itemData);
            Debug.Log(itemData.ToString());
            itemManager.UpdateAllSlots();
        }
        if (items.Contains(itemData))
        {
            items.Remove(itemData);
        }
    }

    private void UpdateEquipmentUI(ItemData itemData)
    {
        foreach (var slot in Slots)
        {
            if (slot.itemData != null) // itemData�� �����Ǿ� �ִ��� Ȯ��
            {
                slot.UpdateSlotUI();
            }
        }
        if (equipmentSlot != null && itemData != null)
        {
            equipmentSlot.itemData = itemData;
            equipmentSlot.UpdateSlotUI(); // Ư�� ������ UI ������Ʈ

        }
    }
    public void InitializeInventory(List<ItemData> items)
    {
        foreach (Transform child in slotPanel)
        {
            Destroy(child.gameObject);
        }
        foreach (ItemData item in items)
        {
            if (itemManager.Item_data[item] <= 0)
            {
                continue;
            }

            GameObject instance = Instantiate(slotPrefab, slotPanel);

            Slot slotInstance = instance.GetComponent<Slot>();
            slotInstance.itemData = item;
            if (item is E_Item)
            {
                Debug.Log("E Item�Դϴ�");
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
                instance.transform.Find("WeaponExplanation").GetComponent<Text>().text = item.itemName + "\n" + "\n" + item.explanation;
            }
            else if (item is C_Item && item is M_Item)
            {
                Debug.Log("E Item����");
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
                instance.transform.Find("ItemQuantity").GetComponent<Text>().text = itemManager.Item_data[item].ToString();
                instance.transform.Find("explanation").GetComponent<Text>().text = item.itemName + "\n" + "\n" + item.explanation;

            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (items != null)
        {

        }
    }

}
