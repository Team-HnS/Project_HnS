using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public GameObject gamemanger;
    #region ü�°��� ����
    public float hp; public float maxHp;
    public float mp; public float maxMp;
    #endregion
    #region ���ݰ��� ����
    public float atk; public float atk_speed; public float atk_range;
    #endregion
    #region ������ ����
    public float def;
    #endregion
    #region �̵����� ����
    public float spd;
    #endregion
    #region ������ ����
    public float team;
    #endregion
    #region ������ ����
    public float gold; public float kill_gold;
    #endregion
    #region ������Ʈ���� ����
    public NavMeshAgent agent;
    #endregion

    #region �����۰��� ����
    public int[] item_equip;
    #endregion

    public Image item_icon;

    void Start()
    {
       
        //item_equip = new int[6];//6���� ����������â�� ����

    }
  
    /*public void get_gold(float got_gold)//óġ�� ����� kill_gold���� �޾Ƽ� ��带 ����
    {
        gold += got_gold;
    }*/

    public void get_item(int item_index)
    {
        if (item_equip[0] == 0)
        {//����������â 1���� �������� ���������
            item_equip[0] = item_index;
        }
        else
        {//������� ������
            if (item_equip[1] == 0)
            {//����������â 2���� ���������ִ��� Ȯ��
                item_equip[1] = item_index;
            }
            else
            {
                if (item_equip[2] == 0)
                {
                    item_equip[2] = item_index;
                }
                else
                {//������� ������
                    if (item_equip[3] == 0)
                    {
                        item_equip[3] = item_index;
                    }
                    else
                    {//������� ������
                        if (item_equip[4] == 0)
                        {
                            item_equip[4] = item_index;
                        }
                        else
                        {//������� ������
                            if (item_equip[5] == 0)
                            {
                                item_equip[5] = item_index;
                            }
                            else
                            {
                                Debug.Log("������â�� ����á���ϴ�.");
                            }
                        }
                    }
                }
            }
        }
    }
    public void sell_item_player(int idx)
    {
        if (item_equip[0] == idx)
        {
            item_equip[0] = 0;
            item_icon.GetComponent<player_item_icon_set>().sell_item_icon(0);
        }
        else
        {
            if (item_equip[1] == idx)
            {
                item_equip[1] = 0;
                item_icon.GetComponent<player_item_icon_set>().sell_item_icon(1);
            }
            else
            {
                if (item_equip[2] == idx)
                {
                    item_equip[2] = 0;
                    item_icon.GetComponent<player_item_icon_set>().sell_item_icon(2);
                }
                else
                {
                    if (item_equip[3] == idx)
                    {
                        item_equip[3] = 0;
                        item_icon.GetComponent<player_item_icon_set>().sell_item_icon(3);
                    }
                    else
                    {
                        if (item_equip[4] == idx)
                        {
                            item_equip[4] = 0;
                            item_icon.GetComponent<player_item_icon_set>().sell_item_icon(4);
                        }
                        else
                        {
                            if (item_equip[5] == idx)
                            {
                                item_equip[5] = 0;
                                item_icon.GetComponent<player_item_icon_set>().sell_item_icon(5);
                            }
                        }
                    }
                }
            }
        }
    }
    void Update()
    {
        //�ӵ�����ȭ
        agent.speed = spd;//�ְ�ӷ�
        agent.acceleration = spd; //���ӵ�
        if (hp <= 0) //ü���� 0���ϸ� ����
        {
            Destroy(this.gameObject);
        }
        gold = gold + Time.deltaTime * 10;
        gamemanger.GetComponent<player_set>().shop.GetComponent<shop>().got_gold.text = "������ : " + gold;

    }
}