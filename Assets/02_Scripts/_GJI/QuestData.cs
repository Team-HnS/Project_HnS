using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public string questName; // 퀘스트의 이름을 저장하는 변수
    public int[] NpdId; // 퀘스트와 관련된 NPC ID를 저장하는 배열

    public QuestData()
    {
        // 기본 생성자
        // 아무 동작도 수행하지 않음
    }

    public QuestData(string name, int[] npcid)
    {
        // 매개변수를 받는 생성자
        questName = name; // 매개변수로 받은 이름을 questName에 설정
        NpdId = npcid; // 매개변수로 받은 NPC ID 배열을 NpdId에 설정
    }
}
