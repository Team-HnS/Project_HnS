using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Object/∏ÛΩ∫≈Õ")]
public class MonsterData : ScriptableObject
{
    public string MonsterName;
    public int id;
    public int hp;
    public int attack;
    public int defense;

    Dictionary<string, float> DropItem;

    public enum Rank
    {
        normal,
        elite,
        boss
    }    
}