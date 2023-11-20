using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    public ItemData data;

    public Image itemImage;
    public TMP_Text itemName;
    public TMP_Text itemExplanation;
    public TMP_Text price;


    // Start is called before the first frame update
    void Start()
    {
        itemImage.sprite = data.item_Icon;
        itemName.text = data.itemName;
        itemExplanation.text = data.explanation;
        price.text = data.price.ToString();
    }

    public void BuyItem()
    {
        ItemManager.Instance.CanBuy(data.price);
        Debug.Log("µé¾î¿È " + ItemManager.Instance.allowBuy);
        if (ItemManager.Instance.allowBuy)
        {
            ItemManager.Instance.AddItem(data, data.quantity);
            ItemManager.Instance.InitializeShopSlots();
            ItemManager.Instance.UseCoin(data.price);
            ItemManager.Instance.allowBuy = false;
            
        }

    }
}
