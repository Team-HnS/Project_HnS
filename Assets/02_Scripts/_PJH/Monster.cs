using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 몬스터 hp 관련 메소드 포함
/// 몬스터 사망 시 드랍하는 아이템 관련 메소드 포함
/// </summary>
public class Monster : MonoBehaviour
{
    public MonsterData data;
    private EnemyFSM fsm;
    private Coin coinData;

    private int hp;

    public int Hp
    {
      get { return hp; }
      set { hp = value; }
    }

    private float dropRadius = 3f;
    private bool isDropped = false; // 여러번 드랍하지 마라

    private GameObject droppedCoin;
    private TMP_Text nameTag;

    private int cnt = 0; // 무한 루프 방지용


    private void Start()
    {
        fsm = GetComponent<EnemyFSM>();
        Hp = data.hp;
    }

    private void Update()
    {
        if (fsm.isDead && isDropped == false)
        {
            DieAndDrop();
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


    private void DieAndDrop()
    {
        
        // 몬스터가 드랍 가능한 아이템들에 대해
        foreach (ItemProbability itemProbability in data.itemProbabilities)
        {
            // 드랍 위치
            Vector3 dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
            dropPosition.y = itemProbability.itemData.itemObj.transform.position.y;
            
            // 확률에 따라 드랍
            if (Random.value < itemProbability.probability)
            {
                // 겹치지 않도록 위치 재설정
                while (!Physics.CheckSphere(dropPosition, 0.5f, 12) && cnt < 500) // 일단 하드 코딩
                {
                    dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
                    dropPosition.y = itemProbability.itemData.itemObj.transform.position.y;
                    cnt++;
                }
                cnt = 0;


                // 코인 드랍
                if (itemProbability.itemData.isCoin)
                {
                    coinData = (Coin)itemProbability.itemData; 

                    // 코인 값 계산
                    coinData.coin = data.level * Random.Range(1, 11) + Random.Range(1, 11);

                    //Debug.Log(coinData.coin);
                    
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
                    }
                }
                // 아이템 드랍
                else
                {
                    Instantiate(itemProbability.itemData.itemObj, dropPosition, Quaternion.identity);
                }
            }
        }

        // 템 떨구기 완료
        isDropped = true;

        // 몬스터 사망 처리
        Destroy(gameObject, 3);
    }
}
