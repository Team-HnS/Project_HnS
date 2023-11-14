using DarkLandsUI.Scripts.Equipment;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using static ItemData;
using static UnityEditor.Progress;


public class Slot : MonoBehaviour
{
    public Image background;
    [SerializeField]
    public ItemData itemData; // Private 필드


    public Sprite NoneBackground;
    public Sprite RareBackground;
    public Sprite EpicBackground;
    public Sprite UniqueBackground;
    public Sprite LegendaryBackground;

    public void UpdateSlotUI()
    {
        if (itemData == null)
        {
            Debug.LogError("슬롯에 ItemData가 할당되지 않았다링");
            return;
        }
        switch (itemData.item_rank)
        {
            case Item_Rank.None:
                background.sprite = NoneBackground;
                break;

            case Item_Rank.Rare:
                background.sprite = RareBackground;
                break;

            case Item_Rank.Epic:
                background.sprite = EpicBackground;
                break;

            case Item_Rank.Unique:
                background.sprite = UniqueBackground;
                break;

            case Item_Rank.Legendary:
                background.sprite = LegendaryBackground;
                break;
        }
    }

}
