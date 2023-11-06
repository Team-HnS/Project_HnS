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
        talkData.Add(1000, new string[] { "안녕", "이 곳에 처음 왔구나?","마을 밖은 몬스터들이 우글거려 위험해" });
        //id = 1001 : 잡화상인
        talkData.Add(1001, new string[] { "안녕 여행자?", "무엇을 사고 싶어?" });
        //id = 1002 : 장비npc
        talkData.Add(1002, new string[] { "강해지고싶나. \n그럼 이것들을 구매해라" });
        //id = 1003 : 퀘스트npc
        talkData.Add(1003, new string[] { "도움이 필요해. \n가능한 빨리 해결해줬으면 하는데" });
    }

    public string GetTalk(int id, int talkIndex) //Object의 id , string배열의 index
    {
        if (talkIndex == talkData[id].Length) //해당 id를 가지는 string배열의 길이와 같음 
            return null;
        else
            return talkData[id][talkIndex]; //해당 아이디의 해당하는 대사를 반환 
    }
}