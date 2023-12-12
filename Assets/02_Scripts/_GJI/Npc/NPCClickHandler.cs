
using UnityEngine;

public class NPCClickHandler : MonoBehaviour
{
    public GameObject uiObject; // ?œì„±?”í•  UI ?”ì†Œ

    //public Vector3 uiOffset;   // NPC?ì„œ??UI ?¤í”„??

    public string npcID;        // NPC??ê³ ìœ ???ë³„??

    public bool isUIActive = false;

    private void Start()
    {
        // UI ?”ì†Œë¥?ì´ˆê¸°??ë¹„í™œ?±í™”
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