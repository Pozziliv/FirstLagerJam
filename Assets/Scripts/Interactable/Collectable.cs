using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite _icon;
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
        if(_questIndex == _questSystem._questsIndex)
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
            Debug.Log("Interact");
            _questSystem.NextQuest();
            _outline.enabled = false;
            _isActivate = false;
            Destroy(this.gameObject);
        }
    }
}
