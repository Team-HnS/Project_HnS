using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId; // 현재 진행 중인 퀘스트의 ID
    Dictionary<int, QuestData> questList; // 퀘스트 데이터를 저장하는 Dictionary
    public int questActionIndex; // 퀘스트 NPC와의 상호작용 인덱스
    public GameObject[] questObject;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>(); // 퀘스트 데이터를 저장할 Dictionary 초기화
        GenerateData(); // 퀘스트 데이터를 생성하는 함수 호출
    }

    void GenerateData()
    {
        // 퀘스트 데이터를 생성하고 Dictionary에 추가
        questList.Add(10, new QuestData("000", new int[] { 1003, 1001/*퀘스트 진행 중인 NPC의 ID*/ }));
        //퀘스트 진행 중에 표시될 UI를 추가

        //퀘스트가 10번일 경우 20번 퀘스트도 추가
        questList.Add(20, new QuestData("000", new int[] { 1002, /*숙제를 주는 NPC의 id*/ }));
    }

    public int GetQuestTalkIndex(int id) // NPC ID를 받아 해당 퀘스트의 대화 인덱스를 반환하는 함수
    {
        return questId;
    }
    //퀘스트 진행 중에 대화가 끝날 때 obj id + quest id + questIndex를 저장

    public string CheckQuest() //퀘스트 진행 상태를 체크하는 함수
    {
        //현재 진행 중인 퀘스트의 이름 반환
        return questList[questId].questName;
    }

    public string CheckQuest(int id)
    {
        //해당 퀘스트의 진행 상태를 체크
        if (id == questList[questId].NpdId[questActionIndex])
            // questList에서 questId에 해당하는 퀘스트에서 , 
            //현재 진행 중인 퀘스트의 NPC와의 상호작용 인덱스(questActionIndex)에 해당하는 npc id가 입력된 npc id와 같다면 -> 퀘스트 진행
            questActionIndex++;

        //Quest Object 제어
        ControlObject();

        //퀘스트가 완료되었다면
        if (questActionIndex == questList[questId].NpdId.Length)
            //퀘스트의 NPC ID(현재 진행 중인 퀘스트에 등장하는 NPC) 개수만큼의 상호작용이 완료되면 -> 퀘스트 완료
            NextQuest();

        //현재 진행 중인 퀘스트의 이름 반환
        return questList[questId].questName;
    }

    void NextQuest()// 다음 퀘스트로 넘어가는 함수
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2) //10번 퀘스트에서 3번째 상호작용이 일어날 때 -> 퀘스트 진행 중에 나타나는 UI를 활성화
                    questObject[0].SetActive(true);
                break;

            case 20:
                if (questActionIndex == 1)//20번 퀘스트에서 2번째 상호작용이 일어날 때 -> 퀘스트 진행 중에 나타나는 UI를 비활성화
                    questObject[0].SetActive(false);
                break;
        }
    }
}
