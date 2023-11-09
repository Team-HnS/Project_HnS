using DarkLandsUI.Scripts.Equipment;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemManager: MonoBehaviour
{
    public static ItemManager Instance { get; private set; }
    
    public Transform slotPanel;
    public GameObject slotPrefab;
    public Text itemDescriptionText; // ������ ���� �ؽ�Ʈ
    public Text weaponExplanationText;

    private void Awake()
    {
        Instance = this;
    }
    // �������� �κ��丮�� �߰��ϴ� �޼���
    public List<ItemData> AddItem(List<ItemData> items, ItemData newItem)
    {
        // �κ��丮���� ���� �������� ã���ϴ�.
        var existingItem = items.Find(item => item.ItemName == newItem.ItemName);
        if (existingItem != null)
        {
            // ���� �������� ������, ������ ������Ʈ�մϴ�. 
            existingItem.quantity = existingItem.quantity+1;
            Debug.Log(newItem.quantity);
        }
        else
        {
            // �� �������̸� ����Ʈ�� �߰��մϴ�.
            items.Add(newItem);
        }

        // UI ������Ʈ ���� ȣ��
        InitializeInventory(items);

        return items;
    }

    void InitializeInventory(List<ItemData> items)
    {
        foreach (Transform child in slotPanel)
        {
            Destroy(child.gameObject);
        }
        foreach (ItemData item in items)
        {
            GameObject instance = Instantiate(slotPrefab, slotPanel);
            // ���� �����տ� ������ ���� ����
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
            //instance.transform.Find("ItemName").GetComponent<Text>().text = item.ItemName;
            instance.transform.Find("explanation").GetComponent<Text>().text = item.explanation;

            if (item is E_Item)
            {
                GameObject instance1 = Instantiate(slotPrefab, slotPanel);
                //������ϰ�� ���� ���ġ�� text�� �����
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
                //instance.transform.Find("ItemName").GetComponent<Text>().text = item.ItemName;
                instance1.transform.Find("WeaponExplanation").GetComponent<Text>().text = item.explanation;

            }
        }
    }
}
