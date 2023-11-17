using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

/// <summary>
/// ���� hp ���� �޼ҵ� ����
/// ���� ��� �� ����ϴ� ������ ���� �޼ҵ� ����
/// </summary>
public class Monster : MonoBehaviour
{    
    public MonsterData data; // ����� ������ ����Ʈ ����

    private EnemyFSM fsm;
    private Outline outline;
    private NavMeshAgent agent;

    public int hp;
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    // ������ ���
    private bool isDropped = false; // ������ ������� �ʱ� ����
    private float dropRadius = 3f;

    // ���� ���
    private int coinAmount;
    private GameObject droppedCoin;
    private TMP_Text nameTag;
    private Coin_Item coinData;

    private int cnt = 0; // ���� ���� ������

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

    public void Damaged(int Damage) // ������ �޴� �Լ�
    {
        if (tag != "PunchingBag")
        {
            Hp -= Damage;
        }        
        UiCreateManager.Instance.CreateDamageFont(Damage, gameObject);
    }

    public void Damaged(int Damage, Color color) // ������ �޴� �Լ� ��ĥ����
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

        // ���Ͱ� ��� ������ �����۵鿡 ����
        foreach (ItemProbability itemProbability in data.itemProbabilities)
        {
            // ��� ��ġ
            Vector3 dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
            dropPosition.y = agent.transform.position.y + itemProbability.itemData.itemObj.transform.position.y;
            
            // Ȯ���� ���� ���
            if (Random.value < itemProbability.probability)
            {
                // ��ġ�� �ʵ��� ��ġ �缳��
                while (!Physics.CheckSphere(dropPosition, 0.5f, 12) && cnt < 500) // �ϴ� �ϵ� �ڵ�
                {
                    dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
                    dropPosition.y = agent.transform.position.y + itemProbability.itemData.itemObj.transform.position.y;
                    cnt++;
                }
                cnt = 0;


                // ���� ���
                if (itemProbability.itemData.isCoin)
                {                    
                    coinData = (Coin_Item)itemProbability.itemData;

                    // ���� �� ���
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
                        nameTag.text = "���� " + coinAmount;
                    }
                }
                // ������ ���
                else
                {
                    Instantiate(itemProbability.itemData.itemObj, dropPosition, Quaternion.identity);
                }
            }
        }

        // �� ������ �Ϸ�
        isDropped = true;

        // ���� ��� ó��
        Destroy(gameObject, 3);
    }
}
