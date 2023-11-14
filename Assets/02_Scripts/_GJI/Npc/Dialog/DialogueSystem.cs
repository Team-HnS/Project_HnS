using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    // 대화 내용을 표시할 텍스트 필드
    [SerializeField] Text DialogText;

    // 캐릭터 이름을 표시할 텍스트 필드
    [SerializeField] Text NpcnameText;

    // 현재 진행 중인 대화 컨테이너
    DialogueContainer currentDialogue;

    // 현재 텍스트 라인의 인덱스
    int currentTextLine;

    // 매 프레임마다 실행되는 업데이트 메서드
    private void Update()
    {
        // 마우스 왼쪽 버튼을 클릭했을 때 텍스트를 전환하는 메서드 호출
        if (Input.GetMouseButtonDown(0))
        {
            PushText();
        }
    }

    // 다음 텍스트를 표시하는 메서드
    private void PushText()
    {
        // 다음 텍스트 라인으로 이동
        currentTextLine += 1;

        /*// 현재 텍스트 라인이 대화의 끝에 도달했는지 확인
        if (currentTextLine >= currentDialogue.line.Count)
        {
            // 대화가 끝났을 경우 마무리 메서드 호출
            Conclude();
        }
        if (currentTextLine >= currentDialogue.line.Count)
        {
            // 다음 텍스트 표시
            DialogText.text = currentDialogue.line[currentTextLine];
        }*/
    }

    // 대화 시스템 초기화 메서드
    public void Initialize(DialogueContainer dialogueContainer)
    {
        // 대화 시스템 활성화
        Show(true);

        // 현재 대화 설정
        currentDialogue = dialogueContainer;

        // 텍스트 라인 초기화
        currentTextLine = 0;

        // 첫 번째 텍스트 표시
        DialogText.text = currentDialogue.line[currentTextLine];
    }

    // 대화 시스템 활성화/비활성화 메서드
    private void Show(bool v)
    {
        gameObject.SetActive(v);
    }

    // 대화가 끝났을 때 호출되는 메서드
    private void Conclude()
    {
        // 대화 시스템 비활성화
        Show(false);

        // 디버그 로그 출력
        Debug.Log("Dialogue test // Stickcode post ");
    }
}
