using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillSet_Library : MonoBehaviour
{
   
    public static SkillSet_Library instance;

    public GameObject player;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<Player>().gameObject;
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
}
