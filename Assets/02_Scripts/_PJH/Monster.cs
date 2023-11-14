using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// ���� hp ���� �޼ҵ� ����
/// ���� ��� �� ����ϴ� ������ ���� �޼ҵ� ����
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
    private bool isDropped = false; // ������ ������� ����

    private GameObject droppedCoin;
    private TMP_Text nameTag;

    private int cnt = 0; // ���� ���� ������


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


    public void Damaged(int Damage) // ������ �޴� �Լ�
    {
        Hp -= Damage;
        UiCreateManager.Instance.CreateDamageFont(Damage,gameObject);
    }

    public void Damaged(int Damage,Color color) // ������ �޴� �Լ� ��ĥ����
    {
        Hp -= Damage;
        UiCreateManager.Instance.CreateDamageFont(Damage, gameObject, color);
    }


    private void DieAndDrop()
    {
        
        // ���Ͱ� ��� ������ �����۵鿡 ����
        foreach (ItemProbability itemProbability in data.itemProbabilities)
        {
            // ��� ��ġ
            Vector3 dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
            dropPosition.y = itemProbability.itemData.itemObj.transform.position.y;
            
            // Ȯ���� ���� ���
            if (Random.value < itemProbability.probability)
            {
                // ��ġ�� �ʵ��� ��ġ �缳��
                while (!Physics.CheckSphere(dropPosition, 0.5f, 12) && cnt < 500) // �ϴ� �ϵ� �ڵ�
                {
                    dropPosition = transform.position + Random.insideUnitSphere * dropRadius;
                    dropPosition.y = itemProbability.itemData.itemObj.transform.position.y;
                    cnt++;
                }
                cnt = 0;


                // ���� ���
                if (itemProbability.itemData.isCoin)
                {
                    coinData = (Coin)itemProbability.itemData; 

                    // ���� �� ���
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
                        nameTag.text = "���� " + coinData.coin;
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
