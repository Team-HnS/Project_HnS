using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image[] UIs;
    public static UIstate currentState = UIstate.None;

    public enum UIstate
    {
        UIbackground,   
        setting,        //설정 UI창
        restart,        //게임을 초기화?
        ending,
        no_item,
        todayFinished,
        quest,
        questPopup,
        None
    }
    public void AllUIoff()
    {
        // 모든 UI를 비활성화합니다.
        for (int i = 0; i < UIs.Length; i++)
        {
            UIs[i].gameObject.SetActive(false);
        }
        // 현재 상태를 None으로 설정합니다.
        currentState = UIstate.None;
    }

    // UI를 활성화하는 코드와 이펙트
    public IEnumerator UI_On(UIstate uistate, bool AutoUIOff = false, float seconds = 2f)
    {
        // 모든 UI를 일단 비활성화합니다.
        AllUIoff();

        // 현재 상태를 지정된 UI 상태로 설정합니다.
        currentState = uistate;

        // 잠시 대기합니다.
        yield return new WaitForSeconds(0.1f);

        // UI 배경과 지정된 UI를 활성화합니다.
        UIs[(int)UIstate.UIbackground].gameObject.SetActive(true);
        UIs[(int)uistate].gameObject.SetActive(true);

        // UI를 확대하는 애니메이션 효과를 줍니다.
        for (int i = 0; i < 5; i++)
        {
            // UI의 크기를 조정합니다.
            UIs[(int)uistate].rectTransform.localScale = new Vector3((float)(0.95 + i * 0.01), (float)(0.95 + i * 0.01), (float)(0.95 + i * 0.01));
            yield return 0;
        }

        // AutoUIOff 옵션이 true인 경우
        if (AutoUIOff)
        {
            // 지정된 시간(seconds)만큼 대기합니다.
            yield return new WaitForSeconds(seconds);

            // UI를 비활성화합니다.
            UIoff(uistate); // 주석 처리된 부분을 활성화하면 해당 UI를 다시 비활성화할 것입니다.
        }

        
    }

    public void UIoff(UIstate index)
    {
        UIs[(int)index].gameObject.SetActive(false);
        // 여기선 current UI State를 어떻게 지정해야할지...?
    }

}
