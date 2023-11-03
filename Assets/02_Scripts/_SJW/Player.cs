using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

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


    public GameObject target;

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
        cam = Camera.main;
        playermove = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();
        Afterglow = GetComponentInChildren<SkinnedMeshAfterImage>();
        SetState();


    }

    private void Start()
    {
        state = PlayerState.Idle;
    }


    void Update()
    {
        playermove.LookMoveDirection();

        if (Input.GetMouseButton(0))
        {
            playermove.PlayerMove();
        }

        if (Input.GetMouseButtonUp(0)) // 몬스터 클릭시
        {
            MouseBtnUpCheck();
        }

        if (Input.GetKeyDown(KeyCode.W) && state != Player.PlayerState.Dash)
        {
            PlayerDash();
        }

    }

    public void MouseBtnUpCheck()
    {
        if(!playermove.canMove)
        {
            return;
        }


        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            print(hit.transform.gameObject.name + "클릭");


            if (hit.transform.gameObject.layer == 10) //만약 클릭한게 몬스터였을경우
            {
                target = hit.transform.gameObject;
                print(hit.transform.gameObject.name + "몬스터 클릭함!");
                playermove.PlayerTargetMove(target);

               // PlayerNomalAttack(hit.transform.gameObject);
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
        if(state != PlayerState.Run) 
        {
            state = PlayerState.Run;
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
        if (state != PlayerState.Dash)
        {
            Afterglow.enabled = true;
            state = PlayerState.Dash;
            animator.SetTrigger("DoDash");
            playermove.agent.speed = Move_Speed * 3;
                Invoke("DashEnd",0.3f);
        }
    }
    public void DashEnd()
    {
        playermove.playerCharacter.localPosition = Vector3.zero;
        Afterglow.enabled = false;
        playermove.agent.speed = Move_Speed;
        if (playermove.isMove)
        {
            PlayerRun();
        }
        else
        {
            PlayerIdle();
        }
    }


}
