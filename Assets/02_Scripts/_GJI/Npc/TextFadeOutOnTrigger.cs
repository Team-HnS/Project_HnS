using UnityEngine;
using UnityEngine.UI;

public class ImageFadeInOutOnTrigger : MonoBehaviour
{
    public GameObject imageObject; // �ν����Ϳ��� ������ GameObject (�̹����� ���Ե� GameObject)
    public float fadeInDuration = 2f; // ���̵��� ���� �ð�
    public float fadeOutDuration = 2f; // ���̵�ƿ� ���� �ð�

    private Image imageComponent; // �̹��� ������Ʈ
    private Color startColor; // �̹��� ���� ����
    private float fadeInTimer = 0f; // ���̵��� Ÿ�̸�
    private float fadeOutTimer = 0f; // ���̵�ƿ� Ÿ�̸�
    private bool isTriggered = false; // Ʈ���� Ȱ��ȭ ����

    private void Start()
    {
        if (imageObject != null)
        {
            imageComponent = imageObject.GetComponent<Image>();
            if (imageComponent != null)
            {
                imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, 0f); // ó���� ���� ���� 0���� ����
                startColor = imageComponent.color; // ���� ���� ����
                imageObject.SetActive(false); // ���� ���� �� �̹����� ��Ȱ��ȭ
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
                imageObject.SetActive(true); // �÷��̾ Ʈ���ſ� �����ϸ� �̹����� Ȱ��ȭ
                fadeInTimer = 0f; // ���̵��� Ÿ�̸� �ʱ�ȭ
            }
        }
    }

    private void Update()
    {
        if (isTriggered && imageComponent != null)
        {
            fadeInTimer += Time.deltaTime; // �ð� ������Ʈ
            float progress = fadeInTimer / fadeInDuration; // ����� ���

            // �̹����� ���� ���� �����Ͽ� ���̵��� ȿ�� ����
            imageComponent.color = Color.Lerp(startColor, new Color(startColor.r, startColor.g, startColor.b, 1f), progress);

            if (fadeInTimer >= fadeInDuration)
            {
                fadeOutTimer += Time.deltaTime; // ���̵�ƿ� Ÿ�̸� ������Ʈ
                float fadeOutProgress = fadeOutTimer / fadeOutDuration; // ���̵�ƿ� ����� ���

                // �̹����� ���� ���� �����Ͽ� ���̵�ƿ� ȿ�� ����
                imageComponent.color = Color.Lerp(new Color(startColor.r, startColor.g, startColor.b, 1f), startColor, fadeOutProgress);

                if (fadeOutTimer >= fadeOutDuration)
                {
                    imageObject.SetActive(false); // ���̵�ƿ��� �Ϸ�Ǹ� �̹����� ��Ȱ��ȭ
                    enabled = false; // �� ��ũ��Ʈ�� ��Ȱ��ȭ�մϴ�.
                }
            }
        }
    }
}
