using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputManager : MonoBehaviour
{
    public static KeyInputManager instance = null;

    //[HideInInspector]
    public SkillSlotPannel ssp;
    [HideInInspector]
    public SkillSlot ResentCheckSkill;
    private void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;
            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
        
    }

    private void Start()
    {
        ssp = MainCanvasManager.Instance.SkillSlotPannel.GetComponent<SkillSlotPannel>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (ssp.skillSlots[0]._skillData == null) 
            {
                return;
            }
            ResentCheckSkill = ssp.skillSlots[0];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[0]._skillData;
            ssp.skillSlots[0]._skillData.SkillEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (ssp.skillSlots[1]._skillData == null)
            {
                return;
            }
            ResentCheckSkill = ssp.skillSlots[1];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[1]._skillData;
            ssp.skillSlots[1]._skillData.SkillEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ssp.skillSlots[2]._skillData == null)
            {
                return;
            }
            ResentCheckSkill = ssp.skillSlots[2];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[2]._skillData;
            ssp.skillSlots[2]._skillData.SkillEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ssp.skillSlots[3]._skillData == null)
            {
                return;
            }
            ResentCheckSkill = ssp.skillSlots[3];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[3]._skillData;
            ssp.skillSlots[3]._skillData.SkillEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (ssp.skillSlots[4]._skillData == null)
            {
                return;
            }
            ResentCheckSkill = ssp.skillSlots[4];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[4]._skillData;
            ssp.skillSlots[4]._skillData.SkillEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (ssp.skillSlots[5]._skillData == null)
            {
                return;
            }
            ResentCheckSkill = ssp.skillSlots[5];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[5]._skillData;
            ssp.skillSlots[5]._skillData.SkillEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (ssp.skillSlots[6]._skillData == null)
            {
                return;
            }
            ResentCheckSkill = ssp.skillSlots[6];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[6]._skillData;
            ssp.skillSlots[6]._skillData.SkillEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ssp.skillSlots[7]._skillData == null)
            {
                return;
            }
            ResentCheckSkill = ssp.skillSlots[7];
            PlayerManager.instance.player_s.Resent_Skill = ssp.skillSlots[7]._skillData;
            ssp.skillSlots[7]._skillData.SkillEvent.Invoke();
        }
    }
}
