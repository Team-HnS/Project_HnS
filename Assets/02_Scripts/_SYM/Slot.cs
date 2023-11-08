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

   
    public Text itemNameText; // ������ �̸� �ؽ�Ʈ
    public Text itemDescriptionText; // ������ ���� �ؽ�Ʈ

    public void SetItem(ItemData item)
    {
        
        //itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.explanation;
    }

}
