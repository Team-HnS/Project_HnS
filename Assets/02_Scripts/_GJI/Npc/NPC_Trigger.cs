using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Trigger : MonoBehaviour
{
    // 플레이어가 트리거 영역에 진입했을 때 표시할 텍스트
    public string ChatText = "";

    // MainScript 게임 오브젝트에 대한 참조
    private GameObject Main;

    void Start()
    {
        // 스크립트가 시작될 때 "Main"이라는 이름의 게임 오브젝트를 찾아서 참조 저장
        Main = GameObject.Find("Main");
    }

    private void OnTriggerEnter(Collider other)
    {
        // 진입한 오브젝트가 "Player" 태그를 가지고 있는지 확인
        if (other.tag == "Player")
        {
            // MainScript에서 NPCChatEnter 메서드 호출하고 ChatText 전달
            Main.GetComponent<MainScript>().NPCChatEnter(ChatText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 나가는 오브젝트가 "Player" 태그를 가지고 있는지 확인
        if (other.tag == "Player")
        {
            // MainScript에서 NPCChatExit 메서드 호출
            Main.GetComponent<MainScript>().NPCChatExit();
        }
    }
}
