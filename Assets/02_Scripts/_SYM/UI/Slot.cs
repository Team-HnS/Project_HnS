using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static ItemData;


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
            if (this.itemData is C_Item c_Item) // 슬롯의 아이템 데이터가 C_Item 형인지 확인
            {
                ItemManager.Instance.UseC_Item(c_Item, ItemManager.Instance.countItem);
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
    public void SetItem(ItemData item, int quantity)
    {
        // 아이템 아이콘과 이름을 설정합니다.
        itemIcon.sprite = item.item_Icon;

        // 수량이 1보다 크면 수량을 표시하고, 아니면 수량을 표시하지 않습니다.
        if (quantity > 1)
        {
            quantityText.text = quantity.ToString();
        }
        else
        {
            quantityText.text = ""; // 수량이 1인 경우는 표시하지 않음
        }
    }

}
