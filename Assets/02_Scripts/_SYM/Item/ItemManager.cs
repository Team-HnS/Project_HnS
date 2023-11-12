using DarkLandsUI.Scripts.Equipment;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    public List<ItemData> items;
    public static ItemManager Instance { get; private set; }

    public Transform slotPanel;
    public GameObject slotPrefab;
    //public Text itemDescriptionText; // ������ ���� �ؽ�Ʈ
    //public Text weaponExplanationText;


    private void Awake()
    {
        Instance = this;
    }
    // �������� �κ��丮�� �߰��ϴ� �޼���
    public List<ItemData> AddItem(List<ItemData> items, ItemData newItem)
    {
        // �κ��丮���� ���� �������� ã��
        var existingItem = items.Find(item => item.ItemName == newItem.ItemName);
        Debug.Log(newItem.name);
        if (existingItem != null)
        {
            // ���� �������� ������, ������ ������Ʈ
            existingItem.quantity = existingItem.quantity + 1;
            Debug.Log(newItem.quantity);
        }
        else
        {
            // �� �������̸� ����Ʈ�� �߰�
            items.Add(newItem);
            Debug.Log(newItem.ItemName);
        }

        // UI ������Ʈ ���� ȣ��
        InitializeInventory(items);
        return items;
    }

    public void InitializeInventory(List<ItemData> items)
    {
        Debug.Log("InitializeInventory called. Items count: " + items.Count);
        foreach (Transform child in slotPanel)
        {
            Debug.Log("Destroying GameObject: " + child.gameObject.name);
            Destroy(child.gameObject);
        }
        foreach (ItemData item in items)
        {
            if (item.quantity <= 0)
            {
                continue; // ���� ���������� �Ѿ
            }

            Debug.Log("Adding item to UI: " + item.ItemName);
            GameObject instance = Instantiate(slotPrefab, slotPanel);
            // ���� �����տ� ������ ���� ����
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
            instance.transform.Find("ItemQuantity").GetComponent<Text>().text = item.quantity.ToString();
            instance.transform.Find("explanation").GetComponent<Text>().text = item.explanation;

            if (item is E_Item)
            {
                //GameObject instance = Instantiate(slotPrefab, slotPanel);
                //������ϰ�� ���� ���ġ�� text�� �����
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
                //instance.transform.Find("ItemName").GetComponent<Text>().text = item.ItemName;
                instance.transform.Find("ItemQuantity").GetComponent<Text>().text = item.quantity.ToString();
                instance.transform.Find("WeaponExplanation").GetComponent<Text>().text = item.explanation;

            }
        }
    }
}
