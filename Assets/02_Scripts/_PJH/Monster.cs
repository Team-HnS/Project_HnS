using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster : MonoBehaviour
{
    public MonsterData data;
    private EnemyFSM fsm;
    public Coin coinData;

    public int hp;

    private float dropRadius = 2f;
    private bool isDropped = false;

    private GameObject droppedCoin;
    private TMP_Text nameTag;

    private float fixedY;

    private void Start()
    {
        fsm = GetComponent<EnemyFSM>();
        hp = data.hp;
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
        fixedY = transform.position.y;
        // ������ ��� ��ġ
        Vector3 dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
        dropPosition.y = fixedY;

        // ��� �����۵鿡 ����
        foreach (ItemProbability itemProbability in data.itemProbabilities)
        {
            // Ȯ���� �°� ������ ���
            if (Random.value < itemProbability.probability)
            {
                if (!Physics.CheckSphere(transform.position, dropRadius, 12))
                {
                    dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
                    dropPosition.y = fixedY;
                }
                Instantiate(itemProbability.item, dropPosition, Quaternion.identity);
            }
        }

        // ��� ���
        coinData.coin = data.level * Random.Range(1, 11) + Random.Range(1, 11);

        if (coinData.coin >= 1 && coinData.coin <= 99)
        {
            droppedCoin = Instantiate(coinData.copperCoins, dropPosition, Quaternion.identity);
        }
        else if (coinData.coin >= 100 && coinData.coin <= 999)
        {
            droppedCoin = Instantiate(coinData.silverCoins, dropPosition, Quaternion.identity);
        }
        else if (coinData.coin >= 1000)
        {
            droppedCoin = Instantiate(coinData.goldCoins, dropPosition, Quaternion.identity);
        }
        nameTag = droppedCoin.GetComponentInChildren<TMP_Text>();
        if (nameTag != null)
        {
            nameTag.text = "���� " + coinData.coin;
            Debug.Log(nameTag.text);
            Debug.Log(coinData.coin);
        }

        // �� ������ �Ϸ�
        isDropped = true;

        // ���� ��� ó��
        Destroy(gameObject, 3);
    }
}
