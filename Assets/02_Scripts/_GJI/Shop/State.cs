using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public GameObject gamemanger;
    #region 체력관련 변수
    public float hp; public float maxHp;
    public float mp; public float maxMp;
    #endregion
    #region 공격관련 변수
    public float atk; public float atk_speed; public float atk_range;
    #endregion
    #region 방어관련 변수
    public float def;
    #endregion
    #region 이동관련 변수
    public float spd;
    #endregion
    #region 팀관련 변수
    public float team;
    #endregion
    #region 골드관련 변수
    public float gold; public float kill_gold;
    #endregion
    #region 오브젝트관련 변수
    public NavMeshAgent agent;
    #endregion

    #region 아이템관련 변수
    public int[] item_equip;
    #endregion

    public Image item_icon;

    void Start()
    {
       
        //item_equip = new int[6];//6개의 아이템장착창을 만듬

    }
  
    /*public void get_gold(float got_gold)//처치한 상대의 kill_gold값을 받아서 골드를 얻음
    {
        gold += got_gold;
    }*/

    public void get_item(int item_index)
    {
        if (item_equip[0] == 0)
        {//아이템장착창 1번에 아이템이 비어있으면
            item_equip[0] = item_index;
        }
        else
        {//비어있지 않으면
            if (item_equip[1] == 0)
            {//아이템장착창 2번에 아이템이있는지 확인
                item_equip[1] = item_index;
            }
            else
            {
                if (item_equip[2] == 0)
                {
                    item_equip[2] = item_index;
                }
                else
                {//비어있지 않으면
                    if (item_equip[3] == 0)
                    {
                        item_equip[3] = item_index;
                    }
                    else
                    {//비어있지 않으면
                        if (item_equip[4] == 0)
                        {
                            item_equip[4] = item_index;
                        }
                        else
                        {//비어있지 않으면
                            if (item_equip[5] == 0)
                            {
                                item_equip[5] = item_index;
                            }
                            else
                            {
                                Debug.Log("아이템창이 가득찼습니다.");
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
        //속도동기화
        agent.speed = spd;//최고속력
        agent.acceleration = spd; //가속도
        if (hp <= 0) //체력이 0이하면 죽음
        {
            Destroy(this.gameObject);
        }
        gold = gold + Time.deltaTime * 10;
        gamemanger.GetComponent<player_set>().shop.GetComponent<shop>().got_gold.text = "소지금 : " + gold;

    }
}