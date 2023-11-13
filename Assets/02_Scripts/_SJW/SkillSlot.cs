using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{

    public SkillData _skillData;

    public Image skillimg;
    public Image skill_Colimg;
    public Sprite nullimg;
    public TMP_Text text;
    public KeyCode keyCode;


    public GameObject infopannel;
    public TMP_Text skill_name;
    public TMP_Text skill_info;
    public TMP_Text skill_explain;
    // Start is called before the first frame update

    private void Awake()
    {

        if (_skillData != null)
        {
            skillimg.sprite = _skillData.skill_Icon;
        }

        if(keyCode != KeyCode.None)
        {
            text.text = keyCode.ToString();
        }
        
    }

    private void OnMouseEnter()
    {
        print(gameObject.name +  "이벤트 테스트");
    }


    private void infoRefresh()
    {
        string s_type;

        if (_skillData != null) 
        {
            skill_name.text = _skillData.SkillName;
            skill_info.text = "계수 : " + _skillData.Coefficient[0] + "\n" + "타입 : 미정";
            skill_explain.text = _skillData.Skill_Explanation;
        }

    }

    public void UiOn()
    {
        if (_skillData == null)
        {
            return;
        }

            infoRefresh();
        infopannel.SetActive(true);
    }

    public void UiOff()
    {
        infoRefresh();
        infopannel.SetActive(false);
    }
}
