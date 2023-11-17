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
    //public Text itemDescriptionText; // 아이템 설명 텍스트
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
            Debug.LogError("Player 오브젝트에 PlayerScript가 없습니다.");
        }
    }

    void InitializeInventory()
    {
        foreach (ItemData item in itemManager.items)
        {
            GameObject instance = Instantiate(slotPrefab, slotPanel);
            //슬롯 프리팹에 아이템 정보 설정
            instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
            GameObject.Find("explanation").GetComponent<Text>().text = item.explanation;

            if (item is E_Item)
            {
                GameObject instance1 = Instantiate(slotPrefab, slotPanel);
                //장비템일경우 스텟 상승치를 text에 띄워둠
                instance.transform.Find("ItemImage").GetComponent<Image>().sprite = item.item_Icon;
                GameObject.Find("WeaponExplanation").GetComponent<Text>().text = item.explanation;
            }


        }

    }
}


