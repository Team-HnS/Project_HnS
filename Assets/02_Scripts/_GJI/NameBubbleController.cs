using UnityEngine;
using UnityEngine.UI;

public class NameBubbleController : MonoBehaviour
{
    public Text nameText;
    public Text speechText;
    public Transform npcTransform;
    public float interactionDistance = 3f;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, npcTransform.position);

        if (distance <= interactionDistance)
        {
            nameText.text = "NPC Name"; // NPC�� �̸� ����
            speechText.text = "�ȳ��ϼ���, �÷��̾�!"; // ��ȭ ���� ����
            ShowBubble();
        }
        else
        {
            HideBubble();
        }
    }

    void ShowBubble()
    {
        // UI ��� Ȱ��ȭ �� ��ġ ����
        nameText.gameObject.SetActive(true);
        speechText.gameObject.SetActive(true);
        transform.position = npcTransform.position + new Vector3(0, 2, 0); 
    }

    void HideBubble()
    {
        // UI ��� ��Ȱ��ȭ
        nameText.gameObject.SetActive(false);
        speechText.gameObject.SetActive(false);
    }
}
