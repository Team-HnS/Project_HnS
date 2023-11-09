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
            // 마우스 오른쪽 버튼이 클릭되었는지 확인
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("12");
                if (hit.collider.gameObject.TryGetComponent<NPCClickHandler>(out npcClickHandler))
                {
                    temp = npcClickHandler;
                    Debug.Log("13");
                    // NPC가 클릭되었을 때
                    hit.transform.GetComponent<NPCClickHandler>().ToggleUI(); // UI를 토글합니다.
                }
                else
                {
                    Debug.Log("14");
                    // 다른 곳을 클릭했을 때
                    if (temp != null && temp.isUIActive)
                    {
                        Debug.Log("15");
                        // UI가 활성화된 상태라면 UI를 비활성화합니다.
                        temp.ToggleUI();
                        temp = null;
                    }
                }
            }
        }
    }
}
