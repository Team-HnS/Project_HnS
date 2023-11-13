using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputManager : MonoBehaviour
{
    public static KeyInputManager instance;

    [HideInInspector]
    public SkillSlotPannel ssp;
    [HideInInspector]
    public SkillSlot ResentCheckSkill;
    private void Awake()
    {
        instance = this;
        ssp = FindObjectOfType<SkillSlotPannel>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ResentCheckSkill = ssp.skillSlots[0];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[0]._skillData;
            ssp.skillSlots[0]._skillData.SkillEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ResentCheckSkill = ssp.skillSlots[1];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[1]._skillData;
            ssp.skillSlots[1]._skillData.SkillEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ResentCheckSkill = ssp.skillSlots[2];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[2]._skillData;
            ssp.skillSlots[2]._skillData.SkillEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResentCheckSkill = ssp.skillSlots[3];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[3]._skillData;
            ssp.skillSlots[3]._skillData.SkillEvent.Invoke();
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            ResentCheckSkill = ssp.skillSlots[7];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[7]._skillData;
            ssp.skillSlots[7]._skillData.SkillEvent.Invoke();
        }
    }
}
