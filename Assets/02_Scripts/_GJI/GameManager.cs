using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //public PlayerMovement player;//Player 스크립트
    public GameObject player;
    public TalkManager talkManager; // 대화 관리를 위한 TalkManager 스크립트
    public int talkIndex; // 대화 인덱스
    private bool isAction; // 대화 중 여부를 나타내는 플래그
    private GameObject scanObject; // 상호 작용할 대상
    public GameObject talkPanel; // 대화 패널(GameObject)을 참조하기 위한 변수
    public Text UITalkText; // 대화 내용을 표시할 UI Text 컴포넌트
    public DialogueSystem dialogueSystem;// 대화 관리를 위한

    //퀘스트
    public QuestManager questManager;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    

    void PlayerReposition()
    {

        //player.VelocityZero(); // 플레이어의 속도를 0으로 설정하여 멈춤(추후 필요하면 활성화)
        player.transform.position = new Vector3(-12, -2, -1); //플레이어의 시작위치로 되돌아오기
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj; // 상호 작용할 대상을 저장
        ObjData objData = scanObject.GetComponent<ObjData>(); // 대상의 정보를 가져옴
        Talk(objData.id, objData.isNPC); // 대화를 시작
        talkPanel.SetActive(isAction); // 대화 패널을 활성화/비활성화
    }

    public void Restart()
    { //재시작이므로 처음부터 다시시작이라 마을로 복귀

        Time.timeScale = 1; //플레이어가 다시 움직일 수 있도록 함 
        SceneManager.LoadScene(0);//마을 씬번호로 추후 수정
    }

    public void PerformAction(GameObject scanObj)
    {
        scanObject = scanObj;// 상호 작용할 대상을 받아옵니다.  
        ObjData objData = scanObject.GetComponent<ObjData>();// 대상의 정보를 가져오기 위해 ObjData 컴포넌트를 사용합니다.
        Talk(objData.id, objData.isNPC);// 대화를 시작합니다.
        talkPanel.SetActive(isAction);// 대화창을 대화 활성화 상태에 따라 활성화 또는 비활성화합니다.
    }

    // 대화를 처리하는 메서드
    void Talk(int id, bool isNPC)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id); // 조사한 obj의 id를 넘겨 퀘스트 id를 반환받음 

        //id에 퀘스트 id를 더하면 -> 해당 id를 가진 오브젝트가 가진 퀘스트의 대화를 반환하게 만들기
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if (talkData == null)//반환된 것이 null이면 더이상 남은 대사가 없으므로 action상태변수를 false로 설정 
        {
            isAction = false; // 대화가 더 이상 없으므로 대화 중 상태를 해제
            talkIndex = 0; // 대화 인덱스 초기화
            questManager.CheckQuest(id); // 퀘스트 인덱스 1증가
            return; // 이후 코드 실행 중단
        }

        // 대화 내용을 UI Text에 표시
        UITalkText.text = talkData;
        isAction = true; // 대화가 남아있으므로 계속 진행
        talkIndex++; // 다음 대화 인덱스로 이동
    }
}