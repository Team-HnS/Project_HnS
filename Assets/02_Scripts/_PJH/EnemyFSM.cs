using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.XR;

public class EnemyFSM : MonoBehaviour
{
    private NavMeshAgent agent;
    [HideInInspector] public Animator animator;

    private GameObject[] playerObj;
    private Transform player;

    public float detectionDistance = 15f; // 플레이어 인식
    public float attackDistance = 3f; // 공격
    public float enemySpeed = 2f; // 이동속도

    private Vector3 stopPos;
    private Quaternion stopRotation;

    private Monster monster;
    [HideInInspector] public bool isDead = false;
    private Collider EnemyCollider;


    enum state
    {
        Idle, Move, Attack, Die
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        playerObj = GameObject.FindGameObjectsWithTag("Player");
        player = playerObj[0].transform;

        monster = GetComponent<Monster>();
        EnemyCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어와 적 사이의 거리 측정
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 여기가 지옥?
        if (monster.Hp <= 0 && EnemyCollider.enabled == true)
        {
            ChangeState(state.Die);
            isDead = true;
            //agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
            agent.enabled = false;
            EnemyCollider.enabled = false;
        }

        // 난 살아있어
        if (isDead == false)
        {
            // 나의 영역에 플레이어가 침범했다.
            if (distanceToPlayer <= detectionDistance)
            {
                // 공격범위 내에 있군
                if (distanceToPlayer <= attackDistance)
                {
                    ChangeState(state.Attack);
                }
                // 어딜 도망가
                else
                {
                    ChangeState(state.Move);
                }

                stopPos = transform.position;
                stopRotation = transform.rotation;

                // 공격할 때는
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    // 제자리에서
                    transform.position = stopPos;
                    transform.rotation = stopRotation;
                }
                // 공격하지 않고 있다면
                else
                {
                    // 플레이어를 향해 이동
                    LookMoveDirection();
                    agent.SetDestination(player.transform.position);
                    agent.velocity = agent.desiredVelocity.normalized * agent.speed;
                }

            }
            // 나의 영역은 안전하다.
            else
            {
                ChangeState(state.Idle);
            }
        }
    }



    private void LookMoveDirection()
    {
        //var dir = destination - transform.position;
        var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        //Debug.Log(dir);
        //playerCharacter.transform.forward = dir;
        LerfRot(dir);
    }

    private void LerfRot(Vector3 dir)
    {
        var targetRotation = Quaternion.LookRotation(dir); // 목표 회전값 계산

        // 부드럽게 회전하기 위해 Quaternion.Slerp 사용
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
    }

    private void ChangeState(state state)
    {
        if (state == state.Idle)
        {
            animator.SetBool("Move", false);
        }
        else if (state == state.Move)
        {
            animator.SetBool("Move", true);
            animator.SetBool("Attack", false);
        }
        else if (state == state.Attack)
        {
            animator.SetBool("Attack", true);
        }
        else if (state == state.Die)
        {
            animator.SetBool("Die", true);
        }
    }
}
