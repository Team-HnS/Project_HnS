using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GuanYu : MonoBehaviour
{
    Player player;
    public ItemData itemData;
    private TMP_Text nameTag;
    public List<ItemData> items;

    //private void LoadResources()
    //{
    //    e_item = Resources.Load<E_Item>("_아이템/_무기/도원결의를 맺을 수 있다 (물리)");
    //    e_item.UseEffect();
    //}

    private void Awake()
    {
        nameTag = GetComponentInChildren<TMP_Text>();
        nameTag.text = itemData.ItemName;
        InitItemNameColor();
    }
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }
        if (player != null)
        {
            nameTag.color = itemData.item_Color[(int)itemData.item_rank];
        player.Atk += 10;
        player.Str += 10;
        player.Dex += 10;
        }
        else
        {
            Debug.LogError("Player 오브젝트에 PlayerScript가 없습니다.");
        }
    }
    private void InitItemNameColor()
    {
        itemData.item_Color = new Color[5];
        itemData.item_Color[0] = Color.white;
        itemData.item_Color[1] = Color.blue;
        itemData.item_Color[2] = new Color(0.5f, 0f, 0.5f); // 보라
        itemData.item_Color[3] = Color.yellow;
        itemData.item_Color[4] = Color.green;
    }

    
}
