using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Object/��ų", order = 0)]

public class SkillData : ScriptableObject
{
    public enum Type
    {
        none,
        passive,
        active,
        buff
    }

    public enum TargetType
    {
        none,
        single,
        multy,
        Flooring
    }

    public Type skilltype;

    public TargetType activetype;
    public Sprite skill_Icon;
    public string SkillName;
    public int SkillCode;

    public int SkillLV;
    public float SkillCoolDown;
    public float Effect_maintenance_time;
    public bool ChangeRot;

    public bool isrange = false;
    public float skill_range;
    public float Tick_time;
    public List<int> hitcount;
    public List<int> ManaRequirement;
    public List<float> Coefficient;
    public List<float> Add_Coefficient;


    public AudioClip SkillSound;// ������
    public AnimationClip SkillMotion;//��ų���

    [TextArea]
    public string Skill_Explanation;

    public UnityEvent SkillEvent;

    public float Before_Delay;// ��������
    public float After_Delay;//�ĵ�����

    public GameObject Effect;//��ų�� ������ ����Ʈ

    public GameObject HitEffect;//������ ������ ������ ����Ʈ

}
