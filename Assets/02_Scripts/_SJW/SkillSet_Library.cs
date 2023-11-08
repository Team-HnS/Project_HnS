using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillSet_Library : MonoBehaviour
{
   
    public static SkillSet_Library instance;

    public GameObject player;
    public Player player_s;
    public PlayerMovement player_m;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<Player>().gameObject;
        player_s = player.GetComponent<Player>();
        player_m = player.GetComponent<PlayerMovement>();
    }

    int SkillDamageSet(int Damage, float Coefficient)
    {
        print("플레이어공격력 = " + instance.player_s.Atk);

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
        //instance.player_m.canMove = false;

        GameObject effect = Instantiate(s_data.Effect,instance.player.transform.position,instance.player_m.playerCharacter.rotation, instance.player.transform);
        SkillCollider skillCollider = effect.GetComponentInChildren<SkillCollider>();
        print("계수 = " + s_data.Coefficient[0]);
        print("예상 데미지 = " + SkillDamageSet(instance.player_s.Atk, s_data.Coefficient[0]));
        skillCollider.damage = SkillDamageSet(instance.player_s.Atk, s_data.Coefficient[0]);
        instance.player_s.PlayerCasting(s_data.After_Delay);
        Destroy(effect,0.5f);
    }


}
