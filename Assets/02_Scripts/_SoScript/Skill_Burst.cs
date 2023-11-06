using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Object/스킬/즉발스킬", order = 0)]

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

    public float Before_Delay;// 선딜레이
    public float After_Delay;//후딜레이

    public GameObject Effect;//스킬에 생성할 이펙트

    public override void OnUse(Player Player,SkillData data)
    {

        Debug.Log("버스트 온유스드 호출");
    }

}
