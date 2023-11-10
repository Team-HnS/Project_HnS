using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToPanelControl : MonoBehaviour
{
    public GameObject panel;

    public void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
