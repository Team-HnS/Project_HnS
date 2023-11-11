using DarkLandsUI.Scripts.Equipment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform slotPanel; // ���Ե��� ���� �θ� �г�
    public GameObject slotPrefab; // ���� ������
    private ItemManager inventory; // �κ��丮 ����

    void Start()
    {
        inventory = FindObjectOfType<ItemManager>(); // �κ��丮 ������Ʈ ã��
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        // ������ ��� ������ ����
        foreach (Transform child in slotPanel)
        {
            Destroy(child.gameObject);
        }

        // ���ο� ���� ����
        foreach (var item in inventory.items)
        {
            GameObject slot = Instantiate(slotPrefab, slotPanel);
            Image image = slot.transform.Find("ItemImage").GetComponent<Image>();
            Text quantityText = slot.transform.Find("ItemQuantity").GetComponent<Text>();

            image.sprite = item.Item_Icon; // ������ ������ ����
            quantityText.text = item.quantity.ToString(); // ������ ���� ����
        }
    }
}
