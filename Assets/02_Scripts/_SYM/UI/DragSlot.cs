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

//아이템 슬롯에 관련된 스크립트

public class DragSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{//IPointerClickHandler
    static public DragSlot instance;
    public Slot dragSlot;
    public List<Slot> Slots;
    public List<ItemData> inventoryItems; //인벤 아이템 리스트
    public ItemData currentItemData; // 현재 드래그 중인 아이템 데이터
    private GameObject draggedItemClone;    //드래그 아이템 복사본
    private CanvasGroup canvasGroup;    //드래그 아이템 원본

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
            // CanvasGroup 컴포넌트가 없다면 추가
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }
    void Start()
    {
        instance = this;
        itemData = GetComponent<Slot>().itemData; // ItemManager 인스턴스 찾기
        

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
                Slots[i].itemData = itemManager.items[i]; // 아이템 데이터 할당
                Slots[i].UpdateSlotUI(); // UI 업데이트
            }
        }
    }

    // 마우스 드래그가 시작 됐을 때 발생하는 이벤트
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
            // 원본 슬롯 숨기기
            canvasGroup.alpha = 0.0f;
            draggedItemClone.transform.SetAsLastSibling(); // 클론을 캔버스 상의 최상단에 위치
        }
    }

    // 마우스 드래그 중일 때 계속 발생하는 이벤트
    public void OnDrag(PointerEventData eventData)
    {
        if (draggedItemClone != null)
        {
            draggedItemClone.transform.position = eventData.position; // 드래그 중 클론 위치 업데이트
        }

    }
    // 마우스 드래그가 끝났을 때 발생하는 이벤트
    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedItemClone != null)
        {
            Destroy(draggedItemClone); // 드래그 종료 시 클론 제거
            draggedItemClone = null; // 참조 초기화
        }
        canvasGroup.alpha = 1.0f; // 원본 슬롯 다시 보이게 하기
        UpdateInventoryUI();
    }

    //마우스 클릭 시
    //public void OnPointerClick(PointerEventData eventData)
    //{

    //}

    //아이템 드롭했을 때
    public void OnDrop(PointerEventData eventData)
    {
        DropArea dropArea = eventData.pointerCurrentRaycast.gameObject.GetComponent<DropArea>();
        if (dropArea != null)
        {
            Debug.Log(dropArea != null);
            // DropArea에 아이템 전달
            dropArea.AssignItem(currentItemData);
            Debug.Log(currentItemData.name);

            // 인벤토리에서 해당 아이템 제거
            inventoryItems.Remove(currentItemData);
            currentItemData = null; // 현재 아이템 데이터 초기화
            
            // 인벤토리 UI 업데이트 (예: 슬롯 비우기)
            UpdateInventoryUI();
        }

        foreach (var slot in Slots)
        {
            if (slot.itemData != null) // itemData가 설정되어 있는지 확인
            {
                slot.UpdateSlotUI();
            }
        }

    }

    private void UpdateInventoryUI()
    {
        foreach (var slot in Slots) // inventorySlots는 모든 인벤토리 슬롯의 리스트
        {
            if (slot.itemData != null)
            {
                slot.UpdateSlotUI();
            }
            else
            {
                // 아이템이 없는 경우
                slot.GetComponent<Image>().sprite = null; // 아이콘 제거
                                                          // 추가적인 정보 초기화
            }
        }
    }
}