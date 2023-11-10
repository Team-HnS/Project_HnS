using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// 드래그 가능한 아이템을 나타내는 스크립트
public class DragDropItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Sprite itemIcon; // 아이템의 아이콘 이미지
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // 드래그 중 투명도 변경
        canvasGroup.blocksRaycasts = false; // 드래그 중 레이캐스트 블록 해제
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta; // 아이템 위치 업데이트
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f; // 드래그 종료 시 투명도 복원
        canvasGroup.blocksRaycasts = true; // 드래그 종료 시 레이캐스트 블록 복원
    }
}

