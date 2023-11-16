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
    private List<item_data> item_data_list;
    public GameObject shopPanel; // �����۸���� �����ִ� �г�
    public Button buy_btn;
    public Button sell_btn;
    public Image item_icon;
    void Start()
    {
        buy_btn.GetComponent<Button>().onClick.AddListener(buy_item);
        sell_btn.GetComponent<Button>().onClick.AddListener(sell_item);
        item_data_list = gamemanger.GetComponent<item_set>().item_data_list;
        int j = 0;//������
        int k = 0;//������
        int galo = 5;//������
        //������ ����Ʈ ��ŭ ��ü����
        for (int i = 0; 2 * k < item_data_list.Count; i++)//�����۰�����ŭ ����  //item_data_list.Count=3�� (����) ������ ī��Ʈ�� ���� 10����� �׸��� �����ٿ� 2�� �Ѵٸ�  1 2 1 2 1 2 1 2 �� 5��
        {
            for (j = 0; j < galo; j++)//������
            {
                GameObject item = Instantiate(Resources.Load<GameObject>("item"));
                item.GetComponent<item_data_update>().I_D = item_data_list[j + k * galo];
                item.transform.SetParent(shopPanel.transform);
                item.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                item.transform.localPosition = new Vector3(-130 + 60 * j, -60 * k, 0);//���� ����
                item.GetComponent<item_data_update>().item_data = item_data_list[j + k * galo];
            }
            k++;
        }
        this.gameObject.SetActive(false);//����ȣ��ɶ� ǥ�õ����ʰ���
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
            Debug.Log("��尡 �����մϴ�.");
        }
    }
    public void sell_item()
    {
        //find item in player's inventory
        player.GetComponent<Stats>().sell_item_player(seleceted_item.GetComponent<item_data_update>().I_D.IDX);
        player.GetComponent<Stats>().gold += sel_price / 80;

    }
    void Update()
    {
        gold = player.GetComponent<Stats>().gold;
    }
}