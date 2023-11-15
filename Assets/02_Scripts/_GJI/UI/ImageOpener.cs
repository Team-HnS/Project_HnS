using UnityEngine;
using UnityEngine.UI;

public class ImageOpener : MonoBehaviour
{
    // 이미지를 참조할 Image 컴포넌트
    [SerializeField] private Image image;

    // 이미지가 열려있는지 여부를 나타내는 플래그
    private bool isImageOpen = false;

    // 버튼 클릭 시 호출되는 메서드
    public void QuestToggleImage()
    {
        //Quest Dialog Panel
        isImageOpen = !isImageOpen;
        image.gameObject.SetActive(isImageOpen);
    }

    public void DialogToggleimage() // 튜토리얼 npc 사용중
    {
        isImageOpen = !isImageOpen;
        image.gameObject.SetActive(isImageOpen);
    }

    public void DialogOnlyToggleimage()
    {
        isImageOpen = !isImageOpen;
        image.gameObject.SetActive(isImageOpen);
    }

    public void ToolgToggleimage()
    {
        isImageOpen = !isImageOpen;
        image.gameObject.SetActive(isImageOpen);
    }

    public void DeongunToggleimage()
    {
        isImageOpen = !isImageOpen;
        image.gameObject.SetActive(isImageOpen);
    }

    public void ObjectToggleimage()
    {
        isImageOpen = !isImageOpen;
        image.gameObject.SetActive(isImageOpen);
    }

}
