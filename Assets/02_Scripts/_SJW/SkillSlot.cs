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

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
