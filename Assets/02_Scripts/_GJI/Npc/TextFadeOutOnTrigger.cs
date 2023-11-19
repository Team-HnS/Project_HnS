using UnityEngine;
using TMPro;
using System.Collections;

public class TextFadeOutOnTrigger : MonoBehaviour
{
    public GameObject textPrefab; // 생성할 텍스트 프리팹
    private GameObject currentText; // 현재 생성된 텍스트 오브젝트

    private void Start()
    {
        // Coroutine 시작
        StartCoroutine(FadeOutTextRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 트리거에 플레이어가 진입했을 때 실행
            // 텍스트 프리팹을 인스턴스화하고 트리거 위치에 배치
            currentText = Instantiate(textPrefab, transform.position, Quaternion.identity);
            currentText.transform.SetParent(transform);

            // FadeOutTextRoutine 코루틴을 실행하여 텍스트 페이드 아웃 효과 적용
            StartCoroutine(FadeOutTextRoutine());
        }
    }

    IEnumerator FadeOutTextRoutine()
    {
        TMP_Text textComponent = currentText.GetComponentInChildren<TMP_Text>();
        if (textComponent != null)
        {
            Color startColor = textComponent.color; // 텍스트 시작 색상
            float duration = 2f; // 페이드 아웃 지속 시간
            float timer = 0f; // 타이머 초기화

            while (timer < duration)
            {
                timer += Time.deltaTime; // 시간 업데이트
                float progress = timer / duration; // 진행률 계산

                // 텍스트의 알파 값을 변경하여 페이드 아웃 효과 구현
                textComponent.color = Color.Lerp(startColor, new Color(startColor.r, startColor.g, startColor.b, 0f), progress);

                yield return null;
            }

            Destroy(currentText); // 텍스트 오브젝트 삭제
        }
        else
        {
            Debug.LogWarning("TMP_Text component not found on the text prefab.");
            Destroy(currentText);
        }
    }
}
