using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLevelText : MonoBehaviour
{
    public TMP_Text PlayerLevText;

    public Player player;

    void Start()
    {
        PlayerLevText = GameObject.Find("PlayerLevel").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        PlayerLevText.text = "Lv. "+player.Lv.ToString();
    }
}
