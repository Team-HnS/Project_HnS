
// ��� ������ ��Ÿ���� ��ũ��Ʈ
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DropArea : MonoBehaviour, IDropHandler
{
    public Image slotImage; // ��� ������ �̹��� ������Ʈ
    public ItemData currentItemData;
    private void Awake()
    {
        SetImageAlpha(0); // �ʱ� ���İ� ���� (���� ����)
    }
    public void AssignItem(ItemData newItemData)
    {
        currentItemData = newItemData;
        // �ʿ��� ��� ���⿡�� �߰� UI ������Ʈ ���� ����
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