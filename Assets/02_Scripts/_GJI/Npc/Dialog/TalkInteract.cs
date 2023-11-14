using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TalkInteract : Interactable
{

    [SerializeField] DialogueContainer dialogue;
    public override void Interact(Character character)
    {
        Debug.Log("대화성공");
        GameManager.instance.dialogueSystem.Initialize(dialogue);
    }
}