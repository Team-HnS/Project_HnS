using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isSucess; // 퀘스트 성공 여부
    public bool Progress; // 퀘스트 진행 중 여부
    public int questid; // 퀘스트 ID

    public string goal; // 퀘스트 목표
    public string title; // 퀘스트 제목
    public string description; // 퀘스트 설명
    public List<Item> Rewarditems; // 보상 아이템 목록
    string UnitCode; // 유닛 코드: 특정 유닛과 연결하여 퀘스트 진행할 때 사용할 수 있음
    //public QuestGoal questGoal; // 퀘스트 목표: 어떤 종류의 목표를 달성해야 하는지 나타냄, NPC ID 등을 사용할 수 있음
}
