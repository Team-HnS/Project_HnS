using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

//������ ���Կ� ���õ� ��ũ��Ʈ

public class DragSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{//IPointerClickHandler
    static public DragSlot instance;
    public Slot dragSlot;
    public List<Slot> Slots;
    public List<ItemData> inventoryItems; //�κ� ������ ����Ʈ
    public ItemData currentItemData; // ���� �巡�� ���� ������ ������
    private GameObject draggedItemClone;    //�巡�� ������ ���纻
    private CanvasGroup canvasGroup;    //�巡�� ������ ����

    public ItemData itemData;
    ItemManager itemManager;
    private Vector2 originalPosition;

    [SerializeField]
    private Image imageItem;

    void Awake()
    {
        instance = this;

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            // CanvasGroup ������Ʈ�� ���ٸ� �߰�
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }
    void Start()
    {
        instance = this;
        itemData = GetComponent<Slot>().itemData; // ItemManager �ν��Ͻ� ã��
        

    }
    public void DragSetImage(Image _itemImage)
    {
        imageItem.sprite = _itemImage.sprite;
        SetColor(1);
    }

    public void SetColor(float _alpha)
    {
        Color color = imageItem.color;
        color.a = _alpha;
        imageItem.color = color;
    }
    public void InitializeSlotsFromItemManager(ItemManager itemManager)
    {
        for (int i = 0; i < itemManager.countItem; i++)
        {
            if (i < Slots.Count)
            {
                Slots[i].itemData = itemManager.items[i]; // ������ ������ �Ҵ�
                Slots[i].UpdateSlotUI(); // UI ������Ʈ
            }
        }
    }

    // ���콺 �巡�װ� ���� ���� �� �߻��ϴ� �̺�Ʈ
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemData == null)
        {
            Debug.LogError("ItemData is null on drag start.");
            return;
        }
        if (draggedItemClone == null)
        {
            draggedItemClone = Instantiate(gameObject, transform.parent);

            CanvasGroup canvasGroupClone = draggedItemClone.GetComponent<CanvasGroup>();
            if (canvasGroupClone == null)
            {
                canvasGroupClone = draggedItemClone.AddComponent<CanvasGroup>();
            }
            canvasGroupClone.blocksRaycasts = false;
            // ���� ���� �����
            canvasGroup.alpha = 0.0f;
            draggedItemClone.transform.SetAsLastSibling(); // Ŭ���� ĵ���� ���� �ֻ�ܿ� ��ġ
        }
    }

    // ���콺 �巡�� ���� �� ��� �߻��ϴ� �̺�Ʈ
    public void OnDrag(PointerEventData eventData)
    {
        if (draggedItemClone != null)
        {
            draggedItemClone.transform.position = eventData.position; // �巡�� �� Ŭ�� ��ġ ������Ʈ
        }

    }
    // ���콺 �巡�װ� ������ �� �߻��ϴ� �̺�Ʈ
    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedItemClone != null)
        {
            Destroy(draggedItemClone); // �巡�� ���� �� Ŭ�� ����
            draggedItemClone = null; // ���� �ʱ�ȭ
        }
        canvasGroup.alpha = 1.0f; // ���� ���� �ٽ� ���̰� �ϱ�
        UpdateInventoryUI();
    }

    //���콺 Ŭ�� ��
    //public void OnPointerClick(PointerEventData eventData)
    //{

    //}

    //������ ������� ��
    public void OnDrop(PointerEventData eventData)
    {
        DropArea dropArea = eventData.pointerCurrentRaycast.gameObject.GetComponent<DropArea>();
        if (dropArea != null)
        {
            Debug.Log(dropArea != null);
            // DropArea�� ������ ����
            dropArea.AssignItem(currentItemData);
            Debug.Log(currentItemData.name);

            // �κ��丮���� �ش� ������ ����
            inventoryItems.Remove(currentItemData);
            currentItemData = null; // ���� ������ ������ �ʱ�ȭ
            
            // �κ��丮 UI ������Ʈ (��: ���� ����)
            UpdateInventoryUI();
        }

        foreach (var slot in Slots)
        {
            if (slot.itemData != null) // itemData�� �����Ǿ� �ִ��� Ȯ��
            {
                slot.UpdateSlotUI();
            }
        }

    }

    private void UpdateInventoryUI()
    {
        foreach (var slot in Slots) // inventorySlots�� ��� �κ��丮 ������ ����Ʈ
        {
            if (slot.itemData != null)
            {
                slot.UpdateSlotUI();
            }
            else
            {
                // �������� ���� ���
                slot.GetComponent<Image>().sprite = null; // ������ ����
                                                          // �߰����� ���� �ʱ�ȭ
            }
        }
    }
}