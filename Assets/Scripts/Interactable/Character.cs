using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Character : MonoBehaviour, IInteractable
{
    [SerializeField] private string _dialogueFileName;
    [SerializeField] private DialogueSystem _dialogueSystem;

    public void Interact()
    {
        _dialogueSystem.StartDialogue(_dialogueFileName);
    }
}
