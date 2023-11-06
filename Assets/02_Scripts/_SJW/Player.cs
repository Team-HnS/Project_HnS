using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public enum PlayerState
    { 
    Idle,
    Run,
    Trace,
    Dash,
    Casting,
    Attack,
    Skill,
    Death
    }
    public PlayerState state;

    private Camera cam;
    private PlayerMovement playermove;
    private Animator animator;
    private SkinnedMeshAfterImage Afterglow;
    private Collider col;


    public GameObject target;
    public GameObject next_target;
    public bool isNextTarget;
    public bool canDash = true;

    public AnimationClip Testanim;
    public AnimationClip Testanim2;

    [HideInInspector]
    public SkillData Resent_Skill;//지금 사용중인 스킬 데이터

    [SerializeField]
    private int lv; //레벨

    [SerializeField]
    private int exp;//경험치


    [SerializeField]
    private int max_hp;
    [SerializeField]
    private int max_mp;

    [SerializeField]
    private int cur_hp;
    [SerializeField]
    private int cur_mp;


    [SerializeField]
    private int atk;//공격력

    [SerializeField]
    private int str;//힘
    [SerializeField]
    private int igt;//마법공격력
    [SerializeField]
    private int dex;//민첩
    [SerializeField]
    private int def;//방어력

    [SerializeField]
    float attack_speed;//공격속도
    [SerializeField]
    float move_speed;//이동속도

    [SerializeField]
    float attack_Range;//공격범위(사거리)

    public int Lv { get { return lv; } set { lv = value; } }
    public int Exp { get { return exp; } set { exp = value; } }

    public int Max_Hp {  get { return max_hp; } set { max_hp = value; } }
    public int Max_Mp { get { return max_mp; } set { max_mp = value; } }
    public int Cur_Hp { get { return cur_hp; } set { cur_hp = value; } }
    public int Cur_Mp { get { return cur_mp; } set { cur_mp = value; } }


    public int Atk { get { return atk; } set { atk = value; } }
    public int Str { get { return str; } set { str = value; } }
    public int Igt { get { return igt; } set { igt = value; } }
    public int Dex { get { return dex; } set { dex = value; } }
    public int Def { get { return def; } set { def = value; } }

    public float Attack_speed { get { return attack_speed; } set { attack_speed = value; } }
    public float Move_Speed { get { return move_speed; } set { move_speed = value; } }

    public float Attack_Range { get { return attack_Range; } set { attack_Range = value; } }


    // 테스트용 변수들
    public AnimatorOverrideController overrideController;

    public void SetState() 
    {
        Max_Hp = 1000;
        Max_Mp = 1000;
        cur_hp = 50;
        cur_mp = Max_Mp;

        Atk = 10;
        Str = 10;
        Igt = 10;
        Dex = 10;
        Def = 10;

        Attack_speed = 1f;
        Move_Speed = 5f;
        Attack_Range = 1.5f;

    }

    private void Awake()
    {
        isNextTarget = false;
        cam = Camera.main;
        playermove = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();
        Afterglow = GetComponentInChildren<SkinnedMeshAfterImage>();
        SetState();

        col = GetComponent<Collider>();
    }

    private void Start()
    {
        state = PlayerState.Idle;
    }




    void Update()
    {
        if (canDash) 
        {
            Checkcollider();
        }
        
    
            playermove.LookMoveDirection();

        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                playermove.PlayerMove();
            }
        }

        if (Input.GetMouseButtonUp(0)) // 몬스터 클릭시
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                MouseBtnUpCheck();
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && state != Player.PlayerState.Dash)
        {
            PlayerDash();
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
            overrideController["RightHand@Attack01"] = Testanim;
            animator.runtimeAnimatorController = overrideController;

            animator.Play("TestSet");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Resent_Skill = Resources.Load<SkillData>("_스킬/_공격기/SkillData");
            Resent_Skill.SkillEvent.Invoke();

            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
            overrideController["_"] = Resent_Skill.SkillMotion;
            animator.SetFloat("SkillSpeed", 5f);
            animator.runtimeAnimatorController = overrideController;

            animator.Play("Skill_1");

            //-> 각 스킬 종류에 맞는 onuse사용


            /*   if (Resent_Skill is Skill_Burst)
               {
                   Skill_Burst skill1Data = (Skill_Burst)Resent_Skill; // 해당 스킬에 맞게 캐스팅
                                                                       // skill1Data의 변수 및 기능을 사용할 수 있음

                   overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
                   overrideController["_"] = skill1Data.SkillMotion;
                   animator.SetFloat("SkillSpeed", 5f);
                   animator.runtimeAnimatorController = overrideController;
                   //skill1Data.OnUse(this);
                   print(skill1Data.activetype);

                   animator.Play("Skill_1");
               }*/
        }

    }

    private RaycastHit colhit; 

    private void Checkcollider()
    {
        if (Physics.Raycast(transform.position+new Vector3(0,1,0), playermove.playerCharacter.transform.forward, out colhit, 0.5f))
        {
            if(colhit.transform.gameObject.layer == 10)
            {
                playermove.agent.speed = 0;
                Debug.Log("hit point : " + colhit.point + ", distance : " + colhit.distance + ", name : " + colhit.collider.name);
            }
           
            Debug.DrawRay(transform.position + new Vector3(0, 1, 0), playermove.playerCharacter.transform.forward * colhit.distance, Color.red);
        }
        else
        {
            playermove.agent.speed = Move_Speed ;
            Debug.DrawRay(transform.position + new Vector3(0, 1, 0), playermove.playerCharacter.transform.forward * 0.5f, Color.red);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 10)
        {
            Debug.Log("몬스터랑충돌함");
            playermove.agent.velocity = Vector3.zero;
        }
    }

    public void MouseBtnUpCheck()
    {


        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            // print(hit.transform.gameObject.name + "클릭"); 클릭하는거 체크


            if (hit.transform.gameObject.layer == 10) //만약 클릭한게 몬스터였을경우
            {
                if (!playermove.canMove && hit.transform.gameObject != target) // 못움직이면 = 이미 공격 중이면 다음 대기열에 저장
                {
                    isNextTarget = true;
                    next_target = hit.transform.gameObject;

                    playermove.saveMovePos = Vector3.zero;
                    playermove.isSavePos = false;

                    return;
                }
                // 공격중이아니라면
                target = hit.transform.gameObject;
                print(hit.transform.gameObject.name + "몬스터 클릭함!");
                playermove.PlayerTargetMove(target); //타겟팅 변경
            }
        }
    }

    public void PlayerNomalAttack(GameObject target)
    {

        print(target.name + "몬스터 클릭함!");
        animator.Play("Attack");
    }


    public void PlayerRun()
    {
        if(state != PlayerState.Run ) 
        {
            state = PlayerState.Run;
            if(canDash)
            animator.SetTrigger("DoRun");
        }
    }

    public void PlayerTrace()
    {
        if (state != PlayerState.Trace)
        {
            state = PlayerState.Trace;
            animator.SetTrigger("DoRun");
        }
    }

    public void PlayerIdle()
    {
        if (state != PlayerState.Idle)
        {
            state = PlayerState.Idle;
            animator.SetTrigger("DoIdle");
        }
    }

    public void PlayerAttack() // 기본공격 구현
    {
        if (state != PlayerState.Attack)
        {
            state = PlayerState.Attack;
            playermove.canMove = false;



            var dir = new Vector3(target.transform.position.x,target.transform.position.y,target.transform.position.z) - transform.position;
            playermove.playerCharacter.transform.forward = dir;

            animator.Play("Attack");
        }
    }

    public void PlayerDash()
    {
        if (state != PlayerState.Dash && canDash)
        {
            canDash = false;
            print("대쉬 시작");
            Afterglow.enabled = true;
            state = PlayerState.Dash;
            animator.SetTrigger("DoDash");
            playermove.agent.speed = Move_Speed * 3;
                Invoke("DashEnd",0.25f);
        }
    }
    public void DashEnd()
    {
        canDash = true;
        print("대쉬 종료");
        playermove.playerCharacter.localPosition = Vector3.zero;
        Afterglow.enabled = false;
        playermove.agent.speed = Move_Speed;
        if (playermove.isMove)
        {
            animator.SetTrigger("DoRun");
            PlayerRun();
        }
        else
        {
            PlayerIdle();
        }
    }


}
