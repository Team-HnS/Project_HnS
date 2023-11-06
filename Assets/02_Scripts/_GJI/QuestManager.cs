using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId; // ���� ���� ���� ����Ʈ�� ID
    Dictionary<int, QuestData> questList; // ����Ʈ �����͸� �����ϴ� Dictionary
    public int questActionIndex; //����Ʈ npc��ȭ ����
    public GameObject[] questObject;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>(); // ����Ʈ �����͸� ������ Dictionary �ʱ�ȭ
        GenerateData(); // ����Ʈ �����͸� �����ϴ� �޼��� ȣ��
    }

    void GenerateData()
    {
        // ����Ʈ �����͸� �����ϰ� Dictionary�� �߰�
        // �����ڸ� ����Ͽ� QuestData ��ü�� ����� ID 10�� �߰��մϴ�.
        questList.Add(10, new QuestData("000�� ���ؿͶ�", new int[] { 1003, 1001/*����Ʈ ������� ���� ��ȣ�ۿ��ؾ��ϴ� npc ����*/ }));
        //���� ����� �ʿ�� Ȱ��ȭ

        //����Ʈ�� 10���� �̹Ƿ� ���� ����Ʈ�� 20������ ����
        questList.Add(20, new QuestData("00 ã��", new int[] { 1002 , /*ã�ƿ;��ϴ� ������Ʈ id����*/ }));
    }

    public int GetQuestTalkIndex(int id) // Npc Id�� �޾� ����Ʈ ��ȣ�� ��ȯ�ϴ� �Լ� 
    {
        return questId;
    }
    //����Ʈ�� ��ȭ���� obj id + quest id + questIndex�� ��ȣ�� ����

    public string CheckQuest() //�����ε� 
    {
        //return Quest Name
        return questList[questId].questName;
    }

    public string CheckQuest(int id)
    {
        //�ش� ����Ʈ�� ���� ���� ��
        if (id == questList[questId].NpdId[questActionIndex])
            // questList���� questId�� �ش��ϴ� ����Ʈ���� , 
            //�� ����Ʈ�� �����ϴ� npc�� ������ȣ(questActionIndex)�� �Է¹��� npc id�� ���� ��� -> ����Ʈ ���� ��
            questActionIndex++;

        //Control Quest Object
        ControlObject();

        //����Ʈ�� ����Ǿ��� ��
        if (questActionIndex == questList[questId].NpdId.Length)
            //����Ʈ ����Ʈ�� �ִ� NpcId(����Ʈ�� �����ϴ� npc) ���� ���� �� -> ����Ʈ ����
            NextQuest();

        //return Quest Name
        return questList[questId].questName;
    }
    void NextQuest()// ���� ����Ʈ�� �Ѿ���� �ϴ� �Լ�
    {
        questId += 10;
        questActionIndex = 0;

    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2) //10�� ����Ʈ�� ����ġ�� ������Ʈ ����
                    questObject[0].SetActive(true);
                break;

            case 20:
                if (questActionIndex == 1)//20�� ����Ʈ���� 1��° ������ ������ -> ����Ʈ �ذῡ �ʿ��� ������Ʈ ����� ����� 
                    questObject[0].SetActive(false);
                break;
        }
    }
}
