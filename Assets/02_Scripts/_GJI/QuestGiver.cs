using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public static QuestGiver instance;
    public List<Quest> quests;
    //public CharacterManager character;
    public GameObject[] button;
    public GameObject questQindow;
    public Text titleText;
    public Text descriptionText;
    public GameObject rewardslot;
    public GameObject progress;
    public GameObject sucess;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }


}
