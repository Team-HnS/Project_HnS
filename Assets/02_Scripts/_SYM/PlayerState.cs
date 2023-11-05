using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class PlayerState : MonoBehaviour
{
    public TMP_Text hpText;
    public TMP_Text mpText;
    public TMP_Text strText;
    public TMP_Text dexText;
    public TMP_Text igtText;
    public TMP_Text defText;
    public TMP_Text atkSpdText;
    public TMP_Text movSpdText;

    public Player player;

    void Start()
    {
        hpText = GameObject.Find("hpVal").GetComponent<TMP_Text>();
        mpText = GameObject.Find("mpVal").GetComponent<TMP_Text>();
        strText = GameObject.Find("strVal").GetComponent<TMP_Text>();
        dexText = GameObject.Find("dexVal").GetComponent<TMP_Text>();
        igtText = GameObject.Find("igtVal").GetComponent<TMP_Text>();
        defText = GameObject.Find("defVal").GetComponent<TMP_Text>();
        atkSpdText = GameObject.Find("atkSpdVal").GetComponent<TMP_Text>();
        movSpdText = GameObject.Find("movSpdVal").GetComponent<TMP_Text>();
    }
    void Update()
    {

        hpText.text = player.Max_Hp.ToString();
        mpText.text = player.Max_Mp.ToString();
        strText.text = player.Str.ToString();
        dexText.text = player.Dex.ToString();
        igtText.text = player.Igt.ToString();
        defText.text = player.Def.ToString();
        atkSpdText.text = player.Attack_speed.ToString();
        movSpdText.text = player.Move_Speed.ToString();
    }


}
