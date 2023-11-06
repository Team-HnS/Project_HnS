using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId; // 현재 진행 중인 퀘스트의 ID
    Dictionary<int, QuestData> questList; // 퀘스트 데이터를 저장하는 Dictionary
    public int questActionIndex; //퀘스트 npc대화 순서
    public GameObject[] questObject;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>(); // 퀘스트 데이터를 저장할 Dictionary 초기화
        GenerateData(); // 퀘스트 데이터를 생성하는 메서드 호출
    }

    void GenerateData()
    {
        // 퀘스트 데이터를 생성하고 Dictionary에 추가
        // 생성자를 사용하여 QuestData 객체를 만들고 ID 10에 추가합니다.
        questList.Add(10, new QuestData("000을 구해와라", new int[] { 1003, 1001/*퀘스트 진행순서 별로 상호작용해야하는 npc 순서*/ }));
        //위의 기능은 필요시 활성화

        //퀘스트는 10단위 이므로 다음 퀘스트는 20번으로 설정
        questList.Add(20, new QuestData("00 찾기", new int[] { 1002 , /*찾아와야하는 오브젝트 id삽입*/ }));
    }

    public int GetQuestTalkIndex(int id) // Npc Id를 받아 퀘스트 번호를 반환하는 함수 
    {
        return questId;
    }
    //퀘스트용 대화에는 obj id + quest id + questIndex를 번호로 저장

    public string CheckQuest() //오버로딩 
    {
        //return Quest Name
        return questList[questId].questName;
    }

    public string CheckQuest(int id)
    {
        //해당 퀘스트가 종료 전일 때
        if (id == questList[questId].NpdId[questActionIndex])
            // questList에서 questId에 해당하는 퀘스트에서 , 
            //이 퀘스트에 참여하는 npc의 순서번호(questActionIndex)와 입력받은 npc id가 같은 경우 -> 퀘스트 종료 전
            questActionIndex++;

        //Control Quest Object
        ControlObject();

        //퀘스트가 종료되었을 때
        if (questActionIndex == questList[questId].NpdId.Length)
            //퀘스트 리스트에 있는 NpcId(퀘스트에 참여하는 npc) 수와 같을 때 -> 퀘스트 종료
            NextQuest();

        //return Quest Name
        return questList[questId].questName;
    }
    void NextQuest()// 다음 퀘스트로 넘어가지게 하는 함수
    {
        questId += 10;
        questActionIndex = 0;

    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2) //10번 퀘스트를 끝마치면 오브젝트 등장
                    questObject[0].SetActive(true);
                break;

            case 20:
                if (questActionIndex == 1)//20번 퀘스트에서 1번째 순서가 끝나고 -> 퀘스트 해결에 필요한 오브젝트 습득시 사라짐 
                    questObject[0].SetActive(false);
                break;
        }
    }
}
