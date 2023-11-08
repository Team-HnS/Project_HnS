using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class Slot : MonoBehaviour
{

   
    public Text itemNameText; // 아이템 이름 텍스트
    public Text itemDescriptionText; // 아이템 설명 텍스트

    public void SetItem(ItemData item)
    {
        
        //itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.explanation;
    }

}
