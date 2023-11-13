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
    public int countItem;
    Slot slot;

    public Dictionary<ItemData, int> Item_data = new Dictionary<ItemData, int>();
    public static ItemManager Instance { get; private set; }


    public Transform slotPanel;
    public GameObject slotPrefab;
    //public Text itemDescriptionText; // 아이템 설명 텍스트
    //public Text weaponExplanationText;
    public Item_Rank? FindItemRankByName(string itemName)
    {
        foreach (var item in items)
        {
            if (item.ItemName == itemName)
            {
                return item.item_rank;
            }
        }

        return null; // 아이템을 찾지 못한 경우
    }

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
            // 아이템이 이미 존재하면, 수량을 증가시킵니다.
            Item_data[newItem] += quantity;
            Debug.Log(newItem.name);

            //slot.UpdateSlotUI();
        }
        else
        {
            Debug.Log(newItem.name);
            // 새로운 아이템을 추가하고, 해당 수량을 설정합니다.
            Item_data[newItem] = quantity;
            items.Add(newItem); // 아이템 리스트에도 추가합니다.

            //slot.UpdateSlotUI();
        }

        countItem = CalculateTotalItemCount(); // 전체 아이템 수 업데이트
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
                items.Remove(item); // 아이템 리스트에서도 제거
            }

            countItem = CalculateTotalItemCount(); // 전체 아이템 수 업데이트
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
                continue; // 다음 아이템으로 넘어감
            }

            Debug.Log("Adding item to UI: " + item.ItemName);
            GameObject instance = Instantiate(slotPrefab, slotPanel);
            
            // 슬롯 프리팹에 아이템 정보 설정
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
            instance.transform.Find("ItemQuantity").GetComponent<Text>().text = Item_data[item].ToString();
            instance.transform.Find("explanation").GetComponent<Text>().text = item.ItemName + "\n" + "\n" + item.explanation;

            if (item is E_Item)
            {
                //GameObject instance = Instantiate(slotPrefab, slotPanel);
                //장비템일경우 스텟 상승치를 text에 띄워둠
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
                //instance.transform.Find("ItemName").GetComponent<Text>().text = item.ItemName;
                //instance.transform.Find("ItemQuantity").GetComponent<Text>().text = item.quantity.ToString();
                instance.transform.Find("WeaponExplanation").GetComponent<Text>().text = item.ItemName + "\n" + "\n" + item.explanation;
            }
        }
    }
}
