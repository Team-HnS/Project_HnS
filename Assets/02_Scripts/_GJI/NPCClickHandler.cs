using UnityEditor.SceneManagement;
using UnityEngine;

public class NPCClickHandler : MonoBehaviour
{
    public GameObject uiObject; // Ȱ��ȭ�� UI ���

    //public Vector3 uiOffset;   // NPC������ UI ������

    public string npcID;        // NPC�� ������ �ĺ���

    public bool isUIActive = false;

    private void Start()
    {
        // UI ��Ҹ� �ʱ⿡ ��Ȱ��ȭ
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
