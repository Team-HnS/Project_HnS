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
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            PlayerState = playerObject.GetComponent<Player>();
        }
        if (PlayerState != null)
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
        else
        {
            Debug.LogError("Player 오브젝트에 PlayerScript가 없습니다.");
        }


    }

    private void OnEnable()
    {
        Debug.Log("체력바 인애이블 호출");

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            PlayerState = playerObject.GetComponent<Player>();
        }
        if (PlayerState != null)
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
        else
        {
            Debug.LogError("Player 오브젝트에 PlayerScript가 없습니다.");
        }


    }

    public float CharHpPer()
    {
        return (PlayerState.Cur_Hp * 100.0f / PlayerState.Max_Hp);
    }
    public float CharMpPer()
    {
        return (PlayerState.Cur_Mp * 100.0f / PlayerState.Max_Mp) ;
    }



    private void Update()
    {
        hp_Slider.maxValue = PlayerState.Max_Hp;
        mp_Slider.maxValue = PlayerState.Max_Mp;
        exp_Slider.maxValue = PlayerState.Exp;

        hp_Slider.value = PlayerState.Cur_Hp;
        mp_Slider.value = PlayerState.Cur_Mp;

        float hpPercent = CharHpPer();
        hpPer.text = hpPercent.ToString("F1") + " %"; 
        float mpPercent = CharMpPer();
        mpPer.text = mpPercent.ToString("F1") + " %";

    }

}
