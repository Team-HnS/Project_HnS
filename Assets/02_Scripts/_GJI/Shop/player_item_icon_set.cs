using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_item_icon_set : MonoBehaviour //아이템칸에 아이템 이미지만 띄워주는 코드이다.
{
    public GameObject gamemanger;
    public GameObject player;
    public List<Button> item_button;
    private List<item_data> item_data_list;
    void Start()
    {
        item_data_list = gamemanger.GetComponent<item_set>().item_data_list;//item_set에서 item_data_list를 찾아서 item_data_list에 저장

    }
    void Update()
    {
        if (item_button[0].GetComponent<Image>().sprite.name == "UISP")
        { //아이템칸 1번에 아이템이 없으면 UISP = 기본 이미지 
            if (player.GetComponent<Stats>().item_equip[0] != 0)
            { //아이템칸 1번에 아이템이 없으면
                item_button[0].GetComponent<Image>().sprite = Resources.Load<Sprite>(item_data_list[player.GetComponent<Stats>().item_equip[0] - 1].Item_name);
                //아이템1번칸의 IDX값을 토대로 item의 이름을 통해 스프라이트를 설정해줍니다.
            }
        }
        else
        {//아이템칸 1번에 아이템이 있으면
            if (item_button[1].GetComponent<Image>().sprite.name == "UISP")
            {//다음칸도 똑같이 실행
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