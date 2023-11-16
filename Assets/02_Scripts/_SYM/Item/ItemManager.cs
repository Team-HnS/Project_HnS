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
    public int PlayerCoin = 0;

    Slot slot;

    public Text coinCountText;

    public Dictionary<ItemData, int> Item_data = new Dictionary<ItemData, int>();
    public static ItemManager Instance { get; private set; }


    public Transform slotPanel;
    public GameObject slotPrefab;
    //public Text weaponExplanationText;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            UpdateCoinUI();
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateCoinUI()
    {
        coinCountText.text = "Coins : " + PlayerCoin.ToString();
    }

    public void AddItem(ItemData newItem, int quantity)
    {
        Debug.Log(newItem.name);
        switch (newItem)
        {
            case Coin_Item coinItem:
                //음
                AddCoin(quantity);
                break;

            case E_Item equipmentItem:
                AddEquipment(equipmentItem, quantity);
                break;

            case C_Item consumableItem:
                AddToInventory(newItem, quantity);
                break;

            case M_Item miscItem:
                AddToInventory(newItem, quantity);
                break;

            default:
                Debug.LogError("알 수 없는 아이템 타입: " + newItem.GetType());
                break;
        }
        countItem = CalculateTotalItemCount(); // 전체 아이템 수 업데이트

    }
    public void AddCoin(int amount)
    {
        PlayerCoin += amount;
        UpdateCoinUI();

    }
    public void UseCoin(int itemPrice)
    {
        PlayerCoin -= itemPrice;
        UpdateCoinUI();

    }
    private void AddEquipment(E_Item equipmentItem, int quantity)
    {

        if (Item_data.ContainsKey(equipmentItem))
        {
            // 아이템이 이미 존재하면, 수량 증가
            Item_data[equipmentItem] += quantity;
            Debug.Log(equipmentItem.name);
            if (items is null)
            {
                Item_data[equipmentItem] = quantity;
                items.Add(equipmentItem);
            }
        }
        else
        {
            Debug.Log(equipmentItem.name);
            // 새로운 아이템을 추가하고, 해당 수량을 설정합니다.
            Item_data[equipmentItem] = quantity;
            items.Add(equipmentItem); // 아이템 리스트에도 추가합니다.
        }
        countItem = CalculateTotalItemCount(); // 전체 아이템 수 업데이트
    }

    private void AddToInventory(ItemData newItem, int quantity)
    {
        if (Item_data.ContainsKey(newItem))
        {
            // 아이템이 이미 존재하면, 수량을 증가시킵니다.
            Item_data[newItem] += quantity;
            Debug.Log(newItem.name);
            if (items is null)
            {
                Item_data[newItem] = quantity;
                items.Add(newItem);
            }
        }
        else
        {
            Debug.Log(newItem.name);
            // 새로운 아이템 추가하고, 해당 수량을 설정합니다.
            Item_data[newItem] = quantity;
            items.Add(newItem); // 아이템 리스트에도 추가합니다.
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

                RemoveItemSlot(item);
            }
            countItem = CalculateTotalItemCount(); // 전체 아이템 수 업데이트
            UpdateAllSlots();
        }
    }

    private void RemoveItemSlot(ItemData item)
    {
        foreach (var slot in Slots)
        {
            if (slot.itemData == item)
            {
                // 해당 아이템을 가진 슬롯을 찾아 UI 업데이트
                slot.itemData = null;
                slot.UpdateSlotUI();
                break;
            }
        }
    }

    public void UseC_Item(C_Item c_Item, int c_ItemCount)
    {
        Debug.Log("매니저 함수 실행");
        c_Item.UseEffect();

        //아이템 수량 감소 및 UI 업데이트
        RemoveItemQuantity(c_Item, c_ItemCount);
        Debug.Log(c_ItemCount.ToString());
    }


    public void UpdateAllSlots()
    {
        foreach (var slot in Slots)
        {
            if (slot.itemData != null) // itemData가 설정되어 있는지 확인
            {
                foreach (ItemData item in items)
                {
                    if (Item_data[item] <= 0)
                    {
                        Debug.Log(Item_data[item]);
                        continue;
                    }
                    slot.UpdateSlotUI();

                    GameObject instance = Instantiate(slotPrefab, slotPanel);
                    Slot slotInstance = instance.GetComponent<Slot>();
                    slotInstance.itemData = item; // 여기에서 itemData 설정
                    slotInstance.UpdateSlotUI();  // UI 업데이트 호출

                    // 슬롯 프리팹에 아이템 정보 설정
                    instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
                    instance.transform.Find("ItemQuantity").GetComponent<Text>().text = Item_data[item].ToString();
                    instance.transform.Find("explanation").GetComponent<Text>().text = item.itemName + "\n" + "\n" + item.explanation;
                }
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
                continue;
            }

            GameObject instance = Instantiate(slotPrefab, slotPanel);

            Slot slotInstance = instance.GetComponent<Slot>();
            slotInstance.itemData = item; // 여기에서 itemData 설정
            slotInstance.UpdateSlotUI();  // UI 업데이트 호출

            // 슬롯 프리팹에 아이템 정보 설정
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
            instance.transform.Find("ItemQuantity").GetComponent<Text>().text = Item_data[item].ToString();
            instance.transform.Find("explanation").GetComponent<Text>().text = item.itemName + "\n" + "\n" + item.explanation;

            if (item is E_Item)
            {
                //GameObject instance = Instantiate(slotPrefab, slotPanel);
                //장비템일경우 스텟 상승치를 text에 띄워둠
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
                instance.transform.Find("WeaponExplanation").GetComponent<Text>().text = item.itemName + "\n" + "\n" + item.explanation;
            }
        }
    }
}
