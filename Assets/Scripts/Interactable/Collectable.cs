using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _questIndex;
    [SerializeField] private Quests _questSystem;
    private bool _isActivate = false;

    private void Update()
    {
        if(_questIndex == _questSystem._questsIndex)
        {
            _isActivate = true;
        }
        else
        {
            _isActivate = false;
        }
    }

    public void Interact()
    {
        if (_isActivate)
        {
            Debug.Log("Interact");
            _questSystem.NextQuest();
        }
    }
}
