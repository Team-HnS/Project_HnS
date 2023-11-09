using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSet_Library : MonoBehaviour
{
   
    public static SkillSet_Library instance;

    public GameObject player;
    public Player player_s;
    public PlayerMovement player_m;

    Dictionary<string, Skill_LibraryData> Skill_CoolDowns = new Dictionary<string, Skill_LibraryData>();

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<Player>().gameObject;
        player_s = player.GetComponent<Player>();
        player_m = player.GetComponent<PlayerMovement>();
    }

    bool SkillCostCheck(int cost) //�����ڽ�Ʈ
    {
        if(instance.player.GetComponent<Player>().Cur_Mp < cost)
        {
            return false;
        }
        else 
        {
            instance.player.GetComponent<Player>().Cur_Mp -= cost;
            return true;
        }
    }

    int SkillDamageSet(int Damage, float Coefficient)
    {
        print("�÷��̾���ݷ� = " + instance.player_s.Atk);

        int result_Damage = (int)((Damage * Coefficient)/100);

        return result_Damage;
    }

    public void SkillTest(GameObject player , GameObject target)
    {

        Debug.Log(player.name + target.name);

    }

    public void SkillTest2(SkillData s_data)
    {
        Debug.Log(instance.player.GetComponent<Player>().Cur_Hp);
       

        Debug.Log(s_data.skilltype);

        Debug.Log(s_data.SkillName);

    }   

    public void Active_Slash(SkillData s_data)
    {
        if (!SkillCostCheck(s_data.ManaRequirement[s_data.SkillLV]))
            return; //���� ������ ���
                    //instance.player_m.canMove = false;
        Debug.Log(name);
        if (!Skill_CoolDowns.ContainsKey(s_data.SkillName)) // ��ų�� ���̺귯���� ������ �߰�
        {
            Skill_LibraryData data = new Skill_LibraryData(s_data);
            Skill_CoolDowns.Add(s_data.SkillName, data);
        }

        Skill_LibraryData c_data = Skill_CoolDowns[s_data.SkillName];

        if (!c_data.CanSkill) //��ų�� üũ
        {
            return; // ��ų ���Ұ����ϸ� ����
        }
        Player _plyaer = instance.player.GetComponent<Player>();
        instance.StartCoroutine(CoolTime(c_data));//���⼭���� ��
        SkillRot(s_data);//�÷��̾� ȸ��

        GameObject effect = Instantiate(s_data.Effect,instance.player.transform.position,instance.player_m.playerCharacter.rotation);
        SkillCollider skillCollider = effect.GetComponentInChildren<SkillCollider>();


        print("��� = " + s_data.Coefficient[0]);
        print("���� ������ = " + SkillDamageSet(instance.player_s.Atk, s_data.Coefficient[0]));
        skillCollider.damage = SkillDamageSet(instance.player_s.Atk, s_data.Coefficient[0]);
        instance.player_s.PlayerCasting(s_data.After_Delay);

        Destroy(effect, s_data.Effect_maintenance_time);


        _plyaer.overrideController = new AnimatorOverrideController(_plyaer.animator.runtimeAnimatorController);
        _plyaer.overrideController["_"] = _plyaer.Resent_Skill.SkillMotion;
        _plyaer.animator.SetFloat("SkillSpeed", 5f);
        _plyaer.animator.runtimeAnimatorController = _plyaer.overrideController;


        _plyaer.animator.CrossFade("Skill_1", 0.05f);
    }



    void SkillRot(SkillData s_data)
    {

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Vector3 hitpos = hit.point;
                hitpos.y = instance.player.transform.position.y;

                instance.player_m.playerCharacter.transform.LookAt(hitpos);
            }
        }
    }

    IEnumerator CoolTime(Skill_LibraryData skill_Data)
    {
        skill_Data.CoolDown = skill_Data.s_data.SkillCoolDown; //��Ÿ�� �� �ʱ�ȭ
        skill_Data.CanSkill = false;
        while (skill_Data.CoolDown >=0) 
        {
            skill_Data.CoolDown -= Time.deltaTime;

            yield return null;
        }
        skill_Data.CanSkill = true;

    }
}

class Skill_LibraryData
{
    public SkillData s_data;
    public float CoolDown =0;
    public bool CanSkill = true;

    public Skill_LibraryData(SkillData data)
    {
        s_data = data;
        CoolDown = data.SkillCoolDown;
        CanSkill = true;
    }
}