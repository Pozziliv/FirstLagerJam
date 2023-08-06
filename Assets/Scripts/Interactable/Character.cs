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
        TryGetComponent<Outline>(out _outline);
    }

    private void Update()
    {
        if (_questIndexs[nowIndex] == _questSystem._questsIndex)
        {
            if (_outline != null)
                _outline.enabled = true;
            _isActivate = true;
        }
        else
        {
            if (_outline != null)
                _outline.enabled = false;
            _isActivate = false;
        }

        if(_questSystem == null)
        {
            _isActivate = true;
        }
    }

    public void Interact()
    {
        if (_isActivate)
        {
            _dialogueSystem.StartDialogue(_dialogueFileName[nowIndex]);
            if(_questIndexs.Length-1 > nowIndex)
                nowIndex++;
        }
    }
}
