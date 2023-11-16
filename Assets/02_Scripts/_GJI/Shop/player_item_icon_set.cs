using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_item_icon_set : MonoBehaviour //������ĭ�� ������ �̹����� ����ִ� �ڵ��̴�.
{
    public GameObject gamemanger;
    public GameObject player;
    public List<Button> item_button;
    private List<item_data> item_data_list;
    void Start()
    {
        item_data_list = gamemanger.GetComponent<item_set>().item_data_list;//item_set���� item_data_list�� ã�Ƽ� item_data_list�� ����

    }
    void Update()
    {
        if (item_button[0].GetComponent<Image>().sprite.name == "UISP")
        { //������ĭ 1���� �������� ������ UISP = �⺻ �̹��� 
            if (player.GetComponent<Stats>().item_equip[0] != 0)
            { //������ĭ 1���� �������� ������
                item_button[0].GetComponent<Image>().sprite = Resources.Load<Sprite>(item_data_list[player.GetComponent<Stats>().item_equip[0] - 1].Item_name);
                //������1��ĭ�� IDX���� ���� item�� �̸��� ���� ��������Ʈ�� �������ݴϴ�.
            }
        }
        else
        {//������ĭ 1���� �������� ������
            if (item_button[1].GetComponent<Image>().sprite.name == "UISP")
            {//����ĭ�� �Ȱ��� ����
                if (player.GetComponent<Stats>().item_equip[1] != 0)
                {
                    item_button[1].GetComponent<Image>().sprite = Resources.Load<Sprite>(item_data_list[player.GetComponent<Stats>().item_equip[1] - 1].Item_name);
                }
            }
            else
            {
                if (item_button[2].GetComponent<Image>().sprite.name == "UISP")
                {
                    if (player.GetComponent<Stats>().item_equip[2] != 0)
                    {
                        item_button[2].GetComponent<Image>().sprite = Resources.Load<Sprite>(item_data_list[player.GetComponent<Stats>().item_equip[2] - 1].Item_name);
                    }
                }
                else
                {
                    if (item_button[3].GetComponent<Image>().sprite.name == "UISP")
                    {
                        if (player.GetComponent<Stats>().item_equip[3] != 0)
                        {
                            item_button[3].GetComponent<Image>().sprite = Resources.Load<Sprite>(item_data_list[player.GetComponent<Stats>().item_equip[3] - 1].Item_name);
                        }
                    }
                    else
                    {
                        if (item_button[4].GetComponent<Image>().sprite.name == "UISP")
                        {
                            if (player.GetComponent<Stats>().item_equip[4] != 0)
                            {
                                item_button[4].GetComponent<Image>().sprite = Resources.Load<Sprite>(item_data_list[player.GetComponent<Stats>().item_equip[4] - 1].Item_name);
                            }
                        }
                        else
                        {
                            if (item_button[5].GetComponent<Image>().sprite.name == "UISP")
                            {
                                if (player.GetComponent<Stats>().item_equip[5] != 0)
                                {
                                    item_button[5].GetComponent<Image>().sprite = Resources.Load<Sprite>(item_data_list[player.GetComponent<Stats>().item_equip[5] - 1].Item_name);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public void sell_item_icon(int x)
    {
        item_button[x].GetComponent<Image>().sprite = Resources.Load<Sprite>("UISP");
    }
}