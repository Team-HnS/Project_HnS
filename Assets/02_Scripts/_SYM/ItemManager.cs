using DarkLandsUI.Scripts.Equipment;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemManager: MonoBehaviour
{
    public Transform slotPanel;
    public GameObject slotPrefab;
    public Text itemDescriptionText; // 아이템 설명 텍스트
    public Text weaponExplanationText;

    // 아이템을 인벤토리에 추가하는 메서드
    public List<ItemData> AddItem(List<ItemData> items, ItemData newItem)
    {
        // 인벤토리에서 같은 아이템을 찾습니다.
        var existingItem = items.Find(item => item.ItemName == newItem.ItemName);
        if (existingItem != null)
        {
            // 같은 아이템이 있으면, 수량을 업데이트합니다.
            existingItem.quantity += newItem.quantity;
        }
        else
        {
            // 새 아이템이면 리스트에 추가합니다.
            items.Add(newItem);
        }

        // UI 업데이트 로직 호출
        InitializeInventory(items);

        return items;
    }

    void InitializeInventory(List<ItemData> items)
    {
        foreach (ItemData item in items)
        {
            GameObject instance = Instantiate(slotPrefab, slotPanel);
            // 슬롯 프리팹에 아이템 정보 설정
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
            //instance.transform.Find("ItemName").GetComponent<Text>().text = item.ItemName;
            instance.transform.Find("explanation").GetComponent<Text>().text = item.explanation;

            if (item is E_Item)
            {
                GameObject instance1 = Instantiate(slotPrefab, slotPanel);
                //장비템일경우 스텟 상승치를 text에 띄워둠
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
                //instance.transform.Find("ItemName").GetComponent<Text>().text = item.ItemName;
                instance1.transform.Find("WeaponExplanation").GetComponent<Text>().text = item.explanation;
            }
        }
    }
}
