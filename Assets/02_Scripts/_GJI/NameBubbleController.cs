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
            nameText.text = "NPC Name"; // NPC의 이름 설정
            speechText.text = "안녕하세요, 플레이어!"; // 대화 내용 설정
            ShowBubble();
        }
        else
        {
            HideBubble();
        }
    }

    void ShowBubble()
    {
        // UI 요소 활성화 및 위치 설정
        nameText.gameObject.SetActive(true);
        speechText.gameObject.SetActive(true);
        transform.position = npcTransform.position + new Vector3(0, 2, 0); 
    }

    void HideBubble()
    {
        // UI 요소 비활성화
        nameText.gameObject.SetActive(false);
        speechText.gameObject.SetActive(false);
    }
}
