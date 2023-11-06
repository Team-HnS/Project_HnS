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
    private Animator animator;

    private GameObject[] playerObj;
    private Transform player;

    public float detectionDistance = 10f; // 플레이어 인식
    public float attackDistance = 3f; // 공격
    public float enemySpeed = 2f; // 이동속도

    private Vector3 prevPos;
    private Quaternion stopRotation;

    private Monster monster;
    private bool isDead = false;

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
        //if (playerObj != null )
        //{
        //    Debug.Log("찾았습니다.");
        //}

        monster = GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어와 적 사이의 거리를 측정
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);      

        // 죽음
        if (monster.hp <= 0 && isDead == false)
        {
            ChangeState(state.Die);
            isDead = true;
        }

        // 플레이어가 감지 거리 내에 있다면
        if (distanceToPlayer <= detectionDistance)
        {
            // 공격범위 내에 있다면
            if (distanceToPlayer <= attackDistance)
            {
                ChangeState(state.Attack);
            }
            else
            {
                ChangeState(state.Move);
            }
           
            prevPos = transform.position;
            stopRotation = transform.rotation;
            
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                transform.position = prevPos;
                transform.rotation = stopRotation;
            }
            else
            {
                // 플레이어를 향해 이동
                LookMoveDirection();
                agent.SetDestination(player.transform.position);
                agent.velocity = agent.desiredVelocity.normalized * agent.speed;
            }
        }
        else
        {
            ChangeState(state.Idle);
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
