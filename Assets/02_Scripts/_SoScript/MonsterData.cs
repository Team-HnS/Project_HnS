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
    public int level;
    public int exp;

    public List<ItemProbability> itemProbabilities = new List<ItemProbability>();

    public enum Rank
    {
        normal,
        elite,
        boss
    }    
}

[System.Serializable]
public class ItemProbability
{
    public Item item;
    public float probability;
}