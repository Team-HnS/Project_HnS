using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public static QuestGiver instance;
    //public List quest;
    //public CharacterManager character;
    public GameObject[] button;
    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public GameObject[] rewardslot;
    public GameObject progerss;
    public GameObject sucess;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }
    /*
    public void OpenQuestWindow()//npc
    {

        if (quest[CharacterManager.instance.questchapter].Progress == false && quest[CharacterManger.instance.questchapter].isSucess == false)//quest[퀘스트진행도].progress,  issucees 가 false면 수락전 완료전 퀘스트 
        {
            questWindow.SetActive(true);//퀘스트 창 보이게
            for (int i = 0; i < button.Length; i++) //안보일 버튼들 추가해서 버튼들 안보이게
            {
                button[i].SetActive(false);
            }

            titleText.text = quest[CharacterManager.instance.questcapter].title;// 제목 = qeust[진행도].제목
            for (int i = 0; i().sprite = GameManager.instance.ItemSprite[GameManager.instance.Alltem.FindIndex
                        (x => x.Name == quest[CharacterManger.instance.questchapter].Rewarditems[j].Name)];)//보상이템과 이름이같은 스프라이트 설정 
                    if (rewardslot[j].transform.GetChild(1).GetComponent().sprite.name != "NONE")//none이 아닐때 활성화 
                {
                    rewardslot[j].SetActive(true);
                }
        }
    }
            else if(quest[CharacterManger.instance.questchapter]).Progress==true&&quest[CharacterManger.instance.questchapter].isSucess==false)//qeust가 진행중일때 버튼을 진행중으로 보이게 
            {
                progerss.SetActive(true);
           
            questWindow.SetActive(true);
            for (int i = 0; i();.sprite = GameManger.instance.ItemSprite[GameManger.instance.Alltem.FindIndex
                    (x => x.Name == quest[CharacterManger.instance.questchapter].Rewarditems[j].Name)];
                if (rewardslot[j]).transform.GetChild(1).GetComponent().sprite.name != "NONE")
                {
                    rewardslot[j].SetActive(true);
}
            }
        }
            else if (quest[CharacterManger.instance.questchapter].Progress == true && quest[CharacterManger.instance.questchapter].isSucess == true)//퀘스트가 진행중인데 성공했을때 버튼이 완료로 보이게 설정
{
    questWindow.SetActive(true);
    for (int i = 0; i().text = "완료";

        }
            
        }

    public void Sucess()//퀘스트 완료후 보상받을때 
    {
        questWindow.SetActive(false);
        for (int i = 0; i < rewardslot.Length; i++) 
        {
            Item item = GameManager.instance.AllItem.Find(x=> x.Name == quest[CharacterManger.instance.questchapter].Rewarditems[i].Name);//allitem에서 이름이같은 아이템을 찾아서 item에 넣고
        }
        
        GameManger.instance.MyItemList.Add(item);//그 아이템을 myitemlist에 추가 
    }

        CharacterManger.instance.questchapter += 1;//퀘스트 진행도 1 증가 
   } */
    
}