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
        talkData.Add(1000, new string[] { "�ȳ�", "�� ���� ó�� �Ա���?","���� ���� ���͵��� ��۰ŷ� ������" });
        //id = 1001 : ��ȭ����
        talkData.Add(1001, new string[] { "�ȳ� ������?", "������ ��� �;�?" });
        //id = 1002 : ���npc
        talkData.Add(1002, new string[] { "��������ͳ�. \n�׷� �̰͵��� �����ض�" });
        //id = 1003 : ����Ʈnpc
        talkData.Add(1003, new string[] { "������ �ʿ���. \n������ ���� �ذ��������� �ϴµ�" });
    }

    public string GetTalk(int id, int talkIndex) //Object�� id , string�迭�� index
    {
        if (talkIndex == talkData[id].Length) //�ش� id�� ������ string�迭�� ���̿� ���� 
            return null;
        else
            return talkData[id][talkIndex]; //�ش� ���̵��� �ش��ϴ� ��縦 ��ȯ 
    }
}