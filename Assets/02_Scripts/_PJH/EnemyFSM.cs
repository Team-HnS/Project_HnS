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

    public float detectionDistance = 15f; // �÷��̾� �ν�
    public float attackDistance = 3f; // ����
    public float enemySpeed = 2f; // �̵��ӵ�

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
        // �÷��̾�� �� ������ �Ÿ� ����
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // ���Ⱑ ����?
        if (monster.Hp <= 0 && EnemyCollider.enabled == true)
        {
            ChangeState(state.Die);
            isDead = true;
            //agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
            agent.enabled = false;
            EnemyCollider.enabled = false;
        }

        // �� ����־�
        if (isDead == false)
        {
            // ���� ������ �÷��̾ ħ���ߴ�.
            if (distanceToPlayer <= detectionDistance)
            {
                // ���ݹ��� ���� �ֱ�
                if (distanceToPlayer <= attackDistance)
                {
                    ChangeState(state.Attack);
                }
                // ��� ������
                else
                {
                    ChangeState(state.Move);
                }

                stopPos = transform.position;
                stopRotation = transform.rotation;

                // ������ ����
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    // ���ڸ�����
                    transform.position = stopPos;
                    transform.rotation = stopRotation;
                }
                // �������� �ʰ� �ִٸ�
                else
                {
                    // �÷��̾ ���� �̵�
                    LookMoveDirection();
                    agent.SetDestination(player.transform.position);
                    agent.velocity = agent.desiredVelocity.normalized * agent.speed;
                }

            }
            // ���� ������ �����ϴ�.
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
            animator.SetBool("Die", true);
        }
    }
}
