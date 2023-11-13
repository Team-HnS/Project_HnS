using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour, IDragHandler, IEndDragHandler , IBeginDragHandler
{
    private RectTransform rectTransform;
    public SkillData _skillData;

    public int slotNumber;
    public Image skillimg;
    public Image skill_Colimg;
    public Sprite nullimg;
    public TMP_Text text;
    public KeyCode keyCode;

    public GameObject nullslot;

    public GameObject infopannel;
    public TMP_Text skill_name;
    public TMP_Text skill_info;
    public TMP_Text skill_explain;

    GameObject newslot;
    // Start is called before the first frame update

    private void Awake()
    {

        if (_skillData != null)
        {
            skillimg.sprite = _skillData.skill_Icon;
        }

        if (keyCode != KeyCode.None)
        {
            text.text = keyCode.ToString();
        }
        rectTransform = GetComponent<RectTransform>();
    }

    void Refresh() 
    {
        skillimg.sprite = _skillData.skill_Icon;
        infoRefresh();
    }


    private void OnMouseEnter()
    {
        print(gameObject.name + "이벤트 테스트");
    }


    private void infoRefresh()
    {
        string s_type = "";
        switch (_skillData.skilltype)
        {
            case SkillData.Type.active: s_type = "액티브"; break;
            case SkillData.Type.passive: s_type = "패시브"; break;
            case SkillData.Type.buff: s_type = "버프"; break;
            case SkillData.Type.none: s_type = "없음"; break;
        }
        if (_skillData != null)
        {
            skill_name.text = _skillData.SkillName;
            skill_info.text = "계수 : " + _skillData.Coefficient[0] + "%\n" + "타입 : " + s_type + "\n" + "소모마나 : " + _skillData.ManaRequirement[1];
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

        infopannel.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_skillData == null)
        {
            return;
        }

        // 드래그 중인 위치 업데이트
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
     

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_skillData == null)
        {
            return;
        }
        PlayerManager.instance.OnUiInteraction = false;
        Destroy(newslot);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (RaycastResult result in results)
        {
           if(result.gameObject.GetComponent<SkillSlot>())
            {
                Debug.Log("UI Name: " + result.gameObject.name);

                //키 코드 위치 변경
                KeyCode temp_key = keyCode;
                keyCode = result.gameObject.GetComponent<SkillSlot>().keyCode;
                result.gameObject.GetComponent<SkillSlot>().keyCode = temp_key;
                text.text = keyCode.ToString();
                result.gameObject.GetComponent<SkillSlot>().text.text = temp_key.ToString();

                //자식 위치 변경
                int childnum = transform.GetSiblingIndex();
                int targetchidnum = result.gameObject.transform.GetSiblingIndex();
                transform.SetSiblingIndex(targetchidnum);
                result.gameObject.transform.SetSiblingIndex(childnum);

                //리스트 배열 위치 변경
                int tempint = result.gameObject.GetComponent<SkillSlot>().slotNumber;

                SkillSlot temp = KeyInputManager.instance.ssp.skillSlots[slotNumber];
                KeyInputManager.instance.ssp.skillSlots[slotNumber] = result.gameObject.GetComponent<SkillSlot>();
                KeyInputManager.instance.ssp.skillSlots[tempint] = temp;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_skillData == null)
        {
            return;
        }

        UiOff();
        PlayerManager.instance.OnUiInteraction = true;
        int childnum = transform.GetSiblingIndex();
        newslot = Instantiate(nullslot, gameObject.transform.parent.parent);
        rectTransform = newslot.GetComponent<RectTransform>();
        newslot.transform.SetSiblingIndex(childnum);
        newslot.transform.parent = gameObject.transform.parent.parent.parent;

        Vector2 mousePosition = Input.mousePosition;
        rectTransform.position = mousePosition;
    }
}
