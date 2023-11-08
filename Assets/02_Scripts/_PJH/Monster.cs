using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData data;
    public int hp;

    // ���� data�� ���� �޾ƿ����� ����
    public GameObject itemPrefab; // ����� ������ ������
    public float dropProbability = 0.5f; // ������ ��� Ȯ��

    private float dropRadius = 1.0f;
    private EnemyFSM fsm;
    private bool isDropped = false;

    private void Start()
    {
        hp = data.hp;
        fsm = GetComponent<EnemyFSM>();
    }
    
    private void Update()
    {
        if (fsm.isDead && isDropped == false)
        {
            Die();
        }
    }
    
    private void Die()
    {
        // ������ ��� Ȯ�� �˻�
        if (Random.value < dropProbability)
        {
            // ������ ��� ��ġ ����
            Vector3 dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
            dropPosition.y = 0;

            // ������ ���
            if (itemPrefab != null)
            {
                Instantiate(itemPrefab, dropPosition, Quaternion.identity);
                isDropped = true;
            }
        }

        // ���� ��� ó��
        Destroy(gameObject, 3);
    }
}
