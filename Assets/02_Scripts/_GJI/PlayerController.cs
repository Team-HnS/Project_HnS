using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f; // 플레이어의 이동 속도
    public float rotationSpeed = 10f; // 플레이어의 회전 속도

    private Vector3 destinationPoint; // 플레이어가 이동할 목적지 좌표
    private bool shouldMove = false; // 플레이어가 이동해야 하는지 여부를 나타내는 플래그

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 감지
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 클릭 위치를 화면 공간에서 월드 공간으로 변환
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f)) // 레이캐스트를 통해 마우스 클릭 지점에서 100 유닛 이내에 물체를 감지
            {
                destinationPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z); // 목적지 지점 설정 (y 좌표는 현재 플레이어의 높이로 유지)

                shouldMove = true; // 플레이어가 이동해야 함을 표시
            }
            Debug.Log("이동한다~");
        }

        if (shouldMove)
        {
            Quaternion targetRotation = Quaternion.LookRotation(destinationPoint - transform.position); // 목적지 지점을 향해 회전할 방향 계산
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // 부드러운 회전을 위해 현재 회전을 목표 회전으로 보간

            transform.position = Vector3.MoveTowards(transform.position, destinationPoint, movementSpeed * Time.deltaTime); // 목적지 지점으로 이동

            if (transform.position == destinationPoint)
            {
                shouldMove = false; // 플레이어가 목적지에 도착하면 이동을 멈춤
            }
            Debug.Log("멈췄다~");
        }
    }
}
