using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Object/��ų/��߽�ų", order = 0)]

public class Skill_Burst : SkillData
{
    public enum AtciveType
    {
        none,
        single,
        multy,
        Flooring
    }

    public AtciveType activetype;

    public float Before_Delay;// ��������
    public float After_Delay;//�ĵ�����

    public GameObject Effect;//��ų�� ������ ����Ʈ

    public override void OnUse(Player Player,SkillData data)
    {

        Debug.Log("����Ʈ �������� ȣ��");
    }

}
