using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController1 : MonoBehaviour
{
    public TMP_Text dialogText;
    void Start()
    {
        dialogText.text = "";
        string sampleText = "안녕하쇼";
        StartCoroutine(Typing(sampleText));
    }

    void Update()
    {

    }

    IEnumerator Typing(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
}