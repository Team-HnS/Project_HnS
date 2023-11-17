using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shop : MonoBehaviour
{
    public GameObject gamemanger;
    public GameObject player;
    public Text got_gold;
    public float gold;
    public float sel_price;
    public Text sel_item_price;
    public Image sel_item_image;
    public GameObject seleceted_item;
    public List<item_data> item_data_list;
    public GameObject shopPanel; // �����۸����?�����ִ� �г�
    public Button buy_btn;
    public Button sell_btn;
    public Image item_icon;
    void Start()
    {
        buy_btn.GetComponent<Button>().onClick.AddListener(buy_item);
        sell_btn.GetComponent<Button>().onClick.AddListener(sell_item);
        item_data_list = gamemanger.GetComponent<item_set>().item_data_list;
        this.gameObject.SetActive(false);//����ȣ��ɶ�?ǥ�õ����ʰ���
    }
    public void buy_item()
    {
        sel_price = seleceted_item.GetComponent<item_data_update>().I_D.Price;
        if (sel_price < gold)
        {
            player.GetComponent<Stats>().gold = gold - sel_price;
            player.GetComponent<Stats>().get_item(seleceted_item.GetComponent<item_data_update>().I_D.IDX);
        }
        else
        {
            Debug.Log(" Gold X ");
        }
    }
    public void sell_item()
    {
        
        player.GetComponent<Stats>().sell_item_player(seleceted_item.GetComponent<item_data_update>().I_D.IDX);
        player.GetComponent<Stats>().gold += sel_price / 80;

    }
    void Update()
    {
        //gold = player.GetComponent<Stats>().gold;
    }
}