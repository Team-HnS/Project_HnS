using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    // ��ȭ ������ ǥ���� �ؽ�Ʈ �ʵ�
    [SerializeField] Text DialogText;

    // ĳ���� �̸��� ǥ���� �ؽ�Ʈ �ʵ�
    [SerializeField] Text NpcnameText;

    // ���� ���� ���� ��ȭ �����̳�
    DialogueContainer currentDialogue;

    // ���� �ؽ�Ʈ ������ �ε���
    int currentTextLine;

    // �� �����Ӹ��� ����Ǵ� ������Ʈ �޼���
    private void Update()
    {
        // ���콺 ���� ��ư�� Ŭ������ �� �ؽ�Ʈ�� ��ȯ�ϴ� �޼��� ȣ��
        if (Input.GetMouseButtonDown(0))
        {
            PushText();
        }
    }

    // ���� �ؽ�Ʈ�� ǥ���ϴ� �޼���
    private void PushText()
    {
        // ���� �ؽ�Ʈ �������� �̵�
        currentTextLine += 1;

        /*// ���� �ؽ�Ʈ ������ ��ȭ�� ���� �����ߴ��� Ȯ��
        if (currentTextLine >= currentDialogue.line.Count)
        {
            // ��ȭ�� ������ ��� ������ �޼��� ȣ��
            Conclude();
        }
        if (currentTextLine >= currentDialogue.line.Count)
        {
            // ���� �ؽ�Ʈ ǥ��
            DialogText.text = currentDialogue.line[currentTextLine];
        }*/
    }

    // ��ȭ �ý��� �ʱ�ȭ �޼���
    public void Initialize(DialogueContainer dialogueContainer)
    {
        // ��ȭ �ý��� Ȱ��ȭ
        Show(true);

        // ���� ��ȭ ����
        currentDialogue = dialogueContainer;

        // �ؽ�Ʈ ���� �ʱ�ȭ
        currentTextLine = 0;

        // ù ��° �ؽ�Ʈ ǥ��
        DialogText.text = currentDialogue.line[currentTextLine];
    }

    // ��ȭ �ý��� Ȱ��ȭ/��Ȱ��ȭ �޼���
    private void Show(bool v)
    {
        gameObject.SetActive(v);
    }

    // ��ȭ�� ������ �� ȣ��Ǵ� �޼���
    private void Conclude()
    {
        // ��ȭ �ý��� ��Ȱ��ȭ
        Show(false);

        // ����� �α� ���
        Debug.Log("Dialogue test // Stickcode post ");
    }
}
