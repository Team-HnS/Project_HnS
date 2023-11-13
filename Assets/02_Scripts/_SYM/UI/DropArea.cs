
// ��� ������ ��Ÿ���� ��ũ��Ʈ
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DropArea : MonoBehaviour, IDropHandler
{
    public Image slotImage; // ��� ������ �̹��� ������Ʈ

    private void Awake()
    {
        SetImageAlpha(0); // �ʱ� ���İ� ���� (���� ����)
    }

    public void OnDrop(PointerEventData eventData)
    {
        //DragDropItem droppedItem = eventData.pointerDrag.GetComponent<DragDropItem>();
        //if (droppedItem != null)
        //{
        //    slotImage.sprite = droppedItem.itemIcon; // �������� ���������� �̹��� ����
        //    SetImageAlpha(255); // ���İ� ���� (���� ������)
        //}
    }

    private void SetImageAlpha(float alpha)
    {
        Color color = slotImage.color;
        color.a = alpha / 255.0f;
        slotImage.color = color;
    }
}