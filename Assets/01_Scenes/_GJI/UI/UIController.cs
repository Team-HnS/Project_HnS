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
        setting,        //���� UIâ
        restart,        //������ �ʱ�ȭ?
        ending,
        no_item,
        todayFinished,
        quest,
        questPopup,
        None
    }
    public void AllUIoff()
    {
        // ��� UI�� ��Ȱ��ȭ�մϴ�.
        for (int i = 0; i < UIs.Length; i++)
        {
            UIs[i].gameObject.SetActive(false);
        }
        // ���� ���¸� None���� �����մϴ�.
        currentState = UIstate.None;
    }

    // UI�� Ȱ��ȭ�ϴ� �ڵ�� ����Ʈ
    public IEnumerator UI_On(UIstate uistate, bool AutoUIOff = false, float seconds = 2f)
    {
        // ��� UI�� �ϴ� ��Ȱ��ȭ�մϴ�.
        AllUIoff();

        // ���� ���¸� ������ UI ���·� �����մϴ�.
        currentState = uistate;

        // ��� ����մϴ�.
        yield return new WaitForSeconds(0.1f);

        // UI ���� ������ UI�� Ȱ��ȭ�մϴ�.
        UIs[(int)UIstate.UIbackground].gameObject.SetActive(true);
        UIs[(int)uistate].gameObject.SetActive(true);

        // UI�� Ȯ���ϴ� �ִϸ��̼� ȿ���� �ݴϴ�.
        for (int i = 0; i < 5; i++)
        {
            // UI�� ũ�⸦ �����մϴ�.
            UIs[(int)uistate].rectTransform.localScale = new Vector3((float)(0.95 + i * 0.01), (float)(0.95 + i * 0.01), (float)(0.95 + i * 0.01));
            yield return 0;
        }

        // AutoUIOff �ɼ��� true�� ���
        if (AutoUIOff)
        {
            // ������ �ð�(seconds)��ŭ ����մϴ�.
            yield return new WaitForSeconds(seconds);

            // UI�� ��Ȱ��ȭ�մϴ�.
            UIoff(uistate); // �ּ� ó���� �κ��� Ȱ��ȭ�ϸ� �ش� UI�� �ٽ� ��Ȱ��ȭ�� ���Դϴ�.
        }

        
    }

    public void UIoff(UIstate index)
    {
        UIs[(int)index].gameObject.SetActive(false);
        // ���⼱ current UI State�� ��� �����ؾ�����...?
    }

}
