using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// 드래그 가능한 아이템을 나타내는 스크립트
public class DragDropSlot : MonoBehaviour
{
    private GraphicRaycaster _gr;
    private PointerEventData _ped;
    private List<RaycastResult> _rrList;

    private ItemManager _beginDragSlot; // 현재 드래그를 시작한 슬롯
    private Transform _beginDragIconTransform; // 해당 슬롯의 아이콘 트랜스폼

    private Vector3 _beginDragIconPoint;   // 드래그 시작 시 슬롯의 위치
    private Vector3 _beginDragCursorPoint; // 드래그 시작 시 커서의 위치
    private int _beginDragSlotSiblingIndex;
    private void Update()
    {
        _ped.position = Input.mousePosition;

        OnPointerDown();
        OnPointerDrag();
        OnPointerUp();
    }

    private T RaycastAndGetFirstComponent<T>() where T : Component
    {
        _rrList.Clear();

        _gr.Raycast(_ped, _rrList);

        if (_rrList.Count == 0)
            return null;

        return _rrList[0].gameObject.GetComponent<T>();
    }

    private void OnPointerUp()
    {
        throw new NotImplementedException();
    }

    private void OnPointerDrag()
    {
        throw new NotImplementedException();
    }

    private void OnPointerDown()
    {
        // Left Click : Begin Drag
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _beginDragSlot = RaycastAndGetFirstComponent<ItemManager>();

        // 아이템을 갖고 있는 슬롯만 해당
        //if (_beginDragSlot != null && _beginDragSlot.HasItem)
        //{
        //    // 위치 기억, 참조 등록
        //    _beginDragIconTransform = _beginDragSlot.IconRect.transform;
        //    _beginDragIconPoint = _beginDragIconTransform.position;
        //    _beginDragCursorPoint = Input.mousePosition;

        //    // 맨 위에 보이기
        //    _beginDragSlotSiblingIndex = _beginDragSlot.transform.GetSiblingIndex();
        //    _beginDragSlot.transform.SetAsLastSibling();

        //    // 해당 슬롯의 하이라이트 이미지를 아이콘보다 뒤에 위치시키기
        //    _beginDragSlot.SetHighlightOnTop(false);
        //}
        //        else
        //        {
        //            _beginDragSlot = null;
        //        }
        //    }
        //}
    }
}

