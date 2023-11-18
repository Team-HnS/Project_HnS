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
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;


public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler
{
    public Image background;
    [SerializeField]
    public ItemData itemData;
    public C_Item consumableItem;

    private GameObject draggedItemClone;
    private CanvasGroup canvasGroup;


    public Image itemIcon;
    public Text quantityText;

    public Sprite NoneBackground;
    public Sprite RareBackground;
    public Sprite EpicBackground;
    public Sprite UniqueBackground;
    public Sprite LegendaryBackground;
    private void Start()
    {
        UpdateSlotUI();
    }
    public void UpdateSlotUI()
    {
        if (itemData == null)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        if (itemIcon != null)
        {
            itemIcon.sprite = itemData.item_Icon;
            itemIcon.enabled = true;
        }

        // 장비 아이템의 경우 수량을 표시하지 않습니다.
        int quantity = ItemManager.Instance.GetItemQuantity(itemData);
        if (itemData is E_Item)
        {
            if (quantityText != null)
            {
                quantityText.enabled = false;
            }

            if (quantity <= 0)
            {
                Destroy(gameObject); // 현재 슬롯의 GameObject를 파괴
            }
        }
        else 
        {
            if (quantityText != null)
            {
                quantityText.text = quantity > 1 ? quantity.ToString() : "";
            }

            if (quantity <= 0)
            {
                Destroy(gameObject); // 현재 슬롯의 GameObject를 파괴
            }
        }

        // 아이템 설명을 업데이트합니다.
        Text explanationText = transform.Find("explanation").GetComponent<Text>();
        //Text amountText = transform.Find("ItemQuantity").GetComponent<Text>();
        if (explanationText != null)
        {
            //amountText.text = ItemManager.Instance.Item_data[itemData].ToString();
            explanationText.text = itemData.itemName + "\n" + "\n" + itemData.explanation;
        }
        else
        {
            Debug.LogError("Explanation Text 컴포넌트를 찾을 수 없습니다.");
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

    internal void AssignItem(ItemData newItemData)
    {
        itemData = newItemData;
        UpdateSlotUI();
    }

    internal void ClearSlot()
    {
        itemData = null;
        UpdateSlotUI();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemData == null)
        {
            Debug.LogError("ItemData is null on drag start.");
            return;
        }
        if (draggedItemClone == null)
        {
            Debug.Log("draggedItemClone is null");
            draggedItemClone = Instantiate(gameObject, transform.parent);

            CanvasGroup canvasGroupClone = draggedItemClone.GetComponent<CanvasGroup>();
            if (canvasGroupClone == null)
            {
                canvasGroupClone = draggedItemClone.AddComponent<CanvasGroup>();
            }
            canvasGroupClone.blocksRaycasts = false;
            // 원본 슬롯 숨기기
            canvasGroup.alpha = 0.0f;
            draggedItemClone.transform.SetAsLastSibling(); // 클론을 캔버스 상의 최상단에 위치
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (this.itemData is C_Item consumableItem) // 슬롯의 아이템 데이터가 C_Item 형인지 확인
            {
                ItemManager.Instance.UseC_Item(consumableItem, ItemManager.Instance.countItem);
                UpdateSlotUI();
            }
            else
            {
                Debug.LogError("소모품 아이템이 아닙니다.");
            }
        }
    }

    
}
