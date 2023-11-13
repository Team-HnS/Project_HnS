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
    //    e_item = Resources.Load<E_Item>("_������/_����/�������Ǹ� ���� �� �ִ� (����)");
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
            Debug.LogError("Player ������Ʈ�� PlayerScript�� �����ϴ�.");
        }
    }
    private void InitItemNameColor()
    {
        itemData.item_Color = new Color[5];
        itemData.item_Color[0] = Color.white;
        itemData.item_Color[1] = Color.blue;
        itemData.item_Color[2] = new Color(0.5f, 0f, 0.5f); // ����
        itemData.item_Color[3] = Color.yellow;
        itemData.item_Color[4] = Color.green;
    }

    
}
