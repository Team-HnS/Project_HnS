using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f; // �÷��̾��� �̵� �ӵ�
    public float rotationSpeed = 10f; // �÷��̾��� ȸ�� �ӵ�

    private Vector3 destinationPoint; // �÷��̾ �̵��� ������ ��ǥ
    private bool shouldMove = false; // �÷��̾ �̵��ؾ� �ϴ��� ���θ� ��Ÿ���� �÷���

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ�� ����
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ���콺 Ŭ�� ��ġ�� ȭ�� �������� ���� �������� ��ȯ
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f)) // ����ĳ��Ʈ�� ���� ���콺 Ŭ�� �������� 100 ���� �̳��� ��ü�� ����
            {
                destinationPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z); // ������ ���� ���� (y ��ǥ�� ���� �÷��̾��� ���̷� ����)

                shouldMove = true; // �÷��̾ �̵��ؾ� ���� ǥ��
            }
            Debug.Log("�̵��Ѵ�~");
        }

        if (shouldMove)
        {
            Quaternion targetRotation = Quaternion.LookRotation(destinationPoint - transform.position); // ������ ������ ���� ȸ���� ���� ���
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // �ε巯�� ȸ���� ���� ���� ȸ���� ��ǥ ȸ������ ����

            transform.position = Vector3.MoveTowards(transform.position, destinationPoint, movementSpeed * Time.deltaTime); // ������ �������� �̵�

            if (transform.position == destinationPoint)
            {
                shouldMove = false; // �÷��̾ �������� �����ϸ� �̵��� ����
            }
            Debug.Log("�����~");
        }
    }
}
