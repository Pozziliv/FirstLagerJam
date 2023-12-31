using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private WaitForSeconds _waiting = new WaitForSeconds(0.06f);

    [SerializeField] private List<TextAsset> _dialogueFiles = new List<TextAsset>();
    private List<string> _dialogueTexts = new List<string>();
    private string[] _dialogueLines;
    private int _index;

    [SerializeField] private Quests _questSystem;
    [SerializeField] private Heart _Heart;

    public void StartDialogue(string dialogueFileName)
    {
        foreach (var file in _dialogueFiles)
        {
            if(file.name == dialogueFileName)
            {
                _dialogueLines = file.text.Replace("\n", "").Split('\r');
                break;
            }
        }

        _dialogueWindow.SetActive(true);
        _text.text = string.Empty;
        _index = 0;
        StartCoroutine(PrintText(_dialogueLines));
    }

    private IEnumerator PrintText(string[] text)
    {
        foreach(char c in text[_index].ToCharArray())
        {
            _text.text += c;
            yield return _waiting;
        }
    }

    private void NextLine()
    {
        if(_index < _dialogueLines.Length - 1)
        {
            _index++;
            _text.text = string.Empty;
            StartCoroutine(PrintText(_dialogueLines));
        }
        else
        {
            StopAllCoroutines();
            _dialogueWindow.SetActive(false);
            
            if(_questSystem != null)
                _questSystem.NextQuest();
            if (_Heart != null && _Heart.isActivated)
                StartCoroutine(_Heart.End());
        }
    }

    private void SkipText()
    {
        if(_text.text == _dialogueLines[_index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            _text.text = _dialogueLines[_index];
        }
    }

    private void Update()
    {
        if (_dialogueWindow.activeSelf && Input.GetMouseButtonDown(0))
            SkipText();
    }
}
