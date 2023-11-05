using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestWindow : MonoBehaviour
{
    public GameObject prefab;
    public GameObject QuestlistWindow;
    public void ClickQuestList()//���� ui ���� ����Ʈ â �������� 
    {
        DrawList();// ����Ʈâ �׸��� 
        QuestlistWindow.SetActive(true);//����Ʈ���  Ȱ��ȭ 
    }
    public void ExitButtonclick()//x��ư Ŭ���� 
    {
        QuestlistWindow.SetActive(false);//����Ʈâ ������ 
        DestroyList();// ����Ʈ ���������� 
    }
    public void DrawList()
    {
        for (int i = 0; i < CharacterManager.instance.myquests.Count; i++) 
        {
            GameObject go = instance(prefab);//����� prefab�� ������
            go.transform.parent = this.transform;
            Text Title = transform.GetChild(i).GetComponent<Text>();//���� text �ֱ� 
            Text goal = Title.transform.GetChild(0).GetComponent<Text>();//goal text �ֱ� 
            Text state = goal.transform.GetChild(0).GetComponent<Text>();//���������� �Ϸ����� ���� �������� ����
            Title.text = CharacterManager.instance.myquests[i].title.ToString();// ĳ���� �Ŵ����� ������Ʈ ���� ����
            goal.text = CharacterManager.instance.myquests[i].goal.ToString();//ĳ���͸Ŵ��� ������Ʈ �� ���� 

        }
            
        
        if (CharacterManager.instance.myquests[i].isSucess == false)//ĳ���� �Ŵ��� is sucess ���η� ���������� �Ϸ����� �ľ� 
        {
            state.text = "������";
        }
        else
        {
            state.text = "�Ϸ�";
        }
    }
    public void DestroyList()// destroy��Ű�� �Լ� 
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
