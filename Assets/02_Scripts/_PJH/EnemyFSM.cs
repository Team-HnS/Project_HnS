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

    public Transform player; // �÷��̾��� Transform�� �Ҵ��ϱ� ���� public ����

    public float detectionDistance = 10f; // �÷��̾� �ν�
    public float attackDistance = 3f; // ����
    public float enemySpeed = 2f; // �̵��ӵ�        

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
        // �÷��̾�� �� ������ �Ÿ��� ����
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Debug.Log(distanceToPlayer);

        // �÷��̾ ���� �Ÿ� ���� �ִٸ�
        if (distanceToPlayer <= detectionDistance)
        {
            // ���ݹ��� ���� �ִٸ�
            if (distanceToPlayer <= attackDistance)
            {
                Debug.Log("����");
                ChangeState(state.Attack);
                ChangeState(state.AttackDelay);
            }
            else
            {
                // �÷��̾ ���� �̵�
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
        var targetRotation = Quaternion.LookRotation(dir); // ��ǥ ȸ���� ���

        // �ε巴�� ȸ���ϱ� ���� Quaternion.Slerp ���
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
