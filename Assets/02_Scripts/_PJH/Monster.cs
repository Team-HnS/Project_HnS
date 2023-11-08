using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData data;
    public int hp;

    // 추후 data를 통해 받아오도록 구현
    public GameObject itemPrefab; // 드랍할 아이템 프리팹
    public float dropProbability = 0.5f; // 아이템 드랍 확률

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
        // 아이템 드랍 확률 검사
        if (Random.value < dropProbability)
        {
            // 아이템 드랍 위치 설정
            Vector3 dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
            dropPosition.y = 0;

            // 아이템 드랍
            if (itemPrefab != null)
            {
                Instantiate(itemPrefab, dropPosition, Quaternion.identity);
                isDropped = true;
            }
        }

        // 몬스터 사망 처리
        Destroy(gameObject, 3);
    }
}
