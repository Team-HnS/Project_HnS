using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

using UnityEngine;
using UnityEngine.UI;
using static ItemData;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    public List<ItemData> items;
    public List<Slot> Slots;
    public int countItem;
    Slot slot;

    public Dictionary<ItemData, int> Item_data = new Dictionary<ItemData, int>();
    public static ItemManager Instance { get; private set; }


    public Transform slotPanel;
    public GameObject slotPrefab;
    //public Text itemDescriptionText; // ������ ���� �ؽ�Ʈ
    //public Text weaponExplanationText;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(ItemData newItem, int quantity)
    {
        if (Item_data.ContainsKey(newItem))
        {
            // �������� �̹� �����ϸ�, ������ ������ŵ�ϴ�.
            Item_data[newItem] += quantity;
            Debug.Log(newItem.name);
        }
        else
        {
            Debug.Log(newItem.name);
            // ���ο� �������� �߰��ϰ�, �ش� ������ �����մϴ�.
            Item_data[newItem] = quantity;
            items.Add(newItem); // ������ ����Ʈ���� �߰��մϴ�.
        }

        countItem = CalculateTotalItemCount(); // ��ü ������ �� ������Ʈ
    }

    private int CalculateTotalItemCount()
    {
        int total = 0;
        foreach (var item in Item_data.Values)
        {
            total += item;
        }
        return total;
    }

    public void RemoveItemQuantity(ItemData item, int quantity)
    {
        if (Item_data.ContainsKey(item))
        {
            Item_data[item] -= quantity;
            if (Item_data[item] <= 0)
            {
                Item_data.Remove(item);
                items.Remove(item); // ������ ����Ʈ������ ����
            }

            countItem = CalculateTotalItemCount(); // ��ü ������ �� ������Ʈ
        }
    }


    public void UpdateAllSlots()
    {
        foreach (var slot in Slots)
        {
            if (slot.itemData != null) // itemData�� �����Ǿ� �ִ��� Ȯ��
            {
                slot.UpdateSlotUI();
            }
        }
    }

    public void InitializeInventory(List<ItemData> items)
    {
        Debug.Log("InitializeInventory called. Items count: " + items.Count);
        foreach (Transform child in slotPanel)
        {
            Debug.Log("Destroying GameObject: " + child.gameObject.name);
            Destroy(child.gameObject);
        }
        foreach (ItemData item in items)
        {
            if (Item_data[item] <= 0)
            {
                Debug.Log(Item_data[item]);
                continue; // ���� ���������� �Ѿ
            }

            Debug.Log("Adding item to UI: " + item.ItemName);
            GameObject instance = Instantiate(slotPrefab, slotPanel);

            Slot slotInstance = instance.GetComponent<Slot>();
            slotInstance.itemData = item; // ���⿡�� itemData ����
            slotInstance.UpdateSlotUI();  // UI ������Ʈ ȣ��
            // ���� �����տ� ������ ���� ����
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
            instance.transform.Find("ItemQuantity").GetComponent<Text>().text = Item_data[item].ToString();
            instance.transform.Find("explanation").GetComponent<Text>().text = item.ItemName + "\n" + "\n" + item.explanation;

            if (item is E_Item)
            {
                //GameObject instance = Instantiate(slotPrefab, slotPanel);
                //������ϰ�� ���� ���ġ�� text�� �����
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
                //instance.transform.Find("ItemName").GetComponent<Text>().text = item.ItemName;
                //instance.transform.Find("ItemQuantity").GetComponent<Text>().text = item.quantity.ToString();
                instance.transform.Find("WeaponExplanation").GetComponent<Text>().text = item.ItemName + "\n" + "\n" + item.explanation;
            }
        }
    }
}
