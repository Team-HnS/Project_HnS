using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public PlayerMovement player;//Player ��ũ��Ʈ 
    public TalkManager talkManager; // ��ȭ ������ ���� TalkManager ��ũ��Ʈ
    public int talkIndex; // ��ȭ �ε���
    private bool isAction; // ��ȭ �� ���θ� ��Ÿ���� �÷���
    private GameObject scanObject; // ��ȣ �ۿ��� ���
    public GameObject talkPanel; // ��ȭ �г�(GameObject)�� �����ϱ� ���� ����
    public Text UITalkText; // ��ȭ ������ ǥ���� UI Text ������Ʈ


    //������ �������� �̵������ϴ� ������Ʈ(Ŭ����)

    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public GameObject[] Stages; //���������� ������Ʈ�� ������� ������ ������Ʈ �迭�� �������� 

    //UI ����
    public Image[] UIhealth; //�̹����� 3���̹Ƿ� �迭 
    public Text UIPoint;
    public Text UIStage;
    public GameObject UIRestartBtn;

    //����Ʈ
    public QuestManager questManager;

    void Start()
    {
        questManager.CheckQuest(); //������ �������ڸ��� ����Ʈ �̸��� �������� 
    }

    void Update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }

    public void NextStage()
    {

        if (stageIndex < Stages.Length - 1)
        {   // ������ �������� �ƴ� ��� -> �������������� 

            Stages[stageIndex].SetActive(false);
            stageIndex++; //�������� ���� 
            Stages[stageIndex].SetActive(true); //���� �������� Ȱ��ȭ

            PlayerReposition(); //������ġ���� �÷��̾ �¾��?�ϴ� �Լ� 


            UIStage.text = "STAGE " + (stageIndex + 1);

        }
        else
        { //������ ���������� ��� ->���ӳ� 

            //�÷��̾� ��Ʈ�� ���� 
            Time.timeScale = 0; //�÷��̾ �̵����� �ʰ� �� 

            //������ 
            Debug.Log("���� Ŭ����");

            //UI �ٽý��۹�ư 
            Text btnText = UIRestartBtn.GetComponentInChildren<Text>();
            btnText.text = "GameClear!";
            UIRestartBtn.SetActive(true);


        }


        //Calculate point
        totalPoint += stagePoint; // ���� ��������Ʈ ��ü������ ���Խ�Ű�� 
        stagePoint = 0; //���� ����Ʈ �ʱ�ȭ
    }

    public void HealthDown()
    {

        if (health > 1)
        {//������ 0���� ũ�� �ܼ� ���� ����
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.3f);
        }
        else
        {// ������ 0���ϸ� ����

            //�÷��̾ �״� ���(����Ʈ)-> �÷��̾� �����ÿ� ����Ʈ ���Խ� Ȱ��ȭ
            //player.OnDie();

            //UI�� ��� ���
            Debug.Log("�׾����ϴ�.");

            //�ٽ� ���� ��ư 
            UIRestartBtn.SetActive(true);

            //�׾��� ��� ��� UI�� ��������� �ؾ��� -> All Health UI Off
            UIhealth[0].color = new Color(1, 0, 0, 0.3f);

        }
    }

    void PlayerReposition()
    {

        //player.VelocityZero(); // �÷��̾��� �ӵ��� 0���� �����Ͽ� ����(���� �ʿ��ϸ� Ȱ��ȭ)
        player.transform.position = new Vector3(-12, -2, -1); //�÷��̾��� ������ġ�� �ǵ��ƿ���
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj; // ��ȣ �ۿ��� ����� ����
        ObjData objData = scanObject.GetComponent<ObjData>(); // ����� ������ ������
        Talk(objData.id, objData.isNPC); // ��ȭ�� ����

        talkPanel.SetActive(isAction); // ��ȭ �г��� Ȱ��ȭ/��Ȱ��ȭ
    }

    public void Restart()
    { //������̹Ƿ� ó������ �ٽý����̶� ������ ����

        Time.timeScale = 1; //�÷��̾ �ٽ� ������ �� �ֵ��� �� 
        SceneManager.LoadScene(0);//���� ����ȣ�� ���� ����
    }

    public void PerformAction(GameObject scanObj)
    { 
        scanObject = scanObj;// ��ȣ �ۿ��� ����� �޾ƿɴϴ�.  
        ObjData objData = scanObject.GetComponent<ObjData>();// ����� ������ �������� ���� ObjData ������Ʈ�� ����մϴ�.
        Talk(objData.id, objData.isNPC);// ��ȭ�� �����մϴ�.
        talkPanel.SetActive(isAction);// ��ȭâ�� ��ȭ Ȱ��ȭ ���¿� ���� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ�մϴ�.
    }

    // ��ȭ�� ó���ϴ� �޼���
    void Talk(int id, bool isNPC)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id); // ������ obj�� id�� �Ѱ� ����Ʈ id�� ��ȯ���� 

        //id�� ����Ʈ id�� ���ϸ� -> �ش� id�� ���� ������Ʈ�� ���� ����Ʈ�� ��ȭ�� ��ȯ�ϰ� �����
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if (talkData == null)//��ȯ�� ���� null�̸� ���̻� ���� ��簡 �����Ƿ� action���º����� false�� ���� 
        {
            isAction = false; // ��ȭ�� �� �̻� �����Ƿ� ��ȭ �� ���¸� ����
            talkIndex = 0; // ��ȭ �ε��� �ʱ�ȭ
            questManager.CheckQuest(id); // ����Ʈ �ε��� 1����
            return; // ���� �ڵ� ���� �ߴ�
        }

        // ��ȭ ������ UI Text�� ǥ��
        UITalkText.text = talkData;

        isAction = true; // ��ȭ�� ���������Ƿ� ��� ����
        talkIndex++; // ���� ��ȭ �ε����� �̵�
    }
}
