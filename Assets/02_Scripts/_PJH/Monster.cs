using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData data;
    public int hp;

    private void Start()
    {
        hp = data.hp;
    }

    
}
