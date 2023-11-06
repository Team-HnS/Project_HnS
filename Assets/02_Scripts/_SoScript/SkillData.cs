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

    public AudioSource SkillSound;// ������
    public AnimationClip SkillMotion;//��ų���

    [TextArea]
    public string Skill_Explanation;


    public virtual void OnUse()
    {
      
    }

    public virtual void OnUse(Player Player, SkillData data)
    {

          Debug.Log("������ �������� ȣ��");
    }

}
