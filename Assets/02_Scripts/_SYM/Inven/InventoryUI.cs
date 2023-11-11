using DarkLandsUI.Scripts.Equipment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform slotPanel; // 슬롯들을 담을 부모 패널
    public GameObject slotPrefab; // 슬롯 프리팹
    private ItemManager inventory; // 인벤토리 참조

    void Start()
    {
        inventory = FindObjectOfType<ItemManager>(); // 인벤토리 컴포넌트 찾기
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        // 기존의 모든 슬롯을 제거
        foreach (Transform child in slotPanel)
        {
            Destroy(child.gameObject);
        }

        // 새로운 슬롯 생성
        foreach (var item in inventory.items)
        {
            GameObject slot = Instantiate(slotPrefab, slotPanel);
            Image image = slot.transform.Find("ItemImage").GetComponent<Image>();
            Text quantityText = slot.transform.Find("ItemQuantity").GetComponent<Text>();

            image.sprite = item.Item_Icon; // 아이템 아이콘 설정
            quantityText.text = item.quantity.ToString(); // 아이템 수량 설정
        }
    }
}
