using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private int _questIndex;
    [SerializeField] private Quests _questSystem;
    private bool _isActivate = false;

    private Outline _outline;

    private void Start()
    {
        _outline = GetComponent<Outline>();
    }

    private void Update()
    {
        if (_questIndex == _questSystem._questsIndex)
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

    private void OnTriggerEnter(Collider other)
    {
        if (_isActivate && other.TryGetComponent(out PlayerMovement player))
        {
            _isActivate = false;
            _outline.enabled = false;
            _questSystem.NextQuest();
        }
    }
}
