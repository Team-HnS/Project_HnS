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

        if (quest[CharacterManager.instance.questchapter].Progress == false && quest[CharacterManger.instance.questchapter].isSucess == false)//quest[����Ʈ���൵].progress,  issucees �� false�� ������ �Ϸ��� ����Ʈ 
        {
            questWindow.SetActive(true);//����Ʈ â ���̰�
            for (int i = 0; i < button.Length; i++) //�Ⱥ��� ��ư�� �߰��ؼ� ��ư�� �Ⱥ��̰�
            {
                button[i].SetActive(false);
            }

            titleText.text = quest[CharacterManager.instance.questcapter].title;// ���� = qeust[���൵].����
            for (int i = 0; i().sprite = GameManager.instance.ItemSprite[GameManager.instance.Alltem.FindIndex
                        (x => x.Name == quest[CharacterManger.instance.questchapter].Rewarditems[j].Name)];)//�������۰� �̸��̰��� ��������Ʈ ���� 
                    if (rewardslot[j].transform.GetChild(1).GetComponent().sprite.name != "NONE")//none�� �ƴҶ� Ȱ��ȭ 
                {
                    rewardslot[j].SetActive(true);
                }
        }
    }
            else if(quest[CharacterManger.instance.questchapter]).Progress==true&&quest[CharacterManger.instance.questchapter].isSucess==false)//qeust�� �������϶� ��ư�� ���������� ���̰� 
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
            else if (quest[CharacterManger.instance.questchapter].Progress == true && quest[CharacterManger.instance.questchapter].isSucess == true)//����Ʈ�� �������ε� ���������� ��ư�� �Ϸ�� ���̰� ����
{
    questWindow.SetActive(true);
    for (int i = 0; i().text = "�Ϸ�";

        }
            
        }

    public void Sucess()//����Ʈ �Ϸ��� ��������� 
    {
        questWindow.SetActive(false);
        for (int i = 0; i < rewardslot.Length; i++) 
        {
            Item item = GameManager.instance.AllItem.Find(x=> x.Name == quest[CharacterManger.instance.questchapter].Rewarditems[i].Name);//allitem���� �̸��̰��� �������� ã�Ƽ� item�� �ְ�
        }
        
        GameManger.instance.MyItemList.Add(item);//�� �������� myitemlist�� �߰� 
    }

        CharacterManger.instance.questchapter += 1;//����Ʈ ���൵ 1 ���� 
   } */
    
}