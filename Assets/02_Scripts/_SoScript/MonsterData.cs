using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Object/∏ÛΩ∫≈Õ")]
public class MonsterData : ScriptableObject
{
    public string name;
    public int id;
    public int hp;
    public int attack;
    public int defense;

    Dictionary<M_Item, float> DropItem;

    public enum Rank
    {
        normal,
        elite,
        boss
    }
}