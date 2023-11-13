using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// �巡�� ������ �������� ��Ÿ���� ��ũ��Ʈ
public class DragDropSlot : MonoBehaviour
{
    private GraphicRaycaster _gr;
    private PointerEventData _ped;
    private List<RaycastResult> _rrList;

    private ItemManager _beginDragSlot; // ���� �巡�׸� ������ ����
    private Transform _beginDragIconTransform; // �ش� ������ ������ Ʈ������

    private Vector3 _beginDragIconPoint;   // �巡�� ���� �� ������ ��ġ
    private Vector3 _beginDragCursorPoint; // �巡�� ���� �� Ŀ���� ��ġ
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

        // �������� ���� �ִ� ���Ը� �ش�
        //if (_beginDragSlot != null && _beginDragSlot.HasItem)
        //{
        //    // ��ġ ���, ���� ���
        //    _beginDragIconTransform = _beginDragSlot.IconRect.transform;
        //    _beginDragIconPoint = _beginDragIconTransform.position;
        //    _beginDragCursorPoint = Input.mousePosition;

        //    // �� ���� ���̱�
        //    _beginDragSlotSiblingIndex = _beginDragSlot.transform.GetSiblingIndex();
        //    _beginDragSlot.transform.SetAsLastSibling();

        //    // �ش� ������ ���̶���Ʈ �̹����� �����ܺ��� �ڿ� ��ġ��Ű��
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

