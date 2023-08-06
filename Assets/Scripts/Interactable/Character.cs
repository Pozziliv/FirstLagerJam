using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Character : MonoBehaviour, IInteractable
{
    [SerializeField] private string[] _dialogueFileName;
    [SerializeField] private DialogueSystem _dialogueSystem;
    [SerializeField] private int[] _questIndexs;
    private int nowIndex = 0;
    [SerializeField] private Quests _questSystem;
    private bool _isActivate = false;

    private Outline _outline;

    private void Start()
    {
        _outline = GetComponent<Outline>();
    }

    private void Update()
    {
        if (_questIndexs[nowIndex] == _questSystem._questsIndex)
        {
            _outline.enabled = true;
            _isActivate = true;
        }
        else
        {
            _outline.enabled = false;
            _isActivate = false;
        }
    }

    public void Interact()
    {
        if (_isActivate)
        {
            _dialogueSystem.StartDialogue(_dialogueFileName[nowIndex]);
            if(_questIndexs.Length-1 > nowIndex)
                nowIndex++;
            _questSystem.NextQuest();
        }
    }
}
