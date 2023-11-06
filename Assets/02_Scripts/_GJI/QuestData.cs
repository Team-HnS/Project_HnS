using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public string questName; // ����Ʈ�� �̸��� �����ϴ� ����
    public int[] NpdId; // ����Ʈ�� ���õ� NPC ID�� �����ϴ� �迭

    public QuestData()
    {
        // �⺻ ������
        // �ƹ� ���۵� �������� ����
    }

    public QuestData(string name, int[] npcid)
    {
        // �Ű������� �޴� ������
        questName = name; // �Ű������� ���� �̸��� questName�� ����
        NpdId = npcid; // �Ű������� ���� NPC ID �迭�� NpdId�� ����
    }
}
