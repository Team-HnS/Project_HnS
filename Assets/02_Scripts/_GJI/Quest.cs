using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public bool isSucess; // ��������
    public bool Progress; // ������ ����
    public int questid; // ����Ʈid

    public string goal; //����Ʈ ����
    public string title; //����Ʈ ����
    public string description; //����Ʈ ����
    //public List<Item> Rewarditems; //���� ������
    //public UnitCode UnitCode; //���� ���͸� ��ƾ��ϴ��� ����
    //public QuestGoal QuestGoal // ����Ʈ Ÿ��, ��ƾ��ϴ� ���ͼ�, ���� ���� ���� ��, Ŭ���� npc id
}
   
