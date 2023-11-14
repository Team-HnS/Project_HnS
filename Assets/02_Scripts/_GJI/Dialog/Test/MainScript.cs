using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    private GameObject NPCDialog;
    private Text NPCText;

    void Start()
    {
        void Start()
        {
            NPCDialog = GameObject.Find("NPCDialog");
            NPCText = GameObject.Find("NPCText")?.GetComponent<Text>(); // null일 경우 예외 발생 방지
            if (NPCText == null)
            {
                Debug.LogError("NPCText not found or Text component is missing.");
            }
            NPCDialog.SetActive(false);
        }

    }

    public void NPCChatEnter(string text)
    {
        NPCText.text = text;
        NPCDialog.SetActive(true);
    }

    public void NPCChatExit()
    {
        NPCText.text = "";
        NPCDialog.SetActive(false);
    }
}