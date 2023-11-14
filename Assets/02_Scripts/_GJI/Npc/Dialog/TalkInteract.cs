using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TalkInteract : Interactable
{

    [SerializeField] DialogueContainer dialogue;
    public override void Interact(Character character)
    {
        Debug.Log("��ȭ����");
        GameManager.instance.dialogueSystem.Initialize(dialogue);
    }
}