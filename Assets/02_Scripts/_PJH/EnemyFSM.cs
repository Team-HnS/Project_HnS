using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class EnemyFSM : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    public Transform player; // 플레이어의 Transform을 할당하기 위한 public 변수

    public float detectionDistance = 10f; // 플레이어 인식
    public float attackDistance = 3f; // 공격
    public float enemySpeed = 2f; // 이동속도        

    private state currentState;

    enum state
    {
        Idle, Move, Attack, AttackDelay, Die
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어와 적 사이의 거리를 측정
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Debug.Log(distanceToPlayer);

        // 플레이어가 감지 거리 내에 있다면
        if (distanceToPlayer <= detectionDistance)
        {
            // 공격범위 내에 있다면
            if (distanceToPlayer <= attackDistance)
            {
                Debug.Log("공격");
                ChangeState(state.Attack);
                ChangeState(state.AttackDelay);
            }
            else
            {
                // 플레이어를 향해 이동
                LookMoveDirection();

                agent.SetDestination(player.transform.position);
                agent.velocity = agent.desiredVelocity.normalized * agent.speed;


                ChangeState(state.Move);                
            }
        }
        else
        {
            ChangeState(state.Idle);
        }

    }

    private void LookMoveDirection()
    {
        // var dir = destination - transform.position;
        var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
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
            animator.SetTrigger("Die");
        }
    }
}
