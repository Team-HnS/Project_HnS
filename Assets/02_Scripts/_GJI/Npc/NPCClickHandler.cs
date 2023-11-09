using UnityEditor.SceneManagement;
using UnityEngine;

public class NPCClickHandler : MonoBehaviour
{
    public GameObject uiObject; // 활성화할 UI 요소

    //public Vector3 uiOffset;   // NPC에서의 UI 오프셋

    public string npcID;        // NPC의 고유한 식별자

    public bool isUIActive = false;

    private void Start()
    {
        // UI 요소를 초기에 비활성화
        uiObject.SetActive(false);
    }

    private void Update()
    {
        uiObject.transform.forward = Camera.main.transform.forward;
    }

    public void ToggleUI()
    {
        Debug.Log("1111");
        isUIActive = !isUIActive;
        uiObject.SetActive(isUIActive);


    }
}