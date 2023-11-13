
// 드랍 영역을 나타내는 스크립트
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DropArea : MonoBehaviour, IDropHandler
{
    public Image slotImage; // 드랍 영역의 이미지 컴포넌트

    private void Awake()
    {
        SetImageAlpha(0); // 초기 알파값 설정 (완전 투명)
    }

    public void OnDrop(PointerEventData eventData)
    {
        //DragDropItem droppedItem = eventData.pointerDrag.GetComponent<DragDropItem>();
        //if (droppedItem != null)
        //{
        //    slotImage.sprite = droppedItem.itemIcon; // 아이템의 아이콘으로 이미지 변경
        //    SetImageAlpha(255); // 알파값 설정 (완전 불투명)
        //}
    }

    private void SetImageAlpha(float alpha)
    {
        Color color = slotImage.color;
        color.a = alpha / 255.0f;
        slotImage.color = color;
    }
}