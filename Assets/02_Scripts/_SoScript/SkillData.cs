using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Object/스킬", order = 0)]

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


    public AudioClip SkillSound;// 시전음
    public AnimationClip SkillMotion;//스킬모션

    [TextArea]
    public string Skill_Explanation;

    public UnityEvent SkillEvent;

    public float Before_Delay;// 선딜레이
    public float After_Delay;//후딜레이

    public GameObject Effect;//스킬에 생성할 이펙트

    public GameObject HitEffect;//데미지 맞을때 생성할 이펙트

}
