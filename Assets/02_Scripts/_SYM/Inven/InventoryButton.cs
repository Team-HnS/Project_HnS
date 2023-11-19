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
            Debug.LogError("Button 컴포넌트를 찾을 수 없습니다.");
        }
    }

    private void UpdateInventoryUI()
    {
        if (itemManager != null)
        {
            // 아이템 매니저의 로직을 여기서 실행
            itemManager.InitializeInventory(itemManager.items);
        }
        else
        {
            Debug.LogError("ItemManager가 씬에 존재하지 않습니다.");
        }
    }
}
