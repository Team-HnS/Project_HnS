using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    { 
    Idle,
    Run,
    Dash,
    Casting,
    Attack,
    Skill,
    Death
    }
    public PlayerState state;

    private PlayerMovement playermove;
    private Animator animator;
    private SkinnedMeshAfterImage Afterglow;

    [SerializeField]
    private int max_hp;
    [SerializeField]
    private int max_mp;

    [SerializeField]
    private int cur_hp;
    [SerializeField]
    private int cur_mp;

    [SerializeField]
    private int str;//공격력
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


    public int Max_Hp {  get { return max_hp; } set { max_hp = value; } }
    public int Max_Mp { get { return max_mp; } set { max_mp = value; } }
    public int Cur_Hp { get { return cur_hp; } set { cur_hp = value; } }
    public int Cur_Mp { get { return cur_mp; } set { cur_mp = value; } }

    public int Str { get { return str; } set { str = value; } }
    public int Igt { get { return igt; } set { igt = value; } }
    public int Dex { get { return dex; } set { dex = value; } }
    public int Def { get { return def; } set { def = value; } }

    public float Attack_speed { get { return attack_speed; } set { attack_speed = value; } }
    public float Move_Speed { get { return move_speed; } set { move_speed = value; } }



    public void SetState() 
    {
        Max_Hp = 1000;
        Max_Mp = 1000;
        cur_hp = Max_Hp;
        cur_mp = Max_Mp;

        Str = 10;
        Igt = 10;
        Dex = 10;
        Def = 10;

        Attack_speed = 10f;
        Move_Speed = 5f;
    }

    private void Awake()
    {
        playermove = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();
        Afterglow = GetComponentInChildren<SkinnedMeshAfterImage>();
        SetState();


    }

    private void Start()
    {
        state = PlayerState.Idle;
    }



    public void PlayerRun()
    {
        if(state != PlayerState.Run) 
        {
            state = PlayerState.Run;
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
