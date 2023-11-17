using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

/// <summary>
/// 몬스터 hp 관련 메소드 포함
/// 몬스터 사망 시 드랍하는 아이템 관련 메소드 포함
/// </summary>
public class Monster : MonoBehaviour
{    
    public MonsterData data; // 드랍할 아이템 리스트 포함

    private EnemyFSM fsm;
    private Outline outline;
    private NavMeshAgent agent;

    public int hp;
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    // 아이템 드랍
    private bool isDropped = false; // 여러번 드랍하지 않기 위함
    private float dropRadius = 3f;

    // 코인 드랍
    private int coinAmount;
    private GameObject droppedCoin;
    private TMP_Text nameTag;
    private Coin_Item coinData;

    private int cnt = 0; // 무한 루프 방지용

    private void Awake()
    {
        fsm = GetComponent<EnemyFSM>();
        outline = GetComponent<Outline>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Hp = data.hp;
    }

    private void Update()
    {
        if (fsm != null)
        {
            if (fsm.isDead && isDropped == false)
            {
                DieAndDrop();
            }
        }        
    }

    private void OnMouseOver()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    public void Damaged(int Damage) // 데미지 받는 함수
    {
        if (tag != "PunchingBag")
        {
            Hp -= Damage;
        }        
        UiCreateManager.Instance.CreateDamageFont(Damage, gameObject);
    }

    public void Damaged(int Damage, Color color) // 데미지 받는 함수 색칠놀이
    {
        if (tag != "PunchingBag")
        {
            Hp -= Damage;
        }
        UiCreateManager.Instance.CreateDamageFont(Damage, gameObject, color);
    }



    private void DieAndDrop()
    {
        PlayerManager.instance.player_s.Exp += data.exp;

        // 몬스터가 드랍 가능한 아이템들에 대해
        foreach (ItemProbability itemProbability in data.itemProbabilities)
        {
            // 드랍 위치
            Vector3 dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
            dropPosition.y = agent.transform.position.y + itemProbability.itemData.itemObj.transform.position.y;
            
            // 확률에 따라 드랍
            if (Random.value < itemProbability.probability)
            {
                // 겹치지 않도록 위치 재설정
                while (!Physics.CheckSphere(dropPosition, 0.5f, 12) && cnt < 500) // 일단 하드 코딩
                {
                    dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
                    dropPosition.y = agent.transform.position.y + itemProbability.itemData.itemObj.transform.position.y;
                    cnt++;
                }
                cnt = 0;


                // 코인 드랍
                if (itemProbability.itemData.isCoin)
                {                    
                    coinData = (Coin_Item)itemProbability.itemData;

                    // 코인 값 계산
                    coinAmount = data.level * Random.Range(1, 11) + Random.Range(1, 11);                    

                    if (coinAmount >= 1 && coinAmount <= 99)
                    {
                        droppedCoin = Instantiate(coinData.copperCoins, dropPosition, Quaternion.identity);
                    }
                    else if (coinAmount >= 100 && coinAmount <= 999)
                    {
                        droppedCoin = Instantiate(coinData.silverCoins, dropPosition, Quaternion.identity);
                    }
                    else if (coinAmount >= 1000)
                    {
                        droppedCoin = Instantiate(coinData.goldCoins, dropPosition, Quaternion.identity);
                    }
                    droppedCoin.GetComponent<Item>().coinAmount = coinAmount;
                    nameTag = droppedCoin.GetComponentInChildren<TMP_Text>();
                    if (nameTag != null)
                    {
                        nameTag.text = "코인 " + coinAmount;
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
