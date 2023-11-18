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
    

    public Image itemIcon;
    public Text quantityText;

    public Sprite NoneBackground;
    public Sprite RareBackground;
    public Sprite EpicBackground;
    public Sprite UniqueBackground;
    public Sprite LegendaryBackground;
    private void Start()
    {
        if (itemData != null)
        {
            Debug.Log("������ ����");
            UpdateSlotUI();
        }
        else
        {
            Debug.Log("������ ����");
            ClearSlot();
            return;
        }
    }
    public void UpdateSlotUI()
    {
        if (itemData != null)
        {
            // ������ ������ ������Ʈ
            itemIcon.sprite = itemData.item_Icon;
            itemIcon.enabled = true;

            // ������ ���� ������Ʈ
            quantityText.text = ItemManager.Instance.GetItemQuantity(itemData).ToString();
        }
        else
        {
            // �������� ������ UI�� �ʱ�ȭ�մϴ�.
            itemIcon.enabled = false;
            quantityText.text = "";
        }
        if (itemData == null)
        {
            if (itemIcon != null) itemIcon.enabled = false;
            if (quantityText != null) quantityText.enabled = false;
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

        int quantity = ItemManager.Instance.GetItemQuantity(itemData);

        if (quantityText != null )
        {
            quantityText.text = quantity > 1 ? quantity.ToString() : "";
        }
        // ������ 0�̸� ������ �ı��ϰų� ��Ȱ��ȭ
        if (quantity <= 0)
        {
            Destroy(gameObject); // ���� ������ GameObject�� �ı�
        }

        if (itemIcon != null)
        {
            itemIcon.sprite = itemData.item_Icon;
            itemIcon.enabled = true;  // ������ Ȱ��ȭ

            Text explanationText = transform.Find("explanation").GetComponent<Text>();
            if (explanationText != null)
            {
                explanationText.text = itemData.itemName + "\n" + "\n" + itemData.explanation;
            }
            else
            {
                Debug.LogError("Explanation Text ������Ʈ�� ã�� �� �����ϴ�.");
            }
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
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (this.itemData is C_Item consumableItem) // ������ ������ �����Ͱ� C_Item ������ Ȯ��
            {
                ItemManager.Instance.UseC_Item(consumableItem, ItemManager.Instance.countItem);
                UpdateSlotUI();
            }
            else
            {
                UpdateSlotUI();
                Debug.LogError("�Ҹ�ǰ �������� �ƴմϴ�.");
            }
        }
    }
}
