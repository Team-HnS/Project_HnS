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

    private int hp;

    public int Hp
    { 
      get { return hp; } 
      set { hp = value; } 
    }

    private float dropRadius = 2f;
    private bool isDropped = false;

    private GameObject droppedCoin;
    private TMP_Text nameTag;

    private float fixedY;

    private void Start()
    {
        fsm = GetComponent<EnemyFSM>();
        Hp = data.hp;
    }

    private void Update()
    {
        if (fsm.isDead && isDropped == false)
        {
            Die();
        }
    }

    public void Damaged(int Damage) // 데미지 받는 함수
    {
        Hp -= Damage;
        UiCreateManager.Instance.CreateDamageFont(Damage,gameObject);
    }

    public void Damaged(int Damage,Color color) // 데미지 받는 함수 색칠놀이
    {
        Hp -= Damage;
        UiCreateManager.Instance.CreateDamageFont(Damage, gameObject, color);
    }


    private void Die()
    {
        fixedY = transform.position.y;
        // 아이템 드랍 위치
        Vector3 dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
        dropPosition.y = fixedY;

        // 드랍 아이템들에 대해
        foreach (ItemProbability itemProbability in data.itemProbabilities)
        {
            // 확률에 맞게 아이템 드랍
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

        // 골드 드랍
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
            nameTag.text = "코인 " + coinData.coin;
            Debug.Log(nameTag.text);
            Debug.Log(coinData.coin);
        }

        // 템 떨구기 완료
        isDropped = true;

        // 몬스터 사망 처리
        Destroy(gameObject, 3);
    }
}
