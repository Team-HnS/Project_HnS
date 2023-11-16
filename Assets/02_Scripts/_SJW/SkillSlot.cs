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

    public void Refresh() 
    {
        if(_skillData !=null)
        {
            skillimg.sprite = _skillData.skill_Icon;
        }
        else
        {
            skillimg.sprite = nullimg;
        }
        infoRefresh();
    }


    private void OnMouseEnter()
    {
        print(gameObject.name + "�̺�Ʈ �׽�Ʈ");
    }


    private void infoRefresh()
    {
        if(_skillData==null)
        {
            return;
        }


        string s_type = "";
        switch (_skillData.skilltype)
        {
            case SkillData.Type.active: s_type = "��Ƽ��"; break;
            case SkillData.Type.passive: s_type = "�нú�"; break;
            case SkillData.Type.buff: s_type = "����"; break;
            case SkillData.Type.none: s_type = "����"; break;
        }
        if (_skillData != null)
        {
            skill_name.text = _skillData.SkillName;
            skill_info.text = "��� : " + _skillData.Coefficient[0] + "%\n" + "Ÿ�� : " + s_type + "\n" + "�Ҹ𸶳� : " + _skillData.ManaRequirement[1];
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

        // �巡�� ���� ��ġ ������Ʈ
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
        SoundManager.instance.EffectPlay(3); //���� ȿ����
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (RaycastResult result in results)
        {
           if(result.gameObject.GetComponent<SkillSlot>())
            {
                Debug.Log("UI Name: " + result.gameObject.name);

                //Ű �ڵ� ��ġ ����
                KeyCode temp_key = keyCode;
                keyCode = result.gameObject.GetComponent<SkillSlot>().keyCode;
                result.gameObject.GetComponent<SkillSlot>().keyCode = temp_key;
                text.text = keyCode.ToString();
                result.gameObject.GetComponent<SkillSlot>().text.text = temp_key.ToString();

                //���Գѹ� ��ġ ����
                int changint = slotNumber;
                slotNumber = result.gameObject.GetComponent<SkillSlot>().slotNumber;
                result.gameObject.GetComponent<SkillSlot>().slotNumber = changint;

                //�ڽ� ��ġ ����
                int childnum = transform.GetSiblingIndex();
                int targetchidnum = result.gameObject.transform.GetSiblingIndex();
                transform.SetSiblingIndex(targetchidnum);
                result.gameObject.transform.SetSiblingIndex(childnum);

                //����Ʈ �迭 ��ġ ����
                int tempint = result.gameObject.GetComponent<SkillSlot>().slotNumber;
                print("����ġ : "+ slotNumber + "�ٲ� ��ġ : "+ tempint);
                print("����ġ : " + KeyInputManager.instance.ssp.skillSlots[slotNumber].name + "�ٲ� ��ġ : " + KeyInputManager.instance.ssp.skillSlots[tempint].name);

                SkillSlot temp = KeyInputManager.instance.ssp.skillSlots[slotNumber];
                print("������ : " + temp.name + "�����");
                print("�������� : " + this.name + "��������");
                KeyInputManager.instance.ssp.skillSlots[slotNumber] = this;
                print(slotNumber+"���Գѹ��� : " + KeyInputManager.instance.ssp.skillSlots[slotNumber] + "�����");

                KeyInputManager.instance.ssp.skillSlots[tempint] = temp;
                print(tempint+"���Գѹ��� : " + KeyInputManager.instance.ssp.skillSlots[tempint] + "�����");
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_skillData == null)
        {
            return;
        }
        SoundManager.instance.EffectPlay(2); //�����ϴ� ȿ����
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
