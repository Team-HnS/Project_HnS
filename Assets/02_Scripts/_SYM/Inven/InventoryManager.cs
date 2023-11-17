using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    ItemManager itemManager;

    public Transform slotPanel;
    public GameObject slotPrefab;
    //public Text itemDescriptionText; // ������ ���� �ؽ�Ʈ
    //public Text weaponExplanationText;


    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            itemManager = playerObject.GetComponent<ItemManager>();
            Debug.Log(itemManager);
        }
        if (itemManager != null)
        {
            InitializeInventory();
        }
        else
        {
            Debug.LogError("Player ������Ʈ�� PlayerScript�� �����ϴ�.");
        }
    }

    void InitializeInventory()
    {
        foreach (ItemData item in itemManager.items)
        {
            GameObject instance = Instantiate(slotPrefab, slotPanel);
            //���� �����տ� ������ ���� ����
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
            GameObject.Find("explanation").GetComponent<Text>().text = item.explanation;

            if (item is E_Item)
            {
                GameObject instance1 = Instantiate(slotPrefab, slotPanel);
                //������ϰ�� ���� ���ġ�� text�� �����
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
                GameObject.Find("WeaponExplanation").GetComponent<Text>().text = item.explanation;
            }


        }

    }
}


