using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour
{
    private static MainCanvasManager instance;

    [SerializeField]
    private GameObject deadPannel;
    [SerializeField]
    private GameObject optionPannel;

    public GameObject SkillSlotPannel;

    void Awake()
    {
        if (null == instance)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
            Destroy(this.gameObject);
        }
    }

    public static MainCanvasManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void DeadPannelShow() //����г� ���� �״�
    {
        if (deadPannel.activeSelf)
        {
            deadPannel.SetActive(false);
        }
        else
        {
            deadPannel.SetActive(true);
        }

    }

    public void OptionPannelShow() //�ɼ��г� ���� �״�
    {
        if (optionPannel.activeSelf)
        {
            optionPannel.SetActive(false);
        }
        else
        {
            optionPannel.SetActive(true);
        }

    }

}
