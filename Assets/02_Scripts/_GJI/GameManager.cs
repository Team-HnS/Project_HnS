using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager; // ��ȭ ������ ���� TalkManager ��ũ��Ʈ
    public int talkIndex; // ��ȭ �ε���
    private bool isAction; // ��ȭ �� ���θ� ��Ÿ���� �÷���
    private GameObject scanObject; // ��ȣ �ۿ��� ���
    public GameObject talkPanel; // ��ȭ �г�(GameObject)�� �����ϱ� ���� ����
    public Text UITalkText; // ��ȭ ������ ǥ���� UI Text ������Ʈ

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj; // ��ȣ �ۿ��� ����� ����
        ObjData objData = scanObject.GetComponent<ObjData>(); // ����� ������ ������
        Talk(objData.id, objData.isNPC); // ��ȭ�� ����

        talkPanel.SetActive(isAction); // ��ȭ �г��� Ȱ��ȭ/��Ȱ��ȭ
    }

    // ��ȭ�� ó���ϴ� �޼���
    void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex); // TalkManager�� ���� ��ȭ ���� ��������

        if (talkData == null)
        {
            isAction = false; // ��ȭ�� �� �̻� �����Ƿ� ��ȭ �� ���¸� ����
            talkIndex = 0; // ��ȭ �ε��� �ʱ�ȭ
            return; // ���� �ڵ� ���� �ߴ�
        }

        // ��ȭ ������ UI Text�� ǥ��
        UITalkText.text = talkData;

        isAction = true; // ��ȭ�� ���������Ƿ� ��� ����
        talkIndex++; // ���� ��ȭ �ε����� �̵�
    }
}
