using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager; // 대화 관리를 위한 TalkManager 스크립트
    public int talkIndex; // 대화 인덱스
    private bool isAction; // 대화 중 여부를 나타내는 플래그
    private GameObject scanObject; // 상호 작용할 대상
    public GameObject talkPanel; // 대화 패널(GameObject)을 참조하기 위한 변수
    public Text UITalkText; // 대화 내용을 표시할 UI Text 컴포넌트

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj; // 상호 작용할 대상을 저장
        ObjData objData = scanObject.GetComponent<ObjData>(); // 대상의 정보를 가져옴
        Talk(objData.id, objData.isNPC); // 대화를 시작

        talkPanel.SetActive(isAction); // 대화 패널을 활성화/비활성화
    }

    // 대화를 처리하는 메서드
    void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex); // TalkManager를 통해 대화 내용 가져오기

        if (talkData == null)
        {
            isAction = false; // 대화가 더 이상 없으므로 대화 중 상태를 해제
            talkIndex = 0; // 대화 인덱스 초기화
            return; // 이후 코드 실행 중단
        }

        // 대화 내용을 UI Text에 표시
        UITalkText.text = talkData;

        isAction = true; // 대화가 남아있으므로 계속 진행
        talkIndex++; // 다음 대화 인덱스로 이동
    }
}
