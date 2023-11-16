using UnityEngine;
using UnityEngine.UI;

public class ImageOpener : MonoBehaviour
{
    // 이미지를 참조할 Image 컴포넌트
    [SerializeField] private Image image;

    // 이미지가 열려있는지 여부를 나타내는 플래그
    private bool isImageOpen = false;

    // 버튼 클릭 시 호출되는 메서드
    public void QuestToggleImage() //퀘스트 npc사용
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

    public void restart() // 튜토리얼 npc 사용중 RE
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

    public void DeongunToggleimage() //던전npc 사용중
    {      
        isImageOpen = !isImageOpen;
        image.gameObject.SetActive(isImageOpen);
    }

    public void ObjectToggleimage() //오브젝트 판매상인 대화 패널
    {
        isImageOpen = !isImageOpen;
        image.gameObject.SetActive(isImageOpen);
    }

    public void ObjectShopToggleimage() //잡화상인 UI 대화 패널
    {
        isImageOpen = !isImageOpen;
        image.gameObject.SetActive(isImageOpen);
    }

    public void StartSceneOptionLoad()
    {
        isImageOpen = !isImageOpen;
        image.gameObject.SetActive(isImageOpen);
    }

    public void StartSceneNewLoad()
    {
        isImageOpen = !isImageOpen;
        image.gameObject.SetActive(isImageOpen);
    }

}
