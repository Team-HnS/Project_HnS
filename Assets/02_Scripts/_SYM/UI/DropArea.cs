
// 드랍 영역을 나타내는 스크립트
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DropArea : MonoBehaviour, IDropHandler
{
    public Image slotImage; // 드랍 영역의 이미지 컴포넌트
    public ItemData currentItemData;
    private void Awake()
    {
        SetImageAlpha(0); // 초기 알파값 설정 (완전 투명)
    }
    public void AssignItem(ItemData newItemData)
    {
        currentItemData = newItemData;
        // 필요한 경우 여기에서 추가 UI 업데이트 로직 구현
    }
    public void OnDrop(PointerEventData eventData)
    {
        DragSlot droppedSlot = eventData.pointerDrag.GetComponent<DragSlot>();
        if (droppedSlot != null)
        {
            
        }
    }

    private void SetImageAlpha(float alpha)
    {
        Color color = slotImage.color;
        color.a = alpha / 255.0f;
        slotImage.color = color;
    }
}