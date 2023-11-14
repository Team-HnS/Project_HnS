using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcUIManager : MonoBehaviour
{
    NPCClickHandler npcClickHandler;
    NPCClickHandler temp;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("11");
            // 마우스 오른쪽 버튼이 클릭되면 실행
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("12");
                if (hit.collider.gameObject.TryGetComponent<NPCClickHandler>(out npcClickHandler))
                {
                    temp = npcClickHandler;
                    Debug.Log("13");
                    // NPC에 해당하는 경우
                    hit.transform.GetComponent<NPCClickHandler>().ToggleUI(); // UI를 토글합니다.
                }
                else
                {
                    Debug.Log("14");
                    // 다른 오브젝트에 해당하는 경우
                    if (temp != null && temp.isUIActive)
                    {
                        Debug.Log("15");
                        // UI가 활성화되어 있으면 UI를 비활성화합니다.
                        temp.ToggleUI();
                        temp = null;
                    }
                }
            }
        }
    }
}
