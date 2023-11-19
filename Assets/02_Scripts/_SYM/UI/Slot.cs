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


public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Image background;
    [SerializeField]
    public ItemData itemData;
    public C_Item consumableItem;

    private GameObject draggItemClone;
    private CanvasGroup canvasGroup;

    public Image itemIcon;
    public Text quantityText;

    public Sprite NoneBackground;
    public Sprite RareBackground;
    public Sprite EpicBackground;
    public Sprite UniqueBackground;
    public Sprite LegendaryBackground;
    void Awake()
    {

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            // CanvasGroup 컴포넌트가 없다면 추가
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }
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

        if (itemData is E_Item)
        {
            if (quantityText != null)
            {
                quantityText.enabled = false;
            }

        }
        else 
        {
            int quantity = ItemManager.Instance.GetItemQuantity(itemData);
            if (quantityText != null)
            {
                quantityText.text = quantity > 1 ? quantity.ToString() : "";
                if(itemData is C_Item)
                {
                    if (quantity <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }

        // 아이템 설명을 업데이트합니다.
        Text explanationText = transform.Find("explanation").GetComponent<Text>();
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
            else if (itemData is E_Item e_Item)
            {
                EquipmentUI.Instance.ReturnItemToInventory(this);
                int eItemQuantity = ItemManager.Instance.GetItemQuantity(e_Item);
                Debug.Log("E_Item 수량: " + eItemQuantity);
            }
            else
            {
                Debug.Log("이거 뜰 일은 없음 제발");
            }
        }
    }

    
}
