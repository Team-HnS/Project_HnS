using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public bool isSucess; // 성공여부
    public bool Progress; // 진행중 여부
    public int questid; // 퀘스트id

    public string goal; //퀘스트 내용
    public string title; //퀘스트 제목
    public string description; //퀘스트 설명
    //public List<Item> Rewarditems; //보상 아이템
    //public UnitCode UnitCode; //무슨 몬스터를 잡아야하는지 설정
    //public QuestGoal QuestGoal // 퀘스트 타입, 잡아야하는 몬스터수, 현재 잡은 몬스터 수, 클리어 npc id
}
   
