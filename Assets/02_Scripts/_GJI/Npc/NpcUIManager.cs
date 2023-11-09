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
            // ���콺 ������ ��ư�� Ŭ���Ǿ����� Ȯ��
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("12");
                if (hit.collider.gameObject.TryGetComponent<NPCClickHandler>(out npcClickHandler))
                {
                    temp = npcClickHandler;
                    Debug.Log("13");
                    // NPC�� Ŭ���Ǿ��� ��
                    hit.transform.GetComponent<NPCClickHandler>().ToggleUI(); // UI�� ����մϴ�.
                }
                else
                {
                    Debug.Log("14");
                    // �ٸ� ���� Ŭ������ ��
                    if (temp != null && temp.isUIActive)
                    {
                        Debug.Log("15");
                        // UI�� Ȱ��ȭ�� ���¶�� UI�� ��Ȱ��ȭ�մϴ�.
                        temp.ToggleUI();
                        temp = null;
                    }
                }
            }
        }
    }
}
