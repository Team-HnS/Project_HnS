using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        //id = 1000 : �ʹ� ��ȭ npc
        talkData.Add(1000, new string[] { "�ȳ�", "�� ���� ó�� �Ա���?", "���� ���� ���͵��� ��۰ŷ� ������" });
        //id = 1001 : ��ȭ����
        talkData.Add(1001, new string[] { "�ȳ� ������?", "������ ��� �;�?" });
        //id = 1002 : ���npc
        talkData.Add(1002, new string[] { "��������ͳ�. \n�׷� �̰͵��� �����ض�" });
        //id = 1003 : ����Ʈnpc
        talkData.Add(1003, new string[] { "������ �ʿ���. \n������ ���� �ذ��������� �ϴµ�" });

        //����Ʈ�� ��ȭ(obj id + quest id)
        talkData.Add(1003/*����Ʈnpc*/ + 10, new string[] { "�����! \n�� �� �����ּ���:0" });
        talkData.Add(1001/*��ȭ����npc*/ + 10, new string[] { "�ȳ�:1" });
    }

    public string GetTalk(int id, int talkIndex) //Object�� id , string�迭�� index
    {
        //1. �ش� ����Ʈ id���� ����Ʈindex(����)�� �ش��ϴ� ��簡 ����
        if (!talkData.ContainsKey(id))
        {

            //�ش� ����Ʈ ��ü�� ��簡 ���� �� -> �⺻ ��縦 �ҷ��� (��, ���� �ڸ� �κ� ���� )
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);//GET FIRST TALK

            //
            else
                return GetTalk(id - id % 10, talkIndex);//GET FIRST QUEST TALK
        }

        //2. �ش� ����Ʈ id���� ����Ʈindex(����)�� �ش��ϴ� ��簡 ����
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex]; //�ش� ���̵��� �ش��ϴ� ��縦 ������
    }
}