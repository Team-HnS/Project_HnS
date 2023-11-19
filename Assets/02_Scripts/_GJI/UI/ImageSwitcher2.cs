using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher2 : MonoBehaviour
{
    public Image[] images; // 이미지 배열
    private int currentImageIndex = 0; // 현재 이미지의 인덱스

    void Start()
    {
       
    }

    // 다음 이미지를 표시하는 함수
    public void ShowNextImage()
    {
        // 이미지가 마지막 이미지인 경우
        if (currentImageIndex == images.Length - 1)
        {
            // 이미지를 비활성화
            HideCurrentImage();
            // 현재 이미지 인덱스를 초기화
            currentImageIndex = 0;
        }
        else
        {
            // 이미지를 비활성화
            HideCurrentImage();
            // 다음 이미지 인덱스로 변경
            currentImageIndex++;
        }

        // 변경된 이미지를 활성화
        ShowCurrentImage();
    }

    // 현재 이미지를 활성화하는 함수
    void ShowCurrentImage()
    {
        images[currentImageIndex].gameObject.SetActive(true);
    }

    // 현재 이미지를 비활성화하는 함수
    public void HideCurrentImage()
    {
        images[currentImageIndex].gameObject.SetActive(false);
    }
}
