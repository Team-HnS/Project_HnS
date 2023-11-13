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
    ItemData itemData;

    public Sprite NoneBackground;
    public Sprite RareBackground;
    public Sprite EpicBackground;
    public Sprite UniqueBackground;
    public Sprite LegendaryBackground;

    public void UpdateSlotUI()
    {
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

        // 기타 UI 업데이트 로직...
    }
}
