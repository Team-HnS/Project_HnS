using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : ScriptableObject
{
    public enum Type
    {
        none,
        passive,
        active,
        buff
    }

    public Type skilltype;

    public string SkillName;
    public int SkillCode;

    [TextArea]
    public string Skill_Explanation;

}
