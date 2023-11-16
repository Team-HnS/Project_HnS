using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static ItemData;
using static UnityEditor.Progress;


public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Image background;
    [SerializeField]
    public ItemData itemData;
    public C_Item consumableItem;
    Slot slotPrefab;
    

    private void Start()
    {
        if (itemData != null)
        {
            UpdateSlotUI(); // 슬롯 UI 업데이트
        }
        else
        {
            ClearSlot(); // 슬롯 초기화
        }
    }

    public Sprite NoneBackground;
    public Sprite RareBackground;
    public Sprite EpicBackground;
    public Sprite UniqueBackground;
    public Sprite LegendaryBackground;

    public void UpdateSlotUI()
    {
        if (itemData == null)
        {
            Debug.LogError("슬롯에 ItemData가 할당되지 않았다링");
            return;
        }
        switch (itemData.item_rank)
        {
            case Item_Rank.Coin:
                background.sprite = NoneBackground;
                break;

            case Item_Rank.Rare:
                background.sprite = RareBackground;
                break;

            case Item_Rank.Epic:
                background.sprite = EpicBackground;
                break;

            case Item_Rank.Unique:
                background.sprite = UniqueBackground;
                break;

            case Item_Rank.Legendary:
                background.sprite = LegendaryBackground;
                break;
        }
    }

    internal void AssignItem(ItemData itemToMove)
    {
        throw new NotImplementedException();
    }

    internal void ClearSlot()
    {
        itemData = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log(eventData);
            if (this.itemData is C_Item consumableItem) // 슬롯의 아이템 데이터가 C_Item 형인지 확인
            {
                ItemManager.Instance.UseC_Item(consumableItem, ItemManager.Instance.countItem);
            }
            else
            {
                Debug.LogError("소모품 아이템이 아닙니다.");
            }
        }
    }
}
