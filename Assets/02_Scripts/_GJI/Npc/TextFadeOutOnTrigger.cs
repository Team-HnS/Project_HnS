using UnityEngine;
using TMPro;
using System.Collections;

public class TextFadeOutOnTrigger : MonoBehaviour
{
    public GameObject textPrefab; // ������ �ؽ�Ʈ ������
    private GameObject currentText; // ���� ������ �ؽ�Ʈ ������Ʈ

    private void Start()
    {
        // Coroutine ����
        StartCoroutine(FadeOutTextRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ʈ���ſ� �÷��̾ �������� �� ����
            // �ؽ�Ʈ �������� �ν��Ͻ�ȭ�ϰ� Ʈ���� ��ġ�� ��ġ
            currentText = Instantiate(textPrefab, transform.position, Quaternion.identity);
            currentText.transform.SetParent(transform);

            // FadeOutTextRoutine �ڷ�ƾ�� �����Ͽ� �ؽ�Ʈ ���̵� �ƿ� ȿ�� ����
            StartCoroutine(FadeOutTextRoutine());
        }
    }

    IEnumerator FadeOutTextRoutine()
    {
        TMP_Text textComponent = currentText.GetComponentInChildren<TMP_Text>();
        if (textComponent != null)
        {
            Color startColor = textComponent.color; // �ؽ�Ʈ ���� ����
            float duration = 2f; // ���̵� �ƿ� ���� �ð�
            float timer = 0f; // Ÿ�̸� �ʱ�ȭ

            while (timer < duration)
            {
                timer += Time.deltaTime; // �ð� ������Ʈ
                float progress = timer / duration; // ����� ���

                // �ؽ�Ʈ�� ���� ���� �����Ͽ� ���̵� �ƿ� ȿ�� ����
                textComponent.color = Color.Lerp(startColor, new Color(startColor.r, startColor.g, startColor.b, 0f), progress);

                yield return null;
            }

            Destroy(currentText); // �ؽ�Ʈ ������Ʈ ����
        }
        else
        {
            Debug.LogWarning("TMP_Text component not found on the text prefab.");
            Destroy(currentText);
        }
    }
}
