using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public int GetItemQuantity(ItemData item)
    {
        if (Item_data.TryGetValue(item, out int quantity))
        {
            return quantity;
        }
        return 0;
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
            Debug.Log(Item_data[item].ToString());
            if (Item_data[item] <= 0)
            {
                RemoveItemSlot(item);
                Item_data.Remove(item);
                items.Remove(item); // 아이템 리스트에서도 제거
                foreach (var slot in Slots)
                {
                    if (slot.itemData == item)
                    {
                        slot.ClearSlot();
                        break;
                    }
                }
            }
            countItem = CalculateTotalItemCount(); // 전체 아이템 수 업데이트
            Debug.Log(countItem.ToString());
            UpdateAllSlots();
        }
    }

    private void RemoveItemSlot(ItemData item)
    {
        foreach (var slot in Slots.ToList())
        {
            if (slot.itemData == item)
            {
                GameObject slotGameObject = slot.gameObject;
                Debug.Log("Destroying slot: " + slotGameObject.name);
                Destroy(slotGameObject);
                Slots.Remove(slot);
                slot.UpdateSlotUI();

                break;
            }
        }
    }

    public void UseC_Item(C_Item c_Item, int c_ItemCount)
    {
        c_Item.UseEffect();
        int currentQuantity = GetItemQuantity(c_Item);
        if (currentQuantity > 0)
        {
            RemoveItemQuantity(c_Item, 1);
            UpdateAllSlots();

            if (GetItemQuantity(c_Item) == 0)
            {
                RemoveItemSlot(c_Item);
                UpdateAllSlots();
            }
        }
        else
        {
            RemoveItemSlot(c_Item);
            Debug.Log("아이템이 없습니다.");
        }

    }


    public void UpdateAllSlots()
    {
        foreach (var slot in Slots)
        {
            if (slot.itemData != null) // itemData가 설정되어 있는지 확인
            {
                slot.UpdateSlotUI();
            }
            else
            {
                slot.ClearSlot();
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
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
            instance.transform.Find("ItemQuantity").GetComponent<Text>().text = Item_data[item].ToString();
            instance.transform.Find("explanation").GetComponent<Text>().text = item.itemName + "\n" + "\n" + item.explanation;
        }
    }
}
