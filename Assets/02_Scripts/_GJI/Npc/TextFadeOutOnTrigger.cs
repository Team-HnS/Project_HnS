using UnityEngine;
using UnityEngine.UI;

public class ImageFadeInOutOnTrigger : MonoBehaviour
{
    public GameObject imageObject; // 인스펙터에서 연결할 GameObject (이미지가 포함된 GameObject)
    public float fadeInDuration = 2f; // 페이드인 지속 시간
    public float fadeOutDuration = 2f; // 페이드아웃 지속 시간

    private Image imageComponent; // 이미지 컴포넌트
    private Color startColor; // 이미지 시작 색상
    private float fadeInTimer = 0f; // 페이드인 타이머
    private float fadeOutTimer = 0f; // 페이드아웃 타이머
    private bool isTriggered = false; // 트리거 활성화 여부

    private void Start()
    {
        if (imageObject != null)
        {
            imageComponent = imageObject.GetComponent<Image>();
            if (imageComponent != null)
            {
                imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, 0f); // 처음에 알파 값을 0으로 설정
                startColor = imageComponent.color; // 시작 색상 저장
                imageObject.SetActive(false); // 게임 시작 시 이미지를 비활성화
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            if (imageObject != null)
            {
                imageObject.SetActive(true); // 플레이어가 트리거에 진입하면 이미지를 활성화
                fadeInTimer = 0f; // 페이드인 타이머 초기화
            }
        }
    }

    private void Update()
    {
        if (isTriggered && imageComponent != null)
        {
            fadeInTimer += Time.deltaTime; // 시간 업데이트
            float progress = fadeInTimer / fadeInDuration; // 진행률 계산

            // 이미지의 알파 값을 변경하여 페이드인 효과 구현
            imageComponent.color = Color.Lerp(startColor, new Color(startColor.r, startColor.g, startColor.b, 1f), progress);

            if (fadeInTimer >= fadeInDuration)
            {
                fadeOutTimer += Time.deltaTime; // 페이드아웃 타이머 업데이트
                float fadeOutProgress = fadeOutTimer / fadeOutDuration; // 페이드아웃 진행률 계산

                // 이미지의 알파 값을 변경하여 페이드아웃 효과 구현
                imageComponent.color = Color.Lerp(new Color(startColor.r, startColor.g, startColor.b, 1f), startColor, fadeOutProgress);

                if (fadeOutTimer >= fadeOutDuration)
                {
                    imageObject.SetActive(false); // 페이드아웃이 완료되면 이미지를 비활성화
                    enabled = false; // 이 스크립트를 비활성화합니다.
                }
            }
        }
    }
}
