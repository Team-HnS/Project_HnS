
using UnityEngine;

public class NPCClickHandler : MonoBehaviour
{
    public GameObject uiObject; // ?�성?�할 UI ?�소

    //public Vector3 uiOffset;   // NPC?�서??UI ?�프??

    public string npcID;        // NPC??고유???�별??

    public bool isUIActive = false;

    private void Start()
    {
        // UI ?�소�?초기??비활?�화
        uiObject.SetActive(false);
    }

    private void Update()
    {
        if (Camera.main != null)
            uiObject.transform.forward = Camera.main.transform.forward;
    }

    public void ToggleUI()
    {
        isUIActive = !isUIActive;

        Debug.Log(gameObject.name + ", " + (uiObject == null) );
        uiObject.SetActive(isUIActive);


    }
}