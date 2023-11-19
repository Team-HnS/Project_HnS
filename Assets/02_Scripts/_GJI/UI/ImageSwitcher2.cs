using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher2 : MonoBehaviour
{
    public Image[] images; // �̹��� �迭
    private int currentImageIndex = 0; // ���� �̹����� �ε���

    void Start()
    {
       
    }

    // ���� �̹����� ǥ���ϴ� �Լ�
    public void ShowNextImage()
    {
        // �̹����� ������ �̹����� ���
        if (currentImageIndex == images.Length - 1)
        {
            // �̹����� ��Ȱ��ȭ
            HideCurrentImage();
            // ���� �̹��� �ε����� �ʱ�ȭ
            currentImageIndex = 0;
        }
        else
        {
            // �̹����� ��Ȱ��ȭ
            HideCurrentImage();
            // ���� �̹��� �ε����� ����
            currentImageIndex++;
        }

        // ����� �̹����� Ȱ��ȭ
        ShowCurrentImage();
    }

    // ���� �̹����� Ȱ��ȭ�ϴ� �Լ�
    void ShowCurrentImage()
    {
        images[currentImageIndex].gameObject.SetActive(true);
    }

    // ���� �̹����� ��Ȱ��ȭ�ϴ� �Լ�
    public void HideCurrentImage()
    {
        images[currentImageIndex].gameObject.SetActive(false);
    }
}
