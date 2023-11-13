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
        //id = 1000 : 초반 대화 npc
        talkData.Add(1000, new string[] { "안녕", "이 곳에 처음 왔구나?", "마을 밖은 몬스터들이 우글거려 위험해" });
        //id = 1001 : 잡화상인
        talkData.Add(1001, new string[] { "안녕 여행자?", "무엇을 사고 싶어?" });
        //id = 1002 : 장비npc
        talkData.Add(1002, new string[] { "강해지고싶나. \n그럼 이것들을 구매해라" });
        //id = 1003 : 퀘스트npc
        talkData.Add(1003, new string[] { "도움이 필요해. \n가능한 빨리 해결해줬으면 하는데" });

        //퀘스트용 대화(obj id + quest id)
        talkData.Add(1003/*퀘스트npc*/ + 10, new string[] { "저기요! \n저 좀 도와주세요:0" });
        talkData.Add(1001/*잡화상인npc*/ + 10, new string[] { "안녕:1" });
    }

    public string GetTalk(int id, int talkIndex) //Object의 id , string배열의 index
    {
        //1. 해당 퀘스트 id에서 퀘스트index(순서)에 해당하는 대사가 없음
        if (!talkData.ContainsKey(id))
        {

            //해당 퀘스트 자체에 대사가 없을 때 -> 기본 대사를 불러옴 (십, 일의 자리 부분 제거 )
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);//GET FIRST TALK

            //
            else
                return GetTalk(id - id % 10, talkIndex);//GET FIRST QUEST TALK
        }

        //2. 해당 퀘스트 id에서 퀘스트index(순서)에 해당하는 대사가 있음
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex]; //해당 아이디의 해당하는 대사를 가져옴
    }
}