//using DarkLandsUI.Scripts.Equipment;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using static UnityEditor.Progress;


//public class Slot : MonoBehaviour
//{
//    public C_Item C_item; // ȹ���� ������
//    public int itemCount; // ȹ���� �������� ����
//    public Image itemImage;  // �������� �̹���

//    [SerializeField]
//    private Text text_Count;
//    [SerializeField]
//    private GameObject go_CountImage;

//    // ������ �̹����� ���� ����
//    private void SetColor(float _alpha)
//    {
//        Color color = itemImage.color;
//        color.a = _alpha;
//        itemImage.color = color;
//    }

//    // �κ��丮�� ���ο� ������ ���� �߰�
//    public void AddItem(C_Item c_item, int c_count = 1)
//    {
//        C_item = c_item;
//        itemCount = c_count;
//        itemImage.sprite = C_item.itemImage;

//        if (C_item.itemType != C_Item.ItemType.Equipment)
//        {
//            go_CountImage.SetActive(true);
//            text_Count.text = itemCount.ToString();
//        }
//        else
//        {
//            text_Count.text = "0";
//            go_CountImage.SetActive(false);
//        }

//        SetColor(1);
//    }

//    // �ش� ������ ������ ���� ������Ʈ
//    public void SetSlotCount(int _count)
//    {
//        itemCount += _count;
//        text_Count.text = itemCount.ToString();

//        if (itemCount <= 0)
//            ClearSlot();
//    }

//    // �ش� ���� �ϳ� ����
//    private void ClearSlot()
//    {
//        C_item = null;
//        itemCount = 0;
//        itemImage.sprite = null;
//        SetColor(0);

//        text_Count.text = "0";
//        go_CountImage.SetActive(false);
//    }

//}
