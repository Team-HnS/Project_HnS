using UnityEngine;
using UnityEngine.EventSystems;

public class PanelParentlUI : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.SetSiblingIndex(1);
    }
}