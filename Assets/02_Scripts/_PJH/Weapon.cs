using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject monsterWeapon;
    private EnemyFSM fsm;
    private Player player;

    private void Awake()
    {
        fsm = GetComponent<EnemyFSM>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (fsm.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && other.CompareTag("Player"))
        {            
            player = other.GetComponent<Player>();
            player.Damaged(100);
            Debug.Log("들어왔다.");
        }
    }
}