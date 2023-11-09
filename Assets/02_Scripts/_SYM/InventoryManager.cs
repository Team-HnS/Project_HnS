using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Transform slotPanel;
    public GameObject slotPrefab;
    public Text itemDescriptionText; // 아이템 설명 텍스트
    public Text weaponExplanationText;

    PlayerItemManager ItemManager;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            ItemManager = playerObject.GetComponent<PlayerItemManager>();
        }
        if (ItemManager != null)
        {
            InitializeInventory();
        }
        else
        {
            Debug.LogError("Player 오브젝트에 PlayerScript가 없습니다.");
        }
    }

    void InitializeInventory()
    {
        foreach (ItemData item in ItemManager.items)
        {
            GameObject instance = Instantiate(slotPrefab, slotPanel);
            //슬롯 프리팹에 아이템 정보 설정
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
            instance.transform.Find("ItemQuantity").GetComponent<Text>().text = item.quantity.ToString();
            instance.transform.Find("explanation").GetComponent<Text>().text = item.explanation;

            if (item is E_Item)
            {
                GameObject instance1 = Instantiate(slotPrefab, slotPanel);
                //장비템일경우 스텟 상승치를 text에 띄워둠
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.Item_Icon;
                instance.transform.Find("ItemQuantity").GetComponent<Text>().text = item.quantity.ToString();
                instance1.transform.Find("WeaponExplanation").GetComponent<Text>().text = item.explanation;


            }


        }

    }
}


