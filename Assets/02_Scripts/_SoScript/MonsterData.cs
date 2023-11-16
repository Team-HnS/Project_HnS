using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Object/∏ÛΩ∫≈Õ")]
public class MonsterData : ScriptableObject
{
    public string MonsterName;
    public int level;
    public int hp;
    public int attack;
    public int defense;
    public int exp;
    public int id;
    public List<ItemProbability> itemProbabilities = new List<ItemProbability>();

    public float hitdelay;

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
    public ItemData itemData;
    public float probability;
}