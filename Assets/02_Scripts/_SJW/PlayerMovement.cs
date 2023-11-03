using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    private Camera cam;
    [HideInInspector]
    public NavMeshAgent agent;


    public bool isMove;
    public bool canMove;

    [SerializeField]
    private Transform playerCharacter;//�÷��̾� ĳ����

    Player player;
    private void Awake()
    {
        cam = Camera.main;
        canMove = true;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        player = GetComponent<Player>();
    }

    private void Update()
    {
        if(player.state == Player.PlayerState.Trace )
        {
            if(agent.remainingDistance > player.Attack_Range)
            {
                SetDest(player.target.transform.position);
            }
            else
            {
                agent.SetDestination(transform.position);
                player.PlayerIdle();
                isMove = false;
            }
        }
    }

    public void PlayerMove() //��Ŭ�������� ȣ��Ǵ� �Լ�
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.transform.gameObject.layer == 7)
            {
                SetDest(hit.point);
                agent.velocity = agent.desiredVelocity.normalized * agent.speed;
                player.PlayerRun(); // �̵� ��Ŵ
            }
        }
    }

    public void PlayerTargetMove(GameObject target)
    {
        print("Ÿ�� ���� �۵�");
        SetDest(target.transform.position);
        player.PlayerTrace(); // �̵� ��Ŵ
    }


    private void SetDest(Vector3 dest)
    {
        agent.SetDestination(dest);
        isMove = true;
    }

    public  void LookMoveDirection() // �ش���ġ�� �ٶ󺸰� �ϴ� �Լ� => �� �����϶���
    {
        if (isMove)
        {
       
            if (agent.remainingDistance == 0.0f && agent.velocity.sqrMagnitude < 0.1f * 0.1f && player.state == Player.PlayerState.Run)  // �����̴� ���°� �ƴҶ�
            {
                print("�����Ÿ�" + agent.remainingDistance + "�ӵ�" + agent.velocity.sqrMagnitude);
                print("������۵�");
                player.PlayerIdle();
                isMove = false;

               
                return;
            }

            if(agent.remainingDistance != 0.0f)
            {
                var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
                LerfRot(dir);
            }

        }
    }


    public void LerfRot(Vector3 dir)
    {
        var targetRotation = Quaternion.LookRotation(dir); // ��ǥ ȸ���� ���

        // �ε巴�� ȸ���ϱ� ���� Quaternion.Slerp ���
        playerCharacter.transform.rotation = Quaternion.Slerp(playerCharacter.transform.rotation, targetRotation, 10 * Time.deltaTime);
    }
}
