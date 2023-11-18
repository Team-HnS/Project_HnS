using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance { get; private set; }

    [SerializeField]
    public ItemManager itemManager;
    public List<Slot> equipmentSlots;
    public List<Slot> consumableSlots;
    public List<Slot> inventorySlots;

    public GameObject slotPrefab;

    public Transform slotPanel;

    private void Awake()
    {
        // 싱글톤 초기화
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        // 나머지 초기화 코드...
    }
    public void UpdateInventoryUI()
    {
        // 기존의 모든 슬롯을 제거합니다.
        foreach (Transform child in slotPanel)
        {
            Destroy(child.gameObject);
        }

        // 새로운 슬롯들을 생성합니다.
        foreach (var item in ItemManager.Instance.items)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotPanel);
            Slot slotComponent = newSlot.GetComponent<Slot>();
            slotComponent.AssignItem(item);
            slotComponent.UpdateSlotUI();
        }
    }
}