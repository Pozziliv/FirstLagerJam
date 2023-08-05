using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite _icon;

    public void Interact()
    {
        Debug.Log("Interact");
    }
}
