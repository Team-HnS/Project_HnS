using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;

    private bool isMove;
    private Vector3 destination;

    [SerializeField]
    private Transform playerCharacter;//�÷��̾� ĳ����


    private void Awake()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if(hit.transform.gameObject.layer == 7 )
                {
                    SetDest(hit.point);
                }

            }
        }

        LookMoveDirection();
    }

    private void SetDest(Vector3 dest)
    {
        agent.SetDestination(dest);
        destination = dest;
        isMove = true;
    }

    private void LookMoveDirection() // �̵���Ű�� �Լ�
    {
        if (isMove)
        {
            //if (Vector3.Distance(destination, transform.position) <= 0.1f)
            if (agent.velocity.magnitude == 0.0f)  // ����
            {
                isMove = false;
                return;
            }

            // var dir = destination - transform.position;
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;  // ����
            playerCharacter.transform.forward = dir;
        }
    }
}
