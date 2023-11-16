using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Build_Pannel : MonoBehaviour
{

    public TMP_Text sptext;
    // Start is called before the first frame update

    private void OnEnable()
    {
        Refresh();
        SoundManager.instance.EffectPlay(0); //여는 효과음
    }

    private void OnDisable()
    {
        SoundManager.instance.EffectPlay(0); //여는 효과음
    }

    public void Refresh()
    {
        sptext.text = "스킬 포인트 : " + PlayerManager.instance.player_s.SkillPoint.ToString();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
