using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPMPBar : MonoBehaviour
{
    public Slider hp_Slider;
    public Slider mp_Slider;
    public Slider exp_Slider;

    public TMP_Text hpPer;
    public TMP_Text mpPer;

    public Player PlayerState;


    void Start()
    {
        hp_Slider = GameObject.Find("hp_Slider").GetComponent<Slider>();
        mp_Slider = GameObject.Find("mp_Slider").GetComponent<Slider>();
        exp_Slider = GameObject.Find("exp_Slider").GetComponent<Slider>();
        hpPer = GameObject.Find("hpPer").GetComponent<TMP_Text>();
        mpPer = GameObject.Find("mpPer").GetComponent<TMP_Text>();
        hp_Slider.minValue = 0;
        mp_Slider.minValue = 0;
        exp_Slider.minValue = 0;

    }

public float CharHpPer()
    {
        return (PlayerState.Cur_Hp / PlayerState.Max_Hp) * 100.0f;
    }
    


    private void Update()
    {
        hp_Slider.maxValue = PlayerState.Max_Hp;
        mp_Slider.maxValue = PlayerState.Max_Mp;
        exp_Slider.maxValue = PlayerState.Exp;

        hp_Slider.value = PlayerState.Cur_Hp;
        mp_Slider.value = PlayerState.Cur_Mp;

        float hpPercent = CharHpPer();
        hpPer.text = hpPercent.ToString() + " %";

    }

}
