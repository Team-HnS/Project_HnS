using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;

    [SerializeField]
    private bool isMove;

    [SerializeField]
    private Transform playerCharacter;//플레이어 캐릭터

    Player player;
    private void Awake()
    {
        cam = Camera.main;
       
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        player = GetComponent<Player>();
    }

    void Update()
    {
        LookMoveDirection();

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.gameObject.layer == 7 )
                {
                    SetDest(hit.point);
                    agent.velocity = agent.desiredVelocity.normalized * agent.speed;
                    player.PlayerRun(); // 이동 시킴
                }
            }
        }

     
    }

    private void SetDest(Vector3 dest)
    {
        agent.SetDestination(dest);
        isMove = true;
    }

    private void LookMoveDirection() // 이동시키는 함수
    {
        if (isMove)
        {
            print("작동");
            if (agent.remainingDistance == 0.0f && agent.velocity.sqrMagnitude < 0.1f * 0.1f && player.state == Player.PlayerState.Run)  // 변경
            {
                print("남은거리" + agent.remainingDistance + "속도" + agent.velocity.sqrMagnitude);
                print("무브끔작동");
                player.PlayerIdle();
                isMove = false;

               
                return;
            }

            // var dir = destination - transform.position;
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position; 
            //playerCharacter.transform.forward = dir;
            LerfRot(dir);
        }
    }

    public void LerfRot(Vector3 dir)
    {
        var targetRotation = Quaternion.LookRotation(dir); // 목표 회전값 계산

        // 부드럽게 회전하기 위해 Quaternion.Slerp 사용
        playerCharacter.transform.rotation = Quaternion.Slerp(playerCharacter.transform.rotation, targetRotation, 10 * Time.deltaTime);
    }
}
