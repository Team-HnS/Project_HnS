using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject monsterWeapon;
    private EnemyFSM fsm;
    private Player player;
    private Collider weaponCollider;
    private Monster monster;

    private bool endAttack;

    private void Awake()
    {
        fsm = GetComponent<EnemyFSM>();
        weaponCollider = monsterWeapon.GetComponent<Collider>();
        monster = GetComponent<Monster>();
    }

    private void Start()
    {
        endAttack = false;
    }

    private void OnTriggerEnter(Collider other)
    {        
        // 1회 공격당 1회 데미지
        if (fsm.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && other.CompareTag("Player"))
        {            
            player = other.GetComponent<Player>();
            if (!endAttack)
            {
                Invoke("Damage", monster.data.hitdelay);
                endAttack = true;
            }
        }
    }

    private void Update()
    {       
        if (fsm.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            weaponCollider.enabled = true;
        }
        else
        {
            weaponCollider.enabled = false;
            endAttack = false;
        }
    }

    private void Damage()
    {
        player.Damaged(monster.data.attack);
    }
}