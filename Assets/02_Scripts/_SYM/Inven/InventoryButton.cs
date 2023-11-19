using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    private ItemManager itemManager;
    public Button button;

    void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(UpdateInventoryUI);
        }
        else
        {
            Debug.LogError("Button ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    private void UpdateInventoryUI()
    {
        if (itemManager != null)
        {
            // ������ �Ŵ����� ������ ���⼭ ����
            itemManager.InitializeInventory(itemManager.items);
        }
        else
        {
            Debug.LogError("ItemManager�� ���� �������� �ʽ��ϴ�.");
        }
    }
}
