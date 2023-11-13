using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public string questName; // 퀘스트의 이름을 저장하는 변수
    public int[] NpdId; // 퀘스트에서 필요한 NPC의 ID를 저장하는 배열

    public QuestData()
    {
        // 기본 생성자
        // 아무 동작도 수행하지 않음
    }

    public QuestData(string name, int[] npcid)
    {
        // 매개변수를 사용하는 생성자
        questName = name; // 주어진 이름을 questName 변수에 저장
        NpdId = npcid; // 주어진 NPC ID 배열을 NpdId 변수에 저장
    }
}
